import { OpaqueToken } from "@angular/core";

/**
 * App configuration
 */
export const APP_CONFIG_TOKEN = new OpaqueToken("app.config");
export const VK_CONFIG_TOKEN = new OpaqueToken("vk.config");
export const TWITTER_CONFIG_TOKEN = new OpaqueToken("twitter.config");

export interface AppConfig {
    i18nPath: string;
    apiEndpoint: string;
    loginApiEndpoint: string;
    i18nResourceFileFormat: string;
}

export interface VkConfig {
   vkMessageUri : string;
   hashtag: string
}

export interface TwitterConfig {
  twitterMessageUri: string;
  hashtag: string
}

export const CONFIG: AppConfig = {
    i18nPath: "/assets/i18n",
    apiEndpoint: "",
    loginApiEndpoint: "",
    i18nResourceFileFormat: ".json"
};

export const VK_CONFIG: VkConfig = {
  vkMessageUri : "https://vk.com/{user}?w=wall{userId}_{networkId}%2Fall",
  hashtag: "somesmallmessagefortest"
};

export const TWITTER_CONFIG: TwitterConfig = {
  twitterMessageUri : "https://twitter.com/{user}/status/{networkId}",
  hashtag: "somesmallmessagefortest"
};


if ("production" === ENV) {
    CONFIG.apiEndpoint = `${location.origin}/api`;
    CONFIG.loginApiEndpoint = "http://localhost:5001/";
} else {
    CONFIG.apiEndpoint = "http://localhost:5005/api/";
    CONFIG.loginApiEndpoint = "http://localhost:5001/";
}
