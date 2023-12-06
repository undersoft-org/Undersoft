import { Personal } from "./personal";
import { Detail } from "./detail";
import { AccountIdentity } from "@/account/accountIdentity";
import { Model } from "@/models/model";
import { UserIdentifier } from "./userIdentifier";

export interface Servicer extends Model {
    Email?: string;
    UserName?: string;
    FullName?: string;
    Group?: string;
    Contact?: any;
    Details?: Detail[];
    Identifiers?: UserIdentifier[];
    Identity?: AccountIdentity;
    Comapny?: Personal;
}
