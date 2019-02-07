import { ContactService } from './../services/contact.service';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Contact } from '../model/contact.model';
import { ContactMail } from '../model/contact-mail.model';
import { ContactPhone } from '../model/contact-phone.model';
import { ContactType } from '../model/contact-type.model';
import { ContactTypeService } from '../services/contact-type.service';
import { MessageOperationService } from '../services/message-operation.service';
import { ContactPhoneService } from '../services/contact-phone.service';
import { ContactMailService } from '../services/contact-mail.service';

@Component({
  selector: 'app-edit-contact',
  templateUrl: './edit-contact.component.html',
  styleUrls: ['./edit-contact.component.css']
})
export class EditContactComponent implements OnInit {

  contactViewModel : Contact;  
  contactMailViewModel : ContactMail;  
  contactPhoneViewModel : ContactPhone;  
  contactTypeList : ContactType[];
  
  constructor(private router: Router, 
              private route: ActivatedRoute, 
              private serviceContact : ContactService,
              private serviceContactType : ContactTypeService,              
              private serviceMessage : MessageOperationService,
              private serviceContactPhone : ContactPhoneService,
              private serviceContactMail : ContactMailService
              ) {

    this.contactViewModel = new Contact();
    this.contactMailViewModel = new ContactMail;  
    this.contactPhoneViewModel = new  ContactPhone; 

   }


  ngOnInit() {

    this.getContactType();

    this.load();    
  }

  load() : void {

    let _id =  this.route.snapshot.paramMap.get("id");

    if (_id === null || _id === undefined || _id === "0") 
        this.router.navigate(["./"]);     

       this.serviceContact.get(parseInt(_id)).subscribe(data=>{
        
        this.contactViewModel = data;

       });    
  }

  addMail(email : ContactMail){
    
    let _mail = Object.assign({},email);

    if(this.contactViewModel.mails.some((item) => {      

        return item.address === email.address && item.contactTypeId === _mail.contactTypeId}))
    {

      this.serviceMessage.send(500, "Este e-mail já existe!");

    } else {

      _mail.contactId = this.contactViewModel.contactId;          

      this.serviceContactMail.post(_mail).subscribe(data => {
        
        this.serviceMessage.send(200, "Lista de e-mails atualizada com sucesso");

        this.load();

        this.contactMailViewModel = new ContactMail();

      },error => {
        
        this.serviceMessage.send(500, error.error);

      })
    }   
    
  }

  editMail(email : ContactMail){
    
    this.contactMailViewModel = Object.assign({}, email);
    
  }

  clearMail(){
    
    this.contactMailViewModel = new ContactMail();
    
  }

  removeMail(mail: ContactMail) {

    if (confirm(`Deseja remover o e-mail: ${mail.address}?`)) { 

    let _mail = Object.assign({}, mail);       

      this.serviceContactMail.delete(_mail).subscribe(data => {

      this.serviceMessage.send(200, "Lista de e-mails atualizada com sucesso");

      this.load();

      this.contactMailViewModel = new ContactMail();

    }, error => {

      this.serviceMessage.send(500, error.error);

        });
    }
  }


  addPhone(phone : ContactPhone){
    
    let _phone = Object.assign({}, phone);

    if(this.contactViewModel.phones.some((item) => {

      return item.number === _phone.number && _phone.contactTypeId === item.contactTypeId
    
      })){

      this.serviceMessage.send(500, "Este telefone já existe!");
      
    } else {

      _phone.contactId = this.contactViewModel.contactId;          

      this.serviceContactPhone.post(_phone).subscribe(data => {
        
        this.serviceMessage.send(200, "Lista de telefone atualizada com sucesso");

        this.load();

        this.contactPhoneViewModel = new ContactPhone();

      },error => {
        
        this.serviceMessage.send(500, error.error);

      })

    }   
  }

  editPhone(phone : ContactPhone){
    
    this.contactPhoneViewModel = Object.assign({},phone);
    
  }

  removePhone(phone: ContactPhone) {

    if (confirm(`Deseja remover o telefone: ${phone.number}?`)) { 

    let _phone = Object.assign({}, phone);       

      this.serviceContactPhone.delete(_phone).subscribe(data => {

      this.serviceMessage.send(200, "Lista de telefone atualizada com sucesso");

      this.load();

      this.contactPhoneViewModel = new ContactPhone();

    }, error => {

      this.serviceMessage.send(500, error.error);

        });
    }
  }

  clearPhone(){
    
    this.contactPhoneViewModel = new ContactPhone();
    
  }

  save(contact : Contact) : void{

    this.serviceContact.post(contact).subscribe(data=> {     
      
      this.serviceMessage.send(200, "Contato cadastrado com sucesso!");
      
      this.router.navigate(["./"]);

    },error => {

      this.serviceMessage.send(error.code, error.message);
      
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
