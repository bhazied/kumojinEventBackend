import { Component } from '@angular/core';
import {RouterOutlet, RouterLink, RouterLinkActive } from '@angular/router';
import { CoreModule } from './core/core.module';

import { environment } from '../environments/environment';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CoreModule, RouterLink, RouterLinkActive],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'KumojimEvents';
  BASE_URL = environment.BASE_URL;
}
