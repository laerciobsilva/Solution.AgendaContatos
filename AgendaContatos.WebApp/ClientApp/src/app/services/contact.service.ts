import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ErrorObservable } from 'rxjs/observable/ErrorObservable';
import {catchError} from 'rxjs/operators';
import { MessageOperationService } from './message-operation.service';
import { Contact } from '../model/contact.model';

@Injectable()
export class ContactService {

  urlApi = "/api/Contact/"
  
  constructor(private httpClient: HttpClient, private serviceMessage : MessageOperationService) { 

  }

  list() : Observable<Contact[]>{

    return this.httpClient.get<Contact[]>(`${this.urlApi}/list`);      
  }

  search(name : String = "", phone : String ="", mail : String="") : Observable<Contact[]>{



    return this.httpClient.get<Contact[]>(`${this.urlApi}/search?name=${name}&phone=${phone}&mail=${mail}`);      
  }

  get(id : number) : Observable<Contact>{

    return this.httpClient.get<Contact>(`${this.urlApi}${id}`);
  }

  post (contact : Contact): any{

    if (this.validate(contact)) {
      
      if (contact.contactId > 0) {

        return this.httpClient.put(`${this.urlApi}`, contact).pipe(catchError(this.handlerError));
      } else {
        return this.httpClient.post(`${this.urlApi}`, contact).pipe(catchError(this.handlerError));
      }
    }
  }

  delete (id : Number): any{

    return this.httpClient.delete(`${this.urlApi}/${id}`);
  } 

  validate(contact : Contact) : Boolean{

    if(contact.phones.length === 0) {

      this.serviceMessage.send(500,"O contato deve ter ao menos um telefone");

      return false;

    } else {

      return true;
    }

  }

  private handlerError(httpError : HttpErrorResponse) {   
       
      return new ErrorObservable({code : httpError.status, message : `${httpError.status}-${httpError.error}` }   );   
  }
}
