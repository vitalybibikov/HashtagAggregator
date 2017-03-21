import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
    TranslateModule,
    TranslateLoader,
    TranslateStaticLoader
} from "ng2-translate";
import { HttpModule, Http } from "@angular/http";
import {ExternalButtonComponent} from "./external-login/external-button/external-button.component";
import {ExternalLoginButtonsComponent} from "./external-login/external-login-buttons.component";

@NgModule({
    imports: [CommonModule,
        TranslateModule.forRoot({
            provide: TranslateLoader,
            useFactory: (http: Http) => new TranslateStaticLoader(http, '../../assets/i18n', '.json'),
            deps: [Http]
        })
    ],
    declarations: [ ExternalLoginButtonsComponent, ExternalButtonComponent],
    exports: [TranslateModule, CommonModule, ExternalLoginButtonsComponent]
})
export class SharedModule {

}
