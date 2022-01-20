import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { States } from 'src/app/_models/states';
import { AdminService } from 'src/app/_services/admin.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  states: States[] = [];
  registerForm: FormGroup;
  validationError: string[] = [];

  constructor(private adminService: AdminService,
    private toastr: ToastrService,
    private fb: FormBuilder,
    private router: Router) {
    this.adminService.getStates().subscribe(states => {
      this.states = states;
      // this.states = this.states.filter(option => option.stateName.startsWith("A"));
    });
  }

  ngOnInit(): void {
    this.initilizeForm();
    // this.states = [
    //   'Arunachal Pradesh',
    //   'Bihar',
    //   'Chattisgarh',
    //   'Chandigarh',
    //   'Delhi',
    //   'Goa',
    //   'Haryana',
    //   'Jammu & Kashmir',
    //   'Karnataka',
    //   'Lakshdweep',
    //   'Manipur',
    //   'Maharashtra',
    //   'Nagaland',
    //   'Orrisa',
    //   'Pondichery',
    //   'Rajasthan',
    //   'Sikkim',
    //   'Tamilnadu',
    //   'Utter Pradesh',
    //   'West Bangal'
    // ]
  }

  matchValue(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      return control?.value === control?.parent?.controls[matchTo]?.value ? null : { isMatching: true }
    }
  }

  initilizeForm() {
    this.registerForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(3)]],
      email: ['', [Validators.required]],
      mobile: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(10)]],
      state: ['', [Validators.required]],
      query: ['', [Validators.required, Validators.minLength(3)]]
    })
  }

  register() {
    this.adminService.register(this.registerForm.value).subscribe(() => {
      this.toastr.success("Query Registered Successfully");
      Swal.fire({
        position: 'center',
        icon: 'success',
        title: 'Your work has been saved',
        showConfirmButton: false,
        timer: 2000
      })
      this.initilizeForm();
    })
  }

  filterFunction(opt: string) {
    console.log(opt)
    this.states = this.states.filter(option => option.stateName.startsWith(opt));
    console.log(this.states);
    return this.states;
  }
}
