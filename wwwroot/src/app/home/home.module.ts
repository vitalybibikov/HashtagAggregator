import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { CommonModule } from "@angular/common";
import { MessagesListComponent } from './messages-list';
import { MessageComponent } from './messages-list/message/message.component';
import { HomeComponent } from './home.component';

import { BrowserModule } from '@angular/platform-browser';
import { LazyLoadImageModule } from 'ng-lazyload-image';

@NgModule({
    declarations: [
        HomeComponent,
        MessageComponent,
        MessagesListComponent
    ],
    imports: [
        CommonModule,
        BrowserModule,
        LazyLoadImageModule
    ],
    providers: [
    ]
})
export class HomeModule {
}
