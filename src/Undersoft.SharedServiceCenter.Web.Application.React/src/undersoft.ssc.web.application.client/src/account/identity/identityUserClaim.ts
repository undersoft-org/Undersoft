import { Model } from "@/models/model";

export interface IdentityUserClaim extends Model {

    UserId?: number;
    ClaimType?: string;
    ClaimValue?: string;
}
