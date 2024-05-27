import { Component } from '@angular/core';
import {RouterOutlet, RouterLink, RouterLinkActive } from '@angular/router';
import { CoreModule } from './core/core.module';
import {MatIconModule} from '@angular/material/icon';
import {MatDividerModule} from '@angular/material/divider';
import {MatButtonModule} from '@angular/material/button';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CoreModule, RouterLink, RouterLinkActive,MatButtonModule, MatDividerModule, MatIconModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'KumojimEvents';
}
