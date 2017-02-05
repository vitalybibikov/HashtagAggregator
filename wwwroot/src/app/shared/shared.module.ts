import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
    TranslateModule,
    TranslateLoader,
    TranslateStaticLoader
} from "ng2-translate";
import { HttpModule, Http } from "@angular/http";

@NgModule({
    imports: [CommonModule,
        TranslateModule.forRoot({
            provide: TranslateLoader,
            useFactory: (http: Http) => new TranslateStaticLoader(http, '../../assets/i18n', '.json'),
            deps: [Http]
        })],
    declarations: [],
    exports: [TranslateModule, CommonModule]
})
export class SharedModule { 

}