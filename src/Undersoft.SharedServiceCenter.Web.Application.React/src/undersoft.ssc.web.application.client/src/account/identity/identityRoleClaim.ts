import { Model } from "@/models/model";

export interface IdentityRoleClaim extends Model {

    RoleId?: number;
    ClaimType?: string;
    ClaimValue?: string;

}
