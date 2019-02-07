import { Contact } from './../model/contact.model';
import { ContactService } from './../services/contact.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  
  ngOnInit(): void {
    
    this.getContacts();
  }

  listContacts : Contact[];
  
  constructor(private contactService : ContactService){

    this.listContacts = new Array<Contact>();
  }

  getContacts(){

    this.contactService.list().subscribe(data=>{

      this.listContacts = data;

    });

  }

  search(name : String, phone : String, mail : String){

    this.contactService.search(name,phone,mail).subscribe(data=>{

      this.listContacts = data;

    });

  }
  remove(contact : Contact){

    if(confirm(`Deseja excluir os dados de ${contact.name}?`)){

        this.contactService.delete(contact.contactId).subscribe(data=>{

          this.getContacts();
  
      });
    }
    
    
    

  }

}
