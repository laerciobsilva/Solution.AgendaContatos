import { ContactPhone } from "./contact-phone.model";
import { ContactMail } from "./contact-mail.model";


export class Contact {
   
    public contactId : Number;

    public name : string;

    public address : string;

    public company : string ;    
    
    public phones : ContactPhone [];   

    public mails : ContactMail [];   
    
    constructor() {

        this.phones = new Array<ContactPhone>();

        this.mails = new Array<ContactMail>();

        this.contactId = 0;
    }
}