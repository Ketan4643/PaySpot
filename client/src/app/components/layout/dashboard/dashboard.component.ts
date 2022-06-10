import { Component, OnInit } from '@angular/core';
import { MediaChange, MediaObserver } from '@angular/flex-layout';
import { Booking } from 'src/app/_models/_admin/booking';
import { AdminService } from 'src/app/_services/admin.service';
import { Chart } from 'angular-highcharts';
import { columnChartOption } from 'src/app/_charts/column-chart';
import { donutChartOption } from 'src/app/_charts/donut-chart';
import { DashData } from 'src/app/_models/dashboardata';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  dashboardGridCols: number = 4;
  cardColspan: number = 2;
  bookings: Booking[] = [];
  // queryData: Querydto[] = [];
  isLoading: boolean = false;
  columnChart: Chart = new Chart(columnChartOption);
  donutChart: Chart = new Chart(donutChartOption);

  nam: String;
  acc: String;
  data: any;

  cardData: DashData[]=[
    new DashData("12345","prepaid","BSNL","complete","99"),
    new DashData("67890","postpaid","Airtel","complete","99"),
    new DashData("54321","prepaid","Jio","complete","99"),

  ]
  constructor(private mediaObserver: MediaObserver, private adminService:AdminService) { }

  ngOnInit(): void {
    // this.getQueries();
    this.mediaObserver.asObservable().subscribe((media: MediaChange[])=> {
      if(media.some(mediaChange => mediaChange.mqAlias == 'lt-sm')) {
        this.dashboardGridCols = 1;
        this.cardColspan = 1;

      } else if(media.some(mediaChange => mediaChange.mqAlias == 'lt-md')) {
        this.dashboardGridCols = 2;
        this.cardColspan = 2;
      } else {
        this.dashboardGridCols = 4;
        this.cardColspan = 2;
      }
    })

    this.data=JSON.parse(localStorage.getItem('form-data'));
    this.nam=this.data.name;
    this.acc=this.data.account;
  }

  // getQueries() {
  //   this.adminService.getQueries().subscribe(queries => {
  //     setTimeout(() => {
  //       this.isLoading = true;
  //       this.queryData = queries;
  //       this.queryData = this.queryData.filter(x=> x.id < 9);
  //     }, 1000);
      
  //     this.isLoading = false;
  //   });
  // }
}
