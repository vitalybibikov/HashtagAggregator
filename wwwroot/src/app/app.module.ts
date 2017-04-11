import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

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

import { AppState, InternalStateType } from './app.service';


import { HttpModule, Http } from "@angular/http";

import {TranslateModule, TranslateLoader, TranslatePipe} from '@ngx-translate/core'
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

import {NotFoundComponent} from "./no-content/not-found.component";
import {MainModule} from "./main/main.module";

import '../styles/styles.scss';
import '../styles/headings.css';

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
    NotFoundComponent
  ],
  imports: [
    MainModule,
    BrowserModule,
    FormsModule,
    HttpModule,
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
    AppState
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
