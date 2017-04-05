import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { HomeModule } from './home/home.module';
import { SharedModule } from "./shared/shared.module";
import {
  NgModule,
  ApplicationRef
} from '@angular/core';
import {
  removeNgStyles,
  createNewHosts,
  createInputTransfer
} from '@angularclass/hmr';
import {
  RouterModule,
  PreloadAllModules
} from '@angular/router';


import { ENV_PROVIDERS } from '../platform/environment';
import { PROVIDERS } from "../platform/providers";
import { APP_ROUTES } from './app.routes';

import { AppComponent } from './app.component';
import { APP_RESOLVER_PROVIDERS } from './app.resolver';
import { AppState, InternalStateType } from './app.service';
import { NoContentComponent } from './no-content';

import '../styles/styles.scss';
import '../styles/headings.css';
import {AuthModule} from "./shared/auth.module";
import {StorageService} from "./shared/services/storage.service";
import { HttpModule, Http } from "@angular/http";

import {TranslateModule, TranslateLoader} from '@ngx-translate/core'
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import {LoginModule} from "./login/login.module";
import {AppConfigService} from "./shared/services/config/app-config.service";

export function HttpLoaderFactory(http: Http) {
  return new TranslateHttpLoader(http);
}

type StoreType = {
  state: InternalStateType,
  restoreInputValues: () => void,
  disposeOldHosts: () => void
};


@NgModule({
  bootstrap: [AppComponent],
  declarations: [
    AppComponent,
    NoContentComponent
  ],
  imports: [
    HomeModule,
    LoginModule,
    BrowserModule,
    FormsModule,
    HttpModule,
    SharedModule,
    AuthModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [Http]
      }
    }),

    RouterModule.forRoot(APP_ROUTES, { useHash: false, preloadingStrategy: PreloadAllModules })
  ],
  providers: [
    ...PROVIDERS,
    ...ENV_PROVIDERS,
    APP_RESOLVER_PROVIDERS,
    AppState,
    AppConfigService,
    StorageService
  ]
})

export class AppModule {

  constructor(
    public appRef: ApplicationRef,
    public appState: AppState
  ) { }

  public hmrOnInit(store: StoreType) {
    if (!store || !store.state) {
      return;
    }
    console.log('HMR store', JSON.stringify(store, null, 2));
    // set state
    this.appState._state = store.state;
    // set input values
    if ('restoreInputValues' in store) {
      let restoreInputValues = store.restoreInputValues;
      setTimeout(restoreInputValues);
    }

    this.appRef.tick();
    delete store.state;
    delete store.restoreInputValues;
  }

  public hmrOnDestroy(store: StoreType) {
    const cmpLocation = this.appRef.components.map((cmp) => cmp.location.nativeElement);
    // save state
    const state = this.appState._state;
    store.state = state;
    // recreate root elements
    store.disposeOldHosts = createNewHosts(cmpLocation);
    // save input values
    store.restoreInputValues = createInputTransfer();
    // remove styles
    removeNgStyles();
  }

  public hmrAfterDestroy(store: StoreType) {
    // display new elements
    store.disposeOldHosts();
    delete store.disposeOldHosts;
  }
}
