import { Contact } from '../model/contact.model';
import { ContactService } from '../services/contact.service';
import { ContactType } from '../model/contact-type.model';
import { Component, OnInit, } from '@angular/core';
import { ContactMail } from '../model/contact-mail.model';
import { ContactPhone } from '../model/contact-phone.model';
import { ContactTypeService } from '../services/contact-type.service';
import { MessageOperationService } from '../services/message-operation.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-contact',
  templateUrl: './new-contact.component.html',
  styleUrls: ['./new-contact.component.css']
})
export class NewContactComponent implements OnInit {

  contactViewModel : Contact;  
  contactMailViewModel : ContactMail;  
  contactPhoneViewModel : ContactPhone;  
  contactTypeList : ContactType[];

  
  constructor(private serviceContact : ContactService, 
              private serviceContactType : ContactTypeService,
              private serviceMessage : MessageOperationService,
              private router : Router
              ) { 

    this.contactViewModel = new Contact();
    this.contactMailViewModel = new ContactMail;  
    this.contactPhoneViewModel = new  ContactPhone;  
  }

  ngOnInit() {

    this.getContactType();
  }

  addMail(email : ContactMail){
    
    let _mail = Object.assign({},email);

    if(this.contactViewModel.mails.some((item) => {      
        return item.address === email.address;}))
    {

      this.serviceMessage.send(500, "Este e-mail já existe!");

    } else {
      
      this.contactViewModel.mails.push(_mail);
      
      this.contactMailViewModel = new ContactMail();
    }   
    
  }

  removeMail(mail: ContactMail) {

    if (confirm(`Deseja remover o e-mail: ${mail.address}?`)) { 

    let _mail = Object.assign({}, mail);       

    this.contactViewModel.mails = this.contactViewModel.mails.filter(item=>{
        item !== _mail;
    });
   
    }      
  }

  addPhone(phone : ContactPhone){
    
    let _phone = Object.assign({},phone);

    if(this.contactViewModel.phones.some((item) => {return item.number === phone.number;})){
      
      this.serviceMessage.send(500, "Este telefone já existe!");

    } else {

      this.contactViewModel.phones.push(_phone);
      phone = new ContactPhone();

    }   
  }

  removePhone(phone: ContactPhone) {

    if (confirm(`Deseja remover o telefone: ${phone.number}?`)) { 

    let _phone = Object.assign({}, phone);       

    this.contactViewModel.phones = this.contactViewModel.phones.filter(item=>{
        item !== _phone;
    });
   
    }      
  }

  save(contact : Contact) : void{

    this.serviceContact.post(contact).subscribe(data=> {     
      
      this.serviceMessage.send(200, "Contato cadastrado com sucesso!");       

      this.router.navigate(["./"]);

    },error => {

      this.serviceMessage.send(500, error.error);
      
    });

  }

  getContactType():void{
    
    this.serviceContactType.list().subscribe(data=>{
      
      this.contactTypeList = data;

    },error => {

      this.serviceMessage.send(error.code, error.message);
    });
  }

}
