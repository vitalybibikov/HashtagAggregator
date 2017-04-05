import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
    TranslateModule,
    TranslateLoader,
    TranslateStaticLoader
} from "ng2-translate";

import {ExternalButtonComponent} from "./login/external-login-buttons/external-button/external-button.component";
import {ExternalLoginButtonsComponent} from "./login/external-login-buttons/external-login-buttons.component";
import {LoginedUserComponent} from "./login/logined-user/logined-user";
import {AuthSectionComponent} from "./login/auth-section";
import {JwtHelper} from "angular2-jwt";
import {AuthService} from "./services/auth.service";

@NgModule({
    imports: [CommonModule],
    declarations: [
      ExternalLoginButtonsComponent,
      ExternalButtonComponent,
      LoginedUserComponent,
      AuthSectionComponent
    ],
    exports: [CommonModule, AuthSectionComponent],
    providers: [JwtHelper , AuthService]
})
export class SharedModule {

}
