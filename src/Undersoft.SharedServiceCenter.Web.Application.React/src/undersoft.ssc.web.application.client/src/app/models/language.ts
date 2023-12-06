import { Model } from "../../models/model";

export interface Language extends Model {
    name: string | null;
    languageCode: string | null;
}