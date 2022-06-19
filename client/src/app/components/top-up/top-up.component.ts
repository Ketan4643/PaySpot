import { Component, OnInit } from '@angular/core';
import { CheckboxControlValueAccessor, FormBuilder } from '@angular/forms';
import { AdminService } from 'src/app/_services/admin.service';
import { TopupService } from 'src/app/_services/topup.service';

export interface PeriodicElement {
  name: string;
  position: number;
  AgentId: number;
  StoreName: string;
  phone:string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {position: 1, name: 'Abhishek', AgentId: 10079, StoreName: 'Gopal Communications',phone:'9988770000'},
  {position: 2, name: 'Abosh Kumar', AgentId: 40026, StoreName: 'Deep Tv centre', phone:'9988770000'},
  {position: 3, name: 'Ali Raj ', AgentId: 6941, StoreName: 'Ali Telecom', phone:'9988770000'},
  {position: 4, name: 'Karan Jindal', AgentId: 90122, StoreName: 'Jindal Karayana Store', phone:'9988770000'},
  {position: 5, name: 'Karan Singh', AgentId: 10811, StoreName: 'Rana Ent.', phone:'9988770000'},
  {position: 6, name: 'Sandeep Kumar', AgentId: 120107, StoreName: 'Sandeep Tel.', phone:'9988770000'},
  {position: 7, name: 'Bipin Kumar', AgentId: 140067, StoreName: 'OM Bipin', phone:'9988770000'},
  
];


@Component({
  selector: 'app-top-up',
  templateUrl: './top-up.component.html',
  styleUrls: ['./top-up.component.css']
})
export class TopUpComponent implements OnInit {
  searchKey: string;
  

  displayedColumns: string[] = ['position', 'name', 'AgentId', 'StoreName','phone','TopUp','check','confirm' ];
  dataSource = ELEMENT_DATA;
  data={"data":ELEMENT_DATA};

  show(ele:any){
    console.log(ele.name);
  }
  // applyfilter(){
  //   this.data.filter=this.searchKey.trim().toLowerCase();
  // }
  constructor(private adminService: AdminService, private formBuilder: FormBuilder,
    private topupService: TopupService ) { }

  ngOnInit(): void {
  }

  topup(dataSource){
    var basicmodel=dataSource;
    var model=JSON.stringify(basicmodel);
    console.log(model);
    this.topupService.topup(basicmodel).subscribe(response => {
        console.log(response);
      })
    
  }

}
