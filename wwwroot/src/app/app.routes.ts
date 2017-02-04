import { Routes } from '@angular/router';
import { HomeComponent } from './home';
import { NoContentComponent } from './no-content';

import { DataResolver } from './app.resolver';

export const APP_ROUTES: Routes = [
  { path: '',      component: HomeComponent },
  { path: 'home',  component: HomeComponent },
  { path: '**',    component: NoContentComponent },
];
