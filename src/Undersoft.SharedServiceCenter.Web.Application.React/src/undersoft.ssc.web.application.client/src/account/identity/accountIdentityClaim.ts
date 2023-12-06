import { IdentityUserClaim } from "./identityUserClaim";
import { Model } from "@/models/model";

export interface AccountIdentityClaim extends Model {

    Info?: IdentityUserClaim;
}
