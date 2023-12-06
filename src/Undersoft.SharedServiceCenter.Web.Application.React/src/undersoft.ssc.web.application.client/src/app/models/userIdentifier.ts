import { Model } from "@/models/model";
import { User } from "./user";


export interface UserIdentifier extends Model {
    Entity?: User;
    EntityId?: number;
    IdKind?: string;
    Name?: string;
    Value?: string;
}

