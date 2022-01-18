import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ToastrService } from 'ngx-toastr';
import { Querydto } from 'src/app/_models/querydto';
import { AdminService } from 'src/app/_services/admin.service';

@Component({
  selector: 'app-leads',
  templateUrl: './leads.component.html',
  styleUrls: ['./leads.component.css']
})
export class LeadsComponent implements AfterViewInit {
  displayedColumns: string[] = ['id','name','email','mobile','state','query','createdOn','pendingStatus'];
  dataSource = new MatTableDataSource([]);
  queries: Querydto[] = [];
  totalCount = 0;
  constructor(private adminService: AdminService, private toastr: ToastrService) { 
    
  }

  @ViewChild(MatPaginator) paginator: MatPaginator;

  ngAfterViewInit(): void {
      this.dataSource.paginator = this.paginator;
  }

  getQueries() {
    this.adminService.getQueries().subscribe(queries => {
      this.dataSource = new MatTableDataSource(queries);
      this.totalCount = queries.length;
    }); 
  }

}
