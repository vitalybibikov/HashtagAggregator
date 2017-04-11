import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import {HomeModule} from "./home/home.module";
import {LoginModule} from "./login/login.module";
import {MainComponent} from "./main.component";
import {SharedModule} from "./shared/shared.module";
import {AuthModule} from "./shared/auth.module";
import {StorageService} from "./shared/services/storage.service";
import {AppConfigService} from "./shared/services/config/app-config.service";
import {TranslateModule} from "@ngx-translate/core";
import {RouterModule} from '@angular/router';
import {CollapseModule} from "ngx-bootstrap";

import {NavbarComponent, HeaderComponent} from "./header";

@NgModule({
  declarations: [
    MainComponent,
    NavbarComponent,
    HeaderComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    AuthModule,
    LoginModule,
    HomeModule,
    TranslateModule,
    RouterModule,
    CollapseModule
  ],
  providers:[
    AppConfigService,
    StorageService
  ]
})

export class MainModule {

}
