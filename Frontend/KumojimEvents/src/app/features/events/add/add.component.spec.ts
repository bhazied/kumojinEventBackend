import { ComponentFixture, TestBed } from '@angular/core/testing';
import { provideHttpClient } from '@angular/common/http';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import {
  FormsModule,
  FormBuilder,
  ReactiveFormsModule,
  FormGroup,
  FormControl,
  Validators,
  AbstractControl,
  UntypedFormControl,
} from '@angular/forms';

import { AddComponent } from './add.component';
import { EventService } from '../Common/services/event.service';
import { EventMockService } from '../Common/Mocks/event.service.mock';

describe('AddComponent', () => {
  let component: AddComponent;
  let fixture: ComponentFixture<AddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddComponent, ReactiveFormsModule, FormsModule],
      providers: [
        { provide: EventService, useClass: EventMockService },
        provideHttpClient(),
        provideAnimationsAsync(),
      ],
    }).compileComponents();

    fixture = TestBed.createComponent(AddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('Test input Element count', () => {
    const compiled = fixture.nativeElement as HTMLElement;
    const formElement = compiled.querySelector('form');
    fixture.detectChanges();
    const inputs = formElement?.querySelectorAll('input');
     const textarea = formElement?.querySelectorAll('textarea');
     const select =   formElement?.querySelectorAll('select');
     const countElements = inputs!.length  + textarea!.length + select!.length;
     expect(countElements).toEqual(7);

    console.log(inputs);
  });

  it('Should have error when name longer than 32 carac', () => {
    let fakeName: string =
      'im an event name, and im very very very very very long more than 32 caracters';
    component.eventForm.controls['Name'].setValue(fakeName);
    const compiled = fixture.nativeElement as HTMLElement;
    component.onSubmit();
    fixture.detectChanges();
    expect(component.submitted).toEqual(true);
    expect(component.eventForm.controls['Name'].errors?.maxlength).toBeTruthy();

  });
});
