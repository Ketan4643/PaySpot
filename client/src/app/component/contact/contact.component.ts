import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {
  querymodel: any = {};
  states: any = [];
  constructor() { }

  ngOnInit(): void {
    this.states = [
      'Arunachal Pradesh',
      'Bihar',
      'Chattisgarh',
      'Chandigarh',
      'Delhi',
      'Goa',
      'Haryana',
      'Jammu & Kashmir',
      'Karnataka',
      'Lakshdweep',
      'Manipur',
      'Maharashtra',
      'Nagaland',
      'Orrisa',
      'Pondichery',
      'Rajasthan',
      'Sikkim',
      'Tamilnadu',
      'Utter Pradesh',
      'West Bangal'
    ]
  }


}
