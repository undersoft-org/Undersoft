import { Model } from "@/models/model";
import { Currency } from "./currency";
import { Language } from "./language";
import { CountryState } from "./countryState";

export interface Country extends Model {
    name: string | null;
    countryCode: string | null;
    continent: string | null;
    timeZone: string | null;
    currencyId: number | null;
    currency: Currency | null;
    languageId: number | null;
    language: Language | null;
    countryStates: CountryState[] | null;
}