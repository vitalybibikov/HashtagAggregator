import {
  Component,
  ViewEncapsulation, OnInit
} from '@angular/core';

import {TranslateService} from '@ngx-translate/core';
import {AppConfigService} from "./shared/services/config/app-config.service";
import {SearchService} from "./shared/services/search.service";

@Component({
  selector: 'main-page',
  encapsulation: ViewEncapsulation.None,
  styleUrls: ['main.component.scss'],
  templateUrl: 'main.component.html',
  providers: [TranslateService, SearchService]
})

export class MainComponent {

  constructor(private configService: AppConfigService) {

  }
}

