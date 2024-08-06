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
  private isRefreshing = false;

  private httpService: GenericHttpService = inject(GenericHttpService);
  private authStatus = new BehaviorSubject<boolean>(this.hasToken());
  private refreshTokenSubject: BehaviorSubject<any> = new BehaviorSubject<any>(null);
  

  constructor( ) { }
  
  login(credentials: LoginRequest): Observable<JwtPayload> {
    return this.httpService.post<AuthResponse>('auth/login', credentials).pipe(
      map((response) =>  {
        localStorage.setItem(this.tokenKey, response.accessToken);
        localStorage.setItem(this.refrehKey, response.refreshToken);
        return this.decodeJwt(response.accessToken)
      })
    );
  }



  register(data: RegisterRequest): Observable<boolean> {
    // This could return confirmation of the registration or similar
    return this.httpService.post<boolean>('auth/register', data);
  }


  logout() : void {
    localStorage.removeItem('accessToken');
    localStorage.removeItem('refreshToken');
    this.authStatus.next(false);
    this.router.navigate(['/auth/login']);
  }

  isAuthenticated(): boolean {
    return this.authStatus.value;
  }

  private hasToken(): boolean {
    return !!localStorage.getItem(this.tokenKey);
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
        }),
        catchError(error => {
          this.logout();
          return throwError(() => error);
        })
      )
    
  }
  handleRefreshToken(): Observable<any> {
    if (!this.isRefreshing) {
      this.isRefreshing = true;
      this.refreshTokenSubject.next(null);

      return this.refreshToken().pipe(
        tap((res) => {
          this.isRefreshing = false;
          this.refreshTokenSubject.next(res.accessToken);
        })
      );
    } else {
      return this.refreshTokenSubject.pipe(
        switchMap(token => {
          if (token) {
            return of(token);
          }
          return of(null);
        })
      );
    }
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
