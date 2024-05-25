import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';

import { EventDto } from '../Common/models/EventDto';
import { EventService } from '../Common/services/event.service';

@Component({
  selector: 'event-list',
  standalone: true,
  imports: [],
  providers: [EventService],
  templateUrl: './list.component.html',
  styleUrl: './list.component.css',
})
export class ListComponent implements OnInit, OnDestroy {
  private destroy$ = new Subject();
  constructor(public service: EventService) {}

  ngOnInit(): void {
    this.service
      .GetAllEvent()
      .pipe(takeUntil(this.destroy$))
      .subscribe((response: any) => {
        if (response.succeeded) {
          this.eventList = response.data;
        }
      });
  }

  ngOnDestroy(): void {
    this.destroy$.next(null);
    this.destroy$.unsubscribe();
  }
  public eventList: EventDto[] = [];
}
