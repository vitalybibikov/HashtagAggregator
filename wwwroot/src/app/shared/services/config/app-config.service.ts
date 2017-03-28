import { Injectable, Inject } from "@angular/core";
import {APP_CONFIG_TOKEN, AppConfig} from "../../../../platform/configuration";

@Injectable()
export class AppConfigService {

  constructor(@Inject(APP_CONFIG_TOKEN) private config: AppConfig) {
  }

  public get<T>(key: string): T {
    return <T>this.config[key];
  }
}
