import { RefreshTokenRequest } from './../interfaces/refresh-token-request';
import { inject, Injectable } from '@angular/core';
import { GenericHttpService } from '../../../common/services/generic-http.service';
import { BehaviorSubject, catchError, map, Observable, of, switchMap, tap, throwError,} from 'rxjs';
import { LoginRequest } from '../interfaces/login-request';
import { RegisterRequest } from '../interfaces/register-request';
import { AuthResponse } from '../interfaces/auth-response';
import { JwtPayload } from '../../../common/interfaces/jwt-payload';
import { ForgotPasswordRequest } from '../interfaces/forgot-password-request';
import { ResetPasswordRequest } from '../interfaces/reset-password-request';
import { Router } from '@angular/router';




@Injectable({

  providedIn: 'root',
 
})

export class AuthService {
  private router = inject(Router);
  private tokenKey = 'accessToken';
  private refrehKey = 'refreshToken';
  private expireKey = 'expire';

  private httpService: GenericHttpService = inject(GenericHttpService);
 
  constructor( ) { }
  
  login(credentials: LoginRequest): Observable<JwtPayload> {
    return this.httpService.post<AuthResponse>('auth/login', credentials).pipe(
      map((response) =>  {
        localStorage.setItem(this.tokenKey, response.accessToken);
        localStorage.setItem(this.refrehKey, response.refreshToken);
        localStorage.setItem(this.expireKey, response.refreshTokenExpire);
        return this.decodeJwt(response.accessToken)
      })
    );
  }



  register(data: RegisterRequest): Observable<boolean> {
    // This could return confirmation of the registration or similar
    return this.httpService.post<boolean>('auth/register', data);
  }


  logout() : void {
    localStorage.removeItem(this.tokenKey);
    localStorage.removeItem(this.refrehKey);
    localStorage.removeItem(this.expireKey);
    this.router.navigate(['/auth/login']);
  }

  isAuthenticated(): boolean {
    const v = this.hasToken();
    return v;
  }



  private hasToken(): boolean {
    const token = localStorage.getItem(this.tokenKey);
    if(!token) {
      return false;
    }
    const expire = localStorage.getItem(this.expireKey);
    const expireDate = Date.parse(expire!);
    const isExpire =  Date.now() > expireDate
    
    if (isExpire)
      this.logout();
    return !isExpire
    
  }

  refreshToken(): Observable<AuthResponse> {
    const refreshToken = this.getRefreshToken();
    if (!refreshToken) {
      this.logout();
      return throwError('No refresh token available');
    }
    const user = this.decodeJwt(this.getAccessToken()!).email;
    return this.httpService.post<AuthResponse>(
      'auth/refreshtoken', 
      { refreshtoken: this.getRefreshToken(), user: user } as RefreshTokenRequest).pipe(
        tap(response => {
          localStorage.setItem(this.tokenKey, response.accessToken);
          localStorage.setItem(this.refrehKey, response.refreshToken);
          localStorage.setItem(this.expireKey, response.refreshTokenExpire);
        }),
        catchError(error => {
          this.logout();
          return throwError(() => error);
        })
      )
    
  }




  getAccessToken(): string | null {
    return localStorage.getItem('accessToken');
  }

  getRefreshToken(): string | null {
    return localStorage.getItem('refreshToken');
  }

  forgotPassword = (data: ForgotPasswordRequest) : Observable<boolean> => {
    return this.httpService.post('auth/forgotpassword', data);
  }

  resetPassword = (data: ResetPasswordRequest) : Observable<boolean> => {
    return this.httpService.post('auth/resetpassword', data);
  }

  
  private decodeJwt(token: string): JwtPayload {
    // Decoding JWT (simplified version, should use a proper library)
    const base64Url = token.split('.')[1];
    const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    const jsonPayload = decodeURIComponent(atob(base64).split('').map((c) => {
      return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(jsonPayload);
  }

  getUserDetail = () : JwtPayload | null => {
    var token = this.getAccessToken();
    if(!token) {
      return null;
    }
    var base64Url = token!.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    var jsonPayload = decodeURIComponent(atob(base64).split('').map((c) => {
      return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));
    return JSON.parse(jsonPayload);
  }

  getRoles = () : string[]  => {
    if(!this.getUserDetail())
      return [];
    return this.getUserDetail()?.role!;
  }

}
