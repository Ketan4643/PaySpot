import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder, FormArray } from "@angular/forms";
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
  relationShip: string[] = ['Spouse', 'Son', 'Daughter', 'Friend', 'Relative', 'Other'];
  gender: string[] = ['Male', 'Female', 'Others']
  userRoles: string[] = ['Admin', 'Operations', 'Sales', 'Agent', 'Distributor', 'SuperDistributor'];
  addressType: string[] = ['WorkAddress', 'ResidenceAddress'];
  addressStatus: string[] = ['Owner', 'Leased', 'Rented'];
  basicInfo: FormGroup;
  workAddressInfo: FormGroup;
  homeAddressInfo: FormGroup;
  kycInfo: FormGroup;
  addressInfo: FormArray = new FormArray([]);

  constructor(private adminService: AdminService, private formBuilder: FormBuilder) {
    // this.formGroup = new FormGroup({
    //   basicInfo: new FormGroup({
    //     userRoles: new FormControl(0, [Validators.required]),
    //     gender: new FormControl(0, [Validators.required]),
    //     name: new FormControl(null, [Validators.required]),
    //     email: new FormControl(null, [Validators.required, Validators.email]),
    //     phoneNumber: new FormControl(null, [Validators.required, Validators.minLength(10), Validators.maxLength(10)]),
    //     dateOfBirth: new FormControl(null, [Validators.required]),
    //     guardianName: new FormControl(null, [Validators.required]),
    //     nominee: new FormControl(null, [Validators.required]),
    //     relationShip: new FormControl(1, [Validators.required]),
    //   }),
    //   addressInfo: new FormGroup({
    //     addressType: new FormControl('', [Validators.required]),
    //     addressStatus: new FormControl(null, [Validators.required]),
    //     latitude: new FormControl(0, [Validators.required]),
    //     Longitude: new FormControl(0, [Validators.required]),
    //     address: new FormControl(null, [Validators.required]),
    //     city: new FormControl(null, [Validators.required]),
    //     pincode: new FormControl(null, [Validators.required]),
    //     stateCode: new FormControl(null, [Validators.required]),
    //     noOfPerson: new FormControl(null, [Validators.required])
    //   })
    // });
  }

  ngOnInit(): void {
    this.adminService.getStates().subscribe(states => this.states = states);
    this.initiateForms();
    // this.relationShip = ['Spouse', 'Son', 'Daughter', 'Friend', 'Relative', 'Other' ];
    // this.gender = ['Male', 'Female', 'Others']
    // this.userRoles = ['Admin', 'Operations', 'Sales', 'Agent', 'Distributor', 'SuperDistributor'];
    this.formGroup = this.formBuilder.group({
      basicInfo: this.basicInfo,
      // addressInfo: new FormArray([this.workAddressInfo, this.homeAddressInfo])
      workAddressInfo: this.workAddressInfo,
      homeAddressInfo: this.homeAddressInfo,
      kycInfo: this.kycInfo
    })
  }

  initiateForms() {
    this.basicInfo = this.formBuilder.group({
      userRoles: ['', [Validators.required]],
      gender: ['', [Validators.required]],
      name: ['', [Validators.required]],
      email: ['', [Validators.required]],
      phoneNumber: ['', [Validators.required]],
      dateOfBirth: ['', [Validators.required]],
      guardianName: ['', [Validators.required]],
      nominee: ['', [Validators.required]],
      relationShip: ['', [Validators.required]]
    });

    this.workAddressInfo = this.formBuilder.group({
      addressType: new FormControl('WorkAddress', [Validators.required]),
      addressStatus: new FormControl(null, [Validators.required]),
      latitude: new FormControl(0, [Validators.required]),
      Longitude: new FormControl(0, [Validators.required]),
      address: new FormControl(null, [Validators.required]),
      city: new FormControl(null, [Validators.required]),
      pincode: new FormControl(null, [Validators.required]),
      stateCode: new FormControl(null, [Validators.required]),
      noOfPerson: new FormControl(null, [Validators.required])
    });

    this.homeAddressInfo = this.formBuilder.group({
      addressType: new FormControl('ResidenceAddress', [Validators.required]),
      addressStatus: new FormControl(null, [Validators.required]),
      latitude: new FormControl(0, [Validators.required]),
      longitude: new FormControl(0, [Validators.required]),
      address: new FormControl(null, [Validators.required]),
      city: new FormControl(null, [Validators.required]),
      pincode: new FormControl(null, [Validators.required]),
      stateCode: new FormControl(null, [Validators.required]),
      noOfPerson: new FormControl(null, [Validators.required])
    });

    this.kycInfo = this.formBuilder.group({
      profImage: new FormControl(''),
      adhar: new FormControl(''),
      panCard: new FormControl(''),
      addProof: new FormControl(''),
      addProofImage: new FormControl('')

    });
  };

    

  //returns the form control object based on the form control name
  getFormControl(controlName: string): FormControl {
    return this.formGroup.get(controlName) as FormControl;
  }

  //returns the error message based on the given control name and errorType
  getErrorMessage(controlName: string, errorType: string): string {
    let errorMessage: string = "";
    switch (controlName) {
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
