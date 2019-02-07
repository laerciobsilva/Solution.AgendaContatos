import { Injectable, EventEmitter } from '@angular/core';

@Injectable()
export class MessageOperationService {
  
  public sendMessage : EventEmitter<any> = new EventEmitter<any>();  

  constructor() {}

  public send( httpCode : number ,message : string ){     
    
    this.sendMessage.emit({
      code : httpCode, 
      message : message,
      isSuccess : httpCode == 200
    });
    
  }
}
