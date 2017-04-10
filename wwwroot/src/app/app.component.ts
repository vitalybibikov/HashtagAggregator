import {
  Component,
  ViewEncapsulation
} from '@angular/core';

import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app',
  encapsulation: ViewEncapsulation.None,
  templateUrl: 'app.component.html',
  providers: [TranslateService]
})

export class AppComponent{
  constructor(private translate: TranslateService) {
      translate.setDefaultLang('en');
      translate.use('en');
  }
}

