import { Route } from '@angular/router';

import { AddComponent } from './add/add.component';
import { ListComponent } from './list/list.component';
import {EventService} from './Common/services/event.service'
export const EVENT_ROUTES: Route[] = [
  {
    path: '',
    pathMatch: 'prefix',
    providers: [
      EventService
    ],
    children: [
      { path: 'add', component: AddComponent },
      { path: 'list', component: ListComponent },
    ],
  },
];
