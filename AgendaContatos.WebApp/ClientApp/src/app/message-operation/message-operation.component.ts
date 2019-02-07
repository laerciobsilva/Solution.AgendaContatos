import { Component, OnInit } from '@angular/core';
import { MessageOperationService } from '../services/message-operation.service';

@Component({
  selector: 'app-message-operation',
  templateUrl: './message-operation.component.html',
  styleUrls: ['./message-operation.component.css']
})
export class MessageOperationComponent implements OnInit {

  message: string;
  isSuccess: boolean;
  isError: boolean;
  isVisible: boolean;

  constructor(private messageService: MessageOperationService) {
  }

  ngOnInit() {

    this.isError = false;

    this.messageService.sendMessage.subscribe(data => {

      this.message = data.message;
      this.isSuccess = data.isSuccess;
      this.isError = true;
      this.isVisible = true;

      setTimeout(() => {
        this.isVisible = false,
        this.isError = true;
        this.isSuccess = false;
      }, 5000)

    });



  }

  hasError(): boolean {

    return !this.isSuccess && this.isError;
  }

}
