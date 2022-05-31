import { JsonpClientBackend } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';


@Component({
  selector: 'app-utilities',
  templateUrl: './utilities.component.html',
  styleUrls: ['./utilities.component.css']
})
export class UtilitiesComponent implements OnInit {

  nam: String;
  acc: String;
  data: any


  BillForm = new FormGroup(
    {
      name: new FormControl(''),
      phone: new FormControl(''),
      account: new FormControl(''),
      state: new FormControl(''),
      provider: new FormControl(''),
      type: new FormControl(''),
      amount: new FormControl('')

    }
    );

  constructor() { }

  ngOnInit(): void {
  }

  SendBill(){
    localStorage.setItem('form-data', JSON.stringify(this.BillForm.value));

    this.data=JSON.parse(localStorage.getItem('form-data'));
    this.nam=this.data.name;
    this.acc=this.data.account;

  }
  // RetBill(){
  //   let data=JSON.parse(localStorage.getItem('form-data'));
  //   this.nam=data.name;
  //   this.acc=data.account;
  // }

}
