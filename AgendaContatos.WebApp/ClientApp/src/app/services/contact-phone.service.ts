import { Injectable } from '@angular/core';
import { HttpErrorResponse, HttpClient } from '@angular/common/http';
import { ErrorObservable } from 'rxjs/observable/ErrorObservable';
import { ContactPhone } from '../model/contact-phone.model';
import { Observable } from 'rxjs/Observable';
import { Contact } from '../model/contact.model';
import { MessageOperationService } from './message-operation.service';
import { catchError } from 'rxjs/operators';

@Injectable()
export class ContactPhoneService {

  urlApi = "/api/Phone/"
  
  constructor(private httpClient: HttpClient, private serviceMessage : MessageOperationService) { 

  }

  list() : Observable<ContactPhone[]>{

    return this.httpClient.get<ContactPhone[]>(`${this.urlApi}/list`);      
  }

  get(id : number) : Observable<ContactPhone>{

    return this.httpClient.get<ContactPhone>(`${this.urlApi}${id}`);
  }

  post (contactPhone : ContactPhone): any{

    if (this.validate(contactPhone)) {
      
      if (contactPhone.contactPhoneId > 0) {

        return this.httpClient.put(`${this.urlApi}`, contactPhone).pipe(catchError(this.handlerError));
      } else {
        return this.httpClient.post(`${this.urlApi}`, contactPhone).pipe(catchError(this.handlerError));
      }
    }
  }

  delete (contact : ContactPhone): Observable<any>{

    return this.httpClient
      .delete(`${this.urlApi}/${contact.contactPhoneId}`)
  } 

  validate(contactPhone : ContactPhone) : Boolean{

    if(contactPhone.number === "" || contactPhone.contactTypeId === 0 || contactPhone.contactTypeId === undefined) {

      this.serviceMessage.send(500,"Informe corretamente os dados do telefone!");

      return false;

    } else {

      return true;
    }

  }

  private handlerError(httpError : HttpErrorResponse) {   
       
      return new ErrorObservable({code : httpError.status, message : `${httpError.status}-${httpError.error}` }   );   
  }

}
