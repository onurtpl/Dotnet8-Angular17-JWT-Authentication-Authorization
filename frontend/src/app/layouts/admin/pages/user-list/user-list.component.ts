import { Component, inject, OnInit } from '@angular/core';
import { AdminService } from '../../services/admin.service';
import { PaginationRequest } from '../../../../common/interfaces/pagination-request';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.scss'
})
export class UserListComponent implements OnInit {

  private adminSrv = inject(AdminService);
  private http = inject(HttpClient);

  constructor() {


  }
  ngOnInit(): void {
    // debugger;
    let paginator = {
      PageNumber: 1,
      PageSize: 10,
      SearchText: ''

    } as PaginationRequest;
    this.adminSrv.getUsers(paginator).subscribe({
      next: (response) => console.log(response)
    });


  }

}
