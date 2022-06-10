import { AccountService } from "../_services/account.service";

export class DashData{
    acc:string;
    type: string;
    op: string;
    status: string;
   
    amount:string;

    constructor(acc:string, type: string, op: string, status: string,amount:string, ){
        this.acc=acc;
        this.type=type;
        this.op=op;
        this.status=status;
        this.amount=amount;
        

        }
}