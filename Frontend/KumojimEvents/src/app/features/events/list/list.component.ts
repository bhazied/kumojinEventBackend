import {
  Component,
  OnDestroy,
  OnInit,
  TemplateRef,
  ViewChild,
  inject,
} from '@angular/core';
import { DatePipe } from '@angular/common';
import { Subject, takeUntil } from 'rxjs';
import { MtxGrid, MtxGridColumn } from '@ng-matero/extensions/grid';

import { EventDto } from '../Common/models/EventDto';
import { EventService } from '../Common/services/event.service';

@Component({
  selector: 'event-list',
  standalone: true,
  imports: [MtxGrid, DatePipe],
  providers: [EventService],
  templateUrl: './list.component.html',
  styleUrl: './list.component.css',
})
export class ListComponent implements OnInit, OnDestroy {
  private destroy$ = new Subject();
  public eventList: EventDto[] = [];
  public locale!: string;
  @ViewChild('sdTpl', { static: true }) sdTpl!: TemplateRef<any>;
  @ViewChild('edTpl', { static: true }) edTpl!: TemplateRef<any>;
  public service: EventService = inject(EventService);
  columns: MtxGridColumn[] = [
    { header: 'Name', field: 'name', showExpand: true },
    { header: 'Description', field: 'description', sortable: true },
    { header: 'Location', field: 'location', sortable: true },
    { header: 'Program', field: 'program', sortable: true },
    {
      header: 'Start date',
      field: 'startDate',
      sortable: true,
      cellTemplate: this.sdTpl,
    },
    {
      header: 'End date',
      field: 'endDate',
      sortable: true,
      cellTemplate: this.edTpl,
    },
    { header: 'Timezone', field: 'timeZone', sortable: true },
  ];
  ngOnInit(): void {
    this.service
      .GetAllEvent()
      .pipe(takeUntil(this.destroy$))
      .subscribe((response: any) => {
        if (response.succeeded) {
          this.eventList = response.data;
        }
      });

    this.locale = this.getUsersLocale('fr-ca');
  }
  getUsersLocale(defaultValue: string): string {
    if (
      typeof window === 'undefined' ||
      typeof window.navigator === 'undefined'
    ) {
      return defaultValue;
    }
    const wn = window.navigator as any;
    let lang = wn.languages ? wn.languages[0] : defaultValue;
    lang = lang || wn.language || wn.browserLanguage || wn.userLanguage;
    return lang;
  }
  log(e: any) {
    console.log(e);
  }
  ngOnDestroy(): void {
    this.destroy$.next(null);
    this.destroy$.unsubscribe();
  }
}
