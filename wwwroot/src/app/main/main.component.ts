import {
  Component,
  ViewEncapsulation
} from '@angular/core';

import { TranslateService } from '@ngx-translate/core';
import {AuthHttp} from "angular2-jwt";
import {AppConfigService} from "./shared/services/config/app-config.service";

@Component({
  selector: 'main-page',
  styleUrls: ['main.component.scss'],
  templateUrl: 'main.component.html',
  providers: [TranslateService]
})

export class MainComponent{

  constructor(
    private authHttp: AuthHttp,
    private configService: AppConfigService) {
  }
}

