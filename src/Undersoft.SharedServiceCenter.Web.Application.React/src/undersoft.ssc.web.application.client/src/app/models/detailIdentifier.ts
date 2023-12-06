import { Detail } from "./detail";
import { Model } from "@/models/model";

export interface DetailIdentifier extends Model {
    Entity?: Detail;
    EntityId?: number;
    IdKind?: string;
    Name?: string;
    Value?: string;
}

