import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: '', redirectTo: '/', pathMatch: 'full' },
  {
    path: 'events',
    loadChildren: () =>
      import('./features/events/routes').then((module) => module.EVENT_ROUTES),
  },
];
