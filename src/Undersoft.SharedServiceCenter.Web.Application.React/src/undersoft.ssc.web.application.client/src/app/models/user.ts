import { Personal } from "./personal";
import { Detail } from "./detail";
import { AccountIdentity } from "@/models/accountIdentity";
import { Model } from "@/models/model";
import { UserIdentifier } from "./userIdentifier";

export interface User extends Model {
    Group?: string;
    Active: boolean;
    Locked: boolean;
    Contact?: any;
    Details?: Detail[];
    Identifiers?: UserIdentifier[];
    Identity?: AccountIdentity;
    Personal?: Personal;
    IsAuthorized: boolean;
}
