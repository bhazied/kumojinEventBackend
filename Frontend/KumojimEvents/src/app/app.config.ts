import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';

import { CoreModule } from './core/core.module';
import { routes } from './app.routes';

export const appConfig: ApplicationConfig = {
  providers: [provideRouter(routes)],
};
