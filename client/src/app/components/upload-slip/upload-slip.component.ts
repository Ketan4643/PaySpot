import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-upload-slip',
  templateUrl: './upload-slip.component.html',
  styleUrls: ['./upload-slip.component.css']
})
export class UploadSlipComponent implements OnInit {

  SlipForm= new FormGroup({
    payMode:new FormControl(''),
    amount:new FormControl(''),
    date:new FormControl(''),
    rctNo:new FormControl(''),


  });

  constructor() { }

  ngOnInit(): void {
  }

}
