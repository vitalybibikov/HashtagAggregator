import { Routes } from '@angular/router';
import { HomeComponent } from './home';
import { NoContentComponent } from './no-content';
import {LoginCallbackComponent} from "./login/login-callback/login-callback.component";

export const APP_ROUTES: Routes = [
  { path: '',  component: HomeComponent },
  { path: 'home', redirectTo: '',  component: HomeComponent },
  { path: 'login-callback', component: LoginCallbackComponent },
  { path: '**',    component: NoContentComponent },
];
