import { Model } from "@/models/model";

export interface Identifier<T = Model | any> extends Model {
    Entity?: T;
    EntityId?: number;
    IdKind?: string;
    Name?: string;
    Value?: string;
    Key?: number;
}

