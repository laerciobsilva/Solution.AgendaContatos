import { ContactType } from './../model/contact-type.model';
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { MessageOperationService } from './message-operation.service';
import { Observable } from 'rxjs/Observable';
import { ErrorObservable } from 'rxjs/observable/ErrorObservable';

@Injectable()
export class ContactTypeService {

  
  urlApi = "/api/ContactType/"
  
  constructor(private httpClient: HttpClient, private serviceMessage : MessageOperationService) { 

  }

  list() : Observable<ContactType[]>{

    return this.httpClient.get<ContactType[]>(`${this.urlApi}/list`);      
  }

  private handlerError(httpError : HttpErrorResponse) {   
       
      return new ErrorObservable({code : httpError.status, message : `${httpError.status}-${httpError.error}` }   );   
  }

}
