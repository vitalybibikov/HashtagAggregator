import { Routes } from '@angular/router';
import {LoginCallbackComponent} from "./main/login/login-callback/login-callback.component";
import {NotFoundComponent} from "./no-content/not-found.component";
import {MainComponent} from "./main/main.component";
import {HomeComponent} from "./main/home/home.component";

export const APP_ROUTES: Routes = [
  { path: '',  component: MainComponent,
    children: [
        { path: '', component: HomeComponent }
      ]
  },
  { path: 'main', redirectTo: '',  component: MainComponent, },
  { path: 'login-callback', component: LoginCallbackComponent },
  { path: '**',    component: NotFoundComponent },
];
