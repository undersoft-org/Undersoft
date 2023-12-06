import { Model } from "@/models/model";

export interface Currency extends Model {
    name: string | null;
    currencyCode: string | null;
    rate: number;
}