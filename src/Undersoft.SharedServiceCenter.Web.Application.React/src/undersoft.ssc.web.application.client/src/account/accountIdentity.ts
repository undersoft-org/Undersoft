import { AccountIdentityClaim } from "./accountIdentityClaim";
import { AccountIdentityRole } from "./accountIdentityRole";
import { IdentityUser } from "./identity/identityUser";
import { Credentials } from "./identity/credentials";
import { Model } from "@/models/model";

export interface AccountIdentity extends Model {
    Info?: IdentityUser;  
    Roles?: AccountIdentityRole;
    Claims?: AccountIdentityClaim;
    Credentials?: Credentials;
}





