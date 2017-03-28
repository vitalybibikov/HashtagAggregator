import { Injectable, Inject } from "@angular/core";
import {
  APP_CONFIG_TOKEN, AppConfig,
  VK_CONFIG_TOKEN, VkConfig,
  TWITTER_CONFIG_TOKEN, TwitterConfig
} from "../../../../platform/configuration";

@Injectable()
export class AppConfigService {

  constructor(@Inject(APP_CONFIG_TOKEN) private config: AppConfig,
              @Inject(VK_CONFIG_TOKEN) private vkConfig: VkConfig,
              @Inject(TWITTER_CONFIG_TOKEN) private twiConfig: TwitterConfig){
  }

  public getApp<T>(key: string): T {
    return <T>this.config[key];
  }

  public getVk<T>(key: string): T {
    return <T>this.vkConfig[key];
  }

  public getTwitter<T>(key: string): T {
    return <T>this.twiConfig[key];
  }
}
