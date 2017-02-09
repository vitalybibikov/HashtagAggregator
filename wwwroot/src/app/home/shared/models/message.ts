import { MediaType } from '../enums/social-media.enum'
import {User} from "./user";

export class Message {
    id : number;
    networkId : string;
    body : string;
    hashTag : string;
    mediaType : number;
    postDate : Date;
    user : User;
}
