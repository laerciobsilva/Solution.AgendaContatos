import { ContactMail } from './../model/contact-mail.model';
import { Injectable } from '@angular/core';
import { MessageOperationService } from './message-operation.service';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { ErrorObservable } from 'rxjs/observable/ErrorObservable';

@Injectable()
export class ContactMailService {

  urlApi = "/api/Mail/"
  
  constructor(private httpClient: HttpClient, private serviceMessage : MessageOperationService) { 

  }

  list() : Observable<ContactMail[]>{

    return this.httpClient.get<ContactMail[]>(`${this.urlApi}/list`);      
  }

  get(id : number) : Observable<ContactMail>{

    return this.httpClient.get<ContactMail>(`${this.urlApi}${id}`);
  }

  post (contactMail : ContactMail): Observable<any>{

    if (this.validate(contactMail)) {
      
      if (contactMail.contactMailId > 0) {

        return this.httpClient.put(`${this.urlApi}`, contactMail).pipe(catchError(this.handlerError));
      } else {
        return this.httpClient.post(`${this.urlApi}`, contactMail).pipe(catchError(this.handlerError));
      }
    }
  }

  delete (contactMail : ContactMail): Observable<any>{

    return this.httpClient
      .delete(`${this.urlApi}/${contactMail.contactMailId}`)
  } 

  validate(contactMail : ContactMail) : Boolean{

    if(contactMail.address === "" || contactMail.contactTypeId === 0 || contactMail.contactTypeId === undefined) {

      this.serviceMessage.send(500,"Informe corretamente os dados do e-mail!");

      return false;

    } else {

      return true;
    }

  }

  private handlerError(httpError : HttpErrorResponse) {   
       
      return new ErrorObservable({code : httpError.status, message : `${httpError.status}-${httpError.error}` }   );   
  }
}
