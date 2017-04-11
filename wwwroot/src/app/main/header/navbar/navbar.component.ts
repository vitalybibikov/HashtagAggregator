import {
  Component,
  ViewEncapsulation, OnInit, EventEmitter, Output, OnDestroy
} from '@angular/core';

import {AppConfigService} from "../../shared/services/config/app-config.service";
import {FormControl} from "@angular/forms";
import {SearchService} from "../../shared/services/search.service";
import {Subscription} from "rxjs";

@Component({
  selector: 'site-nav',
  styleUrls: ['navbar.component.scss'],
  encapsulation: ViewEncapsulation.None,
  templateUrl: 'navbar.component.html'
})

export class NavbarComponent implements OnDestroy, OnInit {

  private searchBoxControl = new FormControl();
  private subscription: Subscription;

  constructor(private configService: AppConfigService, private searchService: SearchService) {

  }

  public ngOnInit(): void {
    this.subscription =
      this.searchBoxControl.valueChanges
        .debounceTime(400)
        .distinctUntilChanged()
        .subscribe(text => this.searchService.confirmSearch(text));
  }

  public ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}

