import { Model } from "@/models/model";

export interface CountryState extends Model {
    name: string | null;
    stateCode: string | null;
    timeZone: string | null;
}