import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from "@angular/forms";
import { debounceTime, tap, switchMap, startWith, map } from "rxjs/operators";
import { States } from 'src/app/_models/states';
import { AdminService } from 'src/app/_services/admin.service';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {
  formGroup: FormGroup;
  states: States[] = [];
  isCitiesLoading: boolean = false;
  relationShip: string[] = ['Spouse', 'Son', 'Daughter', 'Friend', 'Relative', 'Other' ];
  gender: string[] = ['Male', 'Female', 'Others']
  userRoles: string[] = ['Admin', 'Operations', 'Sales', 'Agent', 'Distributor', 'SuperDistributor'];
  addressType: string[] = ['WorkAddress' ,'ResidenceAddress'];
  addressStatus: string[] = ['Owner', 'Leased', 'Rented'];

  constructor(private adminService: AdminService) { 
    this.formGroup = new FormGroup({
      basicInfo: new FormGroup({
        userRoles: new FormControl(0, [Validators.required]),
        gender: new FormControl(0, [Validators.required]),
        name: new FormControl(null, [Validators.required]),
        dateOfBirth: new FormControl(null,[Validators.required]),
        guardianName: new FormControl(null, [Validators.required]),
        nominee: new FormControl(null, [Validators.required]),
        relationShip: new FormControl(1, [Validators.required]),  
      }),
      addressInfo: new FormGroup({
        addressType: new FormControl(null, [Validators.required]),
        addressStatus: new FormControl(null, [Validators.required]),
        latitude: new FormControl(0, [Validators.required]),
        Longitude: new FormControl(0, [Validators.required]),
        address: new FormControl(null, [Validators.required]),
        city: new FormControl(null, [Validators.required]),
        pincode: new FormControl(null, [Validators.required]),
        stateCode: new FormControl(null, [Validators.required]),
        noOfPerson: new FormControl(null, [Validators.required]),
      })
    });
  }

  ngOnInit(): void {
    this.adminService.getStates().subscribe(states => this.states = states);
    // this.relationShip = ['Spouse', 'Son', 'Daughter', 'Friend', 'Relative', 'Other' ];
    // this.gender = ['Male', 'Female', 'Others']
    // this.userRoles = ['Admin', 'Operations', 'Sales', 'Agent', 'Distributor', 'SuperDistributor'];
  }


  //returns the form control object based on the form control name
  getFormControl(controlName: string): FormControl
  {
    return this.formGroup.get(controlName) as FormControl;
  }

  //returns the error message based on the given control name and errorType
  getErrorMessage(controlName: string, errorType: string): string
  {
    let errorMessage: string = "";
    switch (controlName)
    {
      case "city":
        {
          if (errorType == "required") errorMessage = "You must choose a <strong>City</strong>";
        }

      case "checkIn":
        {
          if (errorType == "required") errorMessage = "You must enter a <strong>Check-In Date</strong>";
        }

      case "checkOut":
        {
          if (errorType == "required") errorMessage = "You must enter a <strong>Check-Out Date</strong>";
        }
    }

    return errorMessage;
  }

}
