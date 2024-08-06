import { Component } from '@angular/core';
import { AdminService } from '../../services/admin.service';
import { PaginationRequest } from '../../../../common/interfaces/pagination-request';

@Component({
  selector: 'app-user-detail',
  standalone: true,
  imports: [],
  templateUrl: './user-detail.component.html',
  styleUrl: './user-detail.component.scss'
})
export class UserDetailComponent {


  constructor(private adminSrv: AdminService) {
    this.adminSrv.getUsers({PageNumber : 1, PageSize: 5, SearchText: ''} as PaginationRequest).subscribe({
      next: (response) => {
        console.log(response);
      }
    })
  }

}
