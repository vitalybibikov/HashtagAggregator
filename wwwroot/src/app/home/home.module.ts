import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { CommonModule } from "@angular/common";

// import { SharedAppModule } from "../shared/shared.module";
import { MessagesListComponent } from './messages-list';
import { HomeComponent } from './home.component';
// import { AgentResolver } from "./shared/resolver/agent-resolver";

@NgModule({
    declarations: [
        HomeComponent,
        MessagesListComponent
    ],
    imports: [
        CommonModule
    ],
    providers: [
       // AgentResolver
    ]
})
export class HomeModule {
}
