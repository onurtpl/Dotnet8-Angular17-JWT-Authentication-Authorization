import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { inject, Injectable  } from '@angular/core';
import { environment } from '../../../environments/environment';
import { catchError, Observable, tap, throwError } from 'rxjs';
import { NotificationService } from './notification.service';

@Injectable({
  providedIn: 'root'
})
export class GenericHttpService {

  private http: HttpClient = inject(HttpClient);
  private baseUrl: string = environment.apiUrl; // Using environment variable

  constructor(
    private notifyService : NotificationService
  ) { }

  private handleError(error: HttpErrorResponse): Observable<never> {
    
    let errordata = error.error as {Message: string, StatusCode: number}
    let errorMessage = `Error: ${errordata.Message}`;
    console.log(errorMessage)
    this.notifyService.notify(errorMessage, 'Undo', {duration: 3000,});
    return throwError(() => new Error(errorMessage));
  }

  public get<T>(endpoint: string): Observable<T> {
    return this.http.get<T>(`${this.baseUrl}/${endpoint}`).pipe(
      tap(data => console.log('fetched data:', data)),
      catchError(this.handleError) 
    );
  }

  public post<T>(endpoint: string, data: any): Observable<T> {
    const url = `${this.baseUrl}/${endpoint}`;
    console.log('=============URL===============')
    console.log(url);
    console.log('=============URL===============')
    return this.http.post<T>(url, data).pipe(
      
      tap(data => console.log('posted data:', data)),
      catchError((error: HttpErrorResponse) => this.handleError(error))
      // catchError(this.handleError)
    );
  }

  public put<T>(endpoint: string, data: any): Observable<T> {
    return this.http.put<T>(`${this.baseUrl}/${endpoint}`, data).pipe(
      tap(data => console.log('updated data:', data)),
      catchError(this.handleError)
    );
  }

  public delete<T>(endpoint: string): Observable<T> {
    return this.http.delete<T>(`${this.baseUrl}/${endpoint}`).pipe(
      tap(data => console.log('deleted data:', data)),
      catchError(this.handleError)
    );
  }
}
