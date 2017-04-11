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

import {NavbarComponent, HeaderComponent} from "./header";
import {Collapse} from "./header/navbar/navbar-collapse.directive";
import {Ng2FilterPipeModule} from "ng2-filter-pipe";
import { ReactiveFormsModule , FormsModule } from "@angular/forms";

@NgModule({
  declarations: [
    MainComponent,
    NavbarComponent,
    HeaderComponent,
    Collapse
  ],
  imports: [
    CommonModule,
    SharedModule,
    AuthModule,
    LoginModule,
    HomeModule,
    TranslateModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule
  ],
  providers:[
    AppConfigService,
    StorageService
  ]
})

export class MainModule {

}
