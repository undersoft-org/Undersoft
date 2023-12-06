import { Model } from "@/models/model";

export interface AccountIdentityRoleClaim extends Model {
    RoleId?: number;
    ClaimType?: string;
    ClaimValue?: string;
}
