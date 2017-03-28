import {
  Component,
  OnInit,
  ViewEncapsulation
} from '@angular/core';

import { TranslateService } from '@ngx-translate/core';
import { AppState } from './app.service';
import {Http, RequestOptionsArgs, Headers} from "@angular/http";
import {AuthHttp} from "angular2-jwt";
import {AppConfigService} from "./shared/services/config/app-config.service";

@Component({
  selector: 'app',
  encapsulation: ViewEncapsulation.None,
  styleUrls: ['app.component.scss'],
  templateUrl: 'app.component.html',
  providers: [TranslateService]
})
export class AppComponent implements OnInit {
  constructor(
    private appState: AppState,
    private translate: TranslateService,
    private authHttp: AuthHttp,
    private configService: AppConfigService) {
      translate.setDefaultLang('en');
      translate.use('en');
  }

  public ngOnInit() {
  }

  public makeAuthCall(){
    let apiUri: string = this.configService.getApp<string>("apiEndpoint");
    let link: string = "identity";
    this.authHttp.get(`apiUri ${link}`).subscribe(
      data => console.log(data),
      err => console.log(err),
       () => console.log('Request Complete')
    );
  }
}

