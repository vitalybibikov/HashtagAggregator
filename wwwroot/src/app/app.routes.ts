import { Routes } from '@angular/router';
import { HomeComponent } from './home';
import {LoginCallbackComponent} from "./login/login-callback/login-callback.component";
import {NotFoundComponent} from "./no-content/not-found.component";

export const APP_ROUTES: Routes = [
  { path: '',  component: HomeComponent },
  { path: 'home', redirectTo: '',  component: HomeComponent, },
  { path: 'login-callback', component: LoginCallbackComponent },
  { path: '**',    component: NotFoundComponent },
];
