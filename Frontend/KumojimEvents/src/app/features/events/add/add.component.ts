import { Component, OnInit, OnDestroy } from '@angular/core';
import { NgFor, NgIf, NgClass } from '@angular/common';
import { Subject, takeUntil } from 'rxjs';

import {
  FormBuilder,
  ReactiveFormsModule,
  FormGroup,
  FormControl,
  Validators,
  AbstractControl,
} from '@angular/forms';

import timezones from '../../data/timezones.json';
import { EventDto } from '../Common/models/EventDto';
import { EventService } from '../Common/services/event.service';

@Component({
  selector: 'event-add',
  standalone: true,
  providers: [EventService],
  imports: [NgFor, NgIf, ReactiveFormsModule, NgClass],
  templateUrl: './add.component.html',
  styleUrl: './add.component.css',
})
export class AddComponent implements OnInit, OnDestroy {
  private destroy$ = new Subject();
  public success: boolean = false;
  constructor(
    private formBuilder: FormBuilder,
    private service: EventService
  ) {}
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
