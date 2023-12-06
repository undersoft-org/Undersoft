import { AccountIdentityClaim } from "./accountIdentityClaim";
import { AccountIdentityRole } from "./accountIdentityRole";
import { IdentityUser } from "./identityUser";
import { AccountIdentityCredentials } from "./accountIdentityCredentials";
import { Model } from "@/models/model";

export interface AccountIdentity extends Model {
    Info?: IdentityUser;  
    Roles?: AccountIdentityRole;
    Claims?: AccountIdentityClaim;
    Credentials?: AccountIdentityCredentials;
}





