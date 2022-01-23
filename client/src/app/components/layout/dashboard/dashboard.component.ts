import { Component, OnInit } from '@angular/core';
import { MediaChange, MediaObserver } from '@angular/flex-layout';
import { Querydto } from 'src/app/_models/querydto';
import { Booking } from 'src/app/_models/_admin/booking';
import { AdminService } from 'src/app/_services/admin.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  dashboardGridCols: number = 4;
  cardColspan: number = 2;
  bookings: Booking[] = [];
  queryData: Querydto[] = [];
  
  constructor(private mediaObserver: MediaObserver, private adminService:AdminService) { }

  ngOnInit(): void {
    this.adminService.getQueries().subscribe(queries => {
      this.queryData = queries;
      this.queryData = this.queryData.filter(x=> x.id < 6);
    });
    this.bookings = [
      {
        id: 1,
        city: "Doha",
        hotel: "Hiltop Hotel",
        checkIn: new Date("2025-08-10T18:30:00.000Z"),
        checkOut: new Date("2025-08-12T18:30:00.000Z"),
        adults: 1,
        children: 0,
        customerName: "Smith",
        country: "USA",
        dateOfBirth: new Date("1995-09-03T00:00:00.000Z"),
        gender: "male",
        phone: "(123)28189374",
        status: "Not Paid",
        roomType: "Standard Single Room",
        guest1Name: "John Doe",
        guest1Age: 30,
        guest1Gender: "male",
        guest2Name: "",
        guest2Age: "",
        guest2Gender: "",
        extraBed: false,
        dineIn: [
          false,
          false,
          false
        ],
        foods: [
          { name: "Non Veg Plater" }
        ],
        isExpanded: false
      },
      {
        id: 2,
        city: "Sydney",
        hotel: "Tranquil Tavern",
        checkIn: new Date("2025-10-13T18:30:00.000Z"),
        checkOut: new Date("2025-10-14T18:30:00.000Z"),
        adults: 1,
        children: 1,
        customerName: "Lucy",
        country: "India",
        dateOfBirth: new Date("2000-08-02T00:00:00.000Z"),
        gender: "female",
        phone: "99587487800",
        status: "Paid",
        roomType: "Business Class Single Room",
        guest1Name: "Lucy",
        guest1Age: 24,
        guest1Gender: "female",
        guest2Name: "",
        guest2Age: "",
        "guest2Gender": "",
        "extraBed": false,
        "dineIn": [
          true,
          true,
          false
        ],
        "foods": [],
        "isExpanded": false
      },
      {
        "id": 3,
        "city": "Amsterdam",
        "hotel": "Lorem Grand Hotel",
        "checkIn": new Date("2025-03-07T07:00:00.000Z"),
        "checkOut": new Date("2025-03-09T18:30:00.000Z"),
        "adults": 1,
        "children": 1,
        "customerName": "Mary",
        "country": "India",
        "dateOfBirth": new Date("2000-08-02T00:00:00.000Z"),
        "gender": "female",
        "phone": "99587487800",
        "status": "Paid",
        "roomType": "Business Class Single Room",
        "guest1Name": "Mary",
        "guest1Age": 24,
        "guest1Gender": "female",
        "guest2Name": "",
        "guest2Age": "",
        "guest2Gender": "",
        "extraBed": false,
        "dineIn": [
          true,
          true,
          false
        ],
        "foods": [],
        "isExpanded": false
      },
      {
        "id": 4,
        "city": "Amsterdam",
        "hotel": "Lorem Grand Hotel",
        "checkIn": new Date("2025-03-07T07:00:00.000Z"),
        "checkOut": new Date("2025-03-09T18:30:00.000Z"),
        "adults": 1,
        "children": 1,
        "customerName": "Mary",
        "country": "India",
        "dateOfBirth": new Date("2000-08-02T00:00:00.000Z"),
        "gender": "female",
        "phone": "99587487800",
        "status": "Paid",
        "roomType": "Business Class Single Room",
        "guest1Name": "Mary",
        "guest1Age": 24,
        "guest1Gender": "female",
        "guest2Name": "",
        "guest2Age": "",
        "guest2Gender": "",
        "extraBed": false,
        "dineIn": [
          true,
          true,
          false
        ],
        "foods": [],
        "isExpanded": false
      },
      {
        "id": 5,
        "city": "Amsterdam",
        "hotel": "Lorem Grand Hotel",
        "checkIn": new Date("2025-03-07T07:00:00.000Z"),
        "checkOut": new Date("2025-03-09T18:30:00.000Z"),
        "adults": 1,
        "children": 1,
        "customerName": "Mary",
        "country": "India",
        "dateOfBirth": new Date("2000-08-02T00:00:00.000Z"),
        "gender": "female",
        "phone": "99587487800",
        "status": "Paid",
        "roomType": "Business Class Single Room",
        "guest1Name": "Mary",
        "guest1Age": 24,
        "guest1Gender": "female",
        "guest2Name": "",
        "guest2Age": "",
        "guest2Gender": "",
        "extraBed": false,
        "dineIn": [
          true,
          true,
          false
        ],
        "foods": [],
        "isExpanded": false
      },
      {
        "id": 6,
        "city": "Amsterdam",
        "hotel": "Lorem Grand Hotel",
        "checkIn": new Date("2025-03-07T07:00:00.000Z"),
        "checkOut": new Date("2025-03-09T18:30:00.000Z"),
        "adults": 1,
        "children": 1,
        "customerName": "Mary",
        "country": "India",
        "dateOfBirth": new Date("2000-08-02T00:00:00.000Z"),
        "gender": "female",
        "phone": "99587487800",
        "status": "Paid",
        "roomType": "Business Class Single Room",
        "guest1Name": "Mary",
        "guest1Age": 24,
        "guest1Gender": "female",
        "guest2Name": "",
        "guest2Age": "",
        "guest2Gender": "",
        "extraBed": false,
        "dineIn": [
          true,
          true,
          false
        ],
        "foods": [],
        "isExpanded": false
      }
    ]
    // "roomtypes": [
    //   {
    //     "id": 1,
    //     "roomTypeName": "Standard Double Room",
    //     "price": 100,
    //     "vat": 0.1,
    //     "maxPersons": 2,
    //     "checkIn": "12:00 pm",
    //     "checkOut": "11:30 am"
    //   },
    //   {
    //     "id": 2,
    //     "roomTypeName": "Deluxe Double Room",
    //     "value": "Deluxe Double Room",
    //     "price": 120,
    //     "vat": 0.1,
    //     "maxPersons": 2,
    //     "checkIn": "12:00 pm",
    //     "checkOut": "11:30 am"
    //   },
    //   {
    //     "id": 3,
    //     "roomTypeName": "Business Class Double Room",
    //     "price": 150,
    //     "vat": 0.1,
    //     "maxPersons": 2,
    //     "checkIn": "12:00 pm",
    //     "checkOut": "11:30 am"
    //   },
    //   {
    //     "id": 4,
    //     "roomTypeName": "Standard Single Room",
    //     "price": 60,
    //     "vat": 0.1,
    //     "maxPersons": 1,
    //     "checkIn": "12:00 pm",
    //     "checkOut": "11:30 am"
    //   },
    //   {
    //     "id": 5,
    //     "roomTypeName": "Deluxe Single Room",
    //     "price": 75,
    //     "vat": 0.1,
    //     "maxPersons": 1,
    //     "checkIn": "12:00 pm",
    //     "checkOut": "11:30 am"
    //   },
    //   {
    //     "id": 6,
    //     "roomTypeName": "Business Class Single Room",
    //     "price": 90,
    //     "vat": 0.1,
    //     "maxPersons": 1,
    //     "checkIn": "12:00 pm",
    //     "checkOut": "11:30 am"
    //   }
    // ];

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
  }
}
