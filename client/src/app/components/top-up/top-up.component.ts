import { Component, OnInit } from '@angular/core';
import { CheckboxControlValueAccessor } from '@angular/forms';

export interface PeriodicElement {
  name: string;
  position: number;
  AgentId: number;
  StoreName: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {position: 1, name: 'Abhishek', AgentId: 10079, StoreName: 'Gopal Communications'},
  {position: 2, name: 'Abosh Kumar', AgentId: 40026, StoreName: 'Deep Tv centre'},
  {position: 3, name: 'Ali Raj ', AgentId: 6941, StoreName: 'Ali Telecom'},
  {position: 4, name: 'Karan Jindal', AgentId: 90122, StoreName: 'Jindal Karayana Store'},
  {position: 5, name: 'Karan Singh', AgentId: 10811, StoreName: 'Rana Ent.'},
  {position: 6, name: 'Sandeep Kumar', AgentId: 120107, StoreName: 'Sandeep Tel.'},
  {position: 7, name: 'Bipin Kumar', AgentId: 140067, StoreName: 'OM Bipin'},
  
];


@Component({
  selector: 'app-top-up',
  templateUrl: './top-up.component.html',
  styleUrls: ['./top-up.component.css']
})
export class TopUpComponent implements OnInit {
  searchKey: string;
  

  displayedColumns: string[] = ['position', 'name', 'AgentId', 'StoreName','TopUp','save' ];
  dataSource = ELEMENT_DATA;
  data=ELEMENT_DATA;

  // applyfilter(){
  //   this.datato.filter=this.searchKey.trim().toLowerCase();
  // }
  constructor() { }

  ngOnInit(): void {
  }



}
