import { Injectable } from '@angular/core';
import { GenericHttpService } from '../../../common/services/generic-http.service';
import { map, Observable } from 'rxjs';
import { PaginationResponse } from '../../../common/interfaces/pagination-response';
import { UserResponse } from '../../../common/interfaces/user-response';
import { PaginationRequest } from '../../../common/interfaces/pagination-request';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private http: GenericHttpService) { }

  getUsers = (request: PaginationRequest) : Observable<PaginationResponse<UserResponse>> => {
    return this.http.post<PaginationResponse<UserResponse>>('user/getusers', request);
   
  }
}
