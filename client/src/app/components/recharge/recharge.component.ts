import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-recharge',
  templateUrl: './recharge.component.html',
  styleUrls: ['./recharge.component.css'],
})
export class RechargeComponent implements OnInit {

  PrepaidForm= new FormGroup({
    mobile:new FormControl(''),
    circle:new FormControl(''),
    operator:new FormControl(''),
    amount:new FormControl(''),


  });

  PostpaidForm= new FormGroup({
    mobile:new FormControl(''),
    amount:new FormControl(''),
    operator:new FormControl(''),
    
  });

  DthForm= new FormGroup({
    DthNo:new FormControl(''),
    amount:new FormControl(''),
    operator:new FormControl(''),
    
  });

  LicForm= new FormGroup({
    LicNo:new FormControl(''),
    amount:new FormControl(''),
    mobile:new FormControl(''),
    


  });

  constructor() { }

  ngOnInit(): void {
  }

}
