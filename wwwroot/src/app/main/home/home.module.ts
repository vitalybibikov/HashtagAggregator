import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { MessagesListComponent } from './messages-list';
import { MessageComponent } from './messages-list/message/message.component';
import { HomeComponent } from './home.component';
import { LazyLoadImageModule } from 'ng-lazyload-image';

@NgModule({
    declarations: [
        HomeComponent,
        MessageComponent,
        MessagesListComponent
    ],
    imports: [
        CommonModule,
        LazyLoadImageModule
    ],
    providers: [
    ]
})
export class HomeModule {
}
