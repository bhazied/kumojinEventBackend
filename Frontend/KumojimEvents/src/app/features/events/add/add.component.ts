import { Component, OnInit, OnDestroy, inject} from '@angular/core';
import { NgFor, NgIf, NgClass } from '@angular/common';
import { Subject, takeUntil } from 'rxjs';

import { MatFormField, MatLabel, MatSuffix } from '@angular/material/form-field';
import {
  FormBuilder,
  ReactiveFormsModule,
  FormGroup,
  FormControl,
  Validators,
  AbstractControl,
  UntypedFormControl,
} from '@angular/forms';
import { MatSlider, MatSliderThumb } from '@angular/material/slider';
import { provideMomentDatetimeAdapter } from '@ng-matero/extensions-moment-adapter';
import {
  MtxCalendarView,
  MtxDatetimepicker,
  MtxDatetimepickerInput,
  MtxDatetimepickerMode,
  MtxDatetimepickerToggle,
  MtxDatetimepickerType,
} from '@ng-matero/extensions/datetimepicker';

import timezones from '../../data/timezones.json';
import { EventDto } from '../Common/models/EventDto';
import { EventService } from '../Common/services/event.service';

@Component({
  selector: 'event-add',
  standalone: true,
  providers: [
    EventService,
    provideMomentDatetimeAdapter({
      parse: {
        dateInput: 'YYYY-MM-DD',
        monthInput: 'MMMM',
        yearInput: 'YYYY',
        timeInput: 'HH:mm',
        datetimeInput: 'YYYY-MM-DD HH:mm',
      },
      display: {
        dateInput: 'YYYY-MM-DD',
        monthInput: 'MMMM',
        yearInput: 'YYYY',
        timeInput: 'HH:mm',
        datetimeInput: 'YYYY-MM-DD HH:mm',
        monthYearLabel: 'YYYY MMMM',
        dateA11yLabel: 'LL',
        monthYearA11yLabel: 'MMMM YYYY',
        popupHeaderDateLabel: 'MMM DD, ddd',
      },
    }),
  ],
  imports: [
    NgFor, 
    NgIf, 
    ReactiveFormsModule, 
    NgClass,
    MtxDatetimepicker,
    MtxDatetimepickerInput,
    MtxDatetimepickerToggle,
    MatFormField,
  ],
  templateUrl: './add.component.html',
  styleUrl: './add.component.css',
})
export class AddComponent implements OnInit, OnDestroy {
  private destroy$ = new Subject();
  public success: boolean = false;

  type: MtxDatetimepickerType = 'datetime';
  mode: MtxDatetimepickerMode = 'auto';
  startView: MtxCalendarView = 'month';
  multiYearSelector = false;
  touchUi = false;
  twelvehour = false;
  timeInterval = 1;
  timeInput = true;

  datetime = new UntypedFormControl();
  public service: EventService = inject(EventService);
  private formBuilder: FormBuilder = inject(FormBuilder);
  public timezonesList: { zone: string; utc: string; name: string }[] =
    timezones;
  submitted: boolean = false;
  eventForm: FormGroup = new FormGroup({
    Name: new FormControl(''),
    Description: new FormControl(''),
    Program: new FormControl(''),
    Location: new FormControl(''),
    TimeZone: new FormControl(''),
    StartDate: new FormControl(''),
    EndDate: new FormControl(''),
  });
  ngOnInit(): void {
    this.eventForm = this.formBuilder.group({
      Name: ['', [Validators.required, Validators.maxLength(32)]],
      Description: ['', [Validators.required]],
      Program: ['', [Validators.required]],
      Location: ['', [Validators.required]],
      TimeZone: ['', [Validators.required]],
      StartDate: ['', [Validators.required]],
      EndDate: ['', [Validators.required]],
    });
  }

  get f(): { [key: string]: AbstractControl } {
    return this.eventForm.controls;
  }
  event = new EventDto();

  onSubmit() {
    this.submitted = true;
    if (this.eventForm.invalid) {
      return;
    }
    this.event = { ...this.event, ...this.eventForm.value };
    this.service
      .AddEvent(this.event)
      .pipe(takeUntil(this.destroy$))
      .subscribe(
        (response) => {
          this.success = response.succeeded;
        },
        (error) => {
          this.success = false;
        }
      );
    console.log(JSON.stringify(this.event, null, 2));
  }

  onReset() {
    this.submitted = false;
    this.eventForm.reset();
  }

  ngOnDestroy(): void {
    this.destroy$.next(null);
    this.destroy$.unsubscribe();
  }
}
