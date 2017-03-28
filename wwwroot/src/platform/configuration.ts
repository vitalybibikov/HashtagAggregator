import {OpaqueToken, InjectionToken} from "@angular/core";

/**
 * App configuration
 */
export const APP_CONFIG_TOKEN = new InjectionToken("app.config");
export const VK_CONFIG_TOKEN = new InjectionToken("vk.config");
export const TWITTER_CONFIG_TOKEN = new InjectionToken("twitter.config");

export interface AppConfig {
    i18nPath: string;
    apiEndpoint: string;
    loginApiEndpoint: string;
    i18nResourceFileFormat: string;
    hashtag: string;
}

export interface VkConfig {
   vkMessageUri : string;
}

export interface TwitterConfig {
  twitterMessageUri: string;
}

export const CONFIG: AppConfig = {
    i18nPath: "/assets/i18n",
    apiEndpoint: "",
    loginApiEndpoint: "",
    i18nResourceFileFormat: ".json",
  hashtag: "somesmallmessagefortest"
};

export const VK_CONFIG: VkConfig = {
  vkMessageUri : "https://vk.com/{user}?w=wall{userId}_{networkId}%2Fall",
};

export const TWITTER_CONFIG: TwitterConfig = {
  twitterMessageUri : "https://twitter.com/{user}/status/{networkId}",
};


if ("production" === ENV) {
    CONFIG.apiEndpoint = `${location.origin}/api`;
    CONFIG.loginApiEndpoint = "http://localhost:5001/";
} else {
    CONFIG.apiEndpoint = "http://localhost:5005/api/";
    CONFIG.loginApiEndpoint = "http://localhost:5001/";
}
