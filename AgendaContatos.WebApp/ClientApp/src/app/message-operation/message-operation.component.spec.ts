import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MessageOperationComponent } from './message-operation.component';

describe('MessageOperationComponent', () => {
  let component: MessageOperationComponent;
  let fixture: ComponentFixture<MessageOperationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MessageOperationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MessageOperationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
