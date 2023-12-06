import { Address } from "./address";
import { Endpoint } from "./endpoint";
import { Model } from "@/models/model";

export interface Location extends Model {
    name: string | null;
    localeType: LocaleType;
    email: string | null;
    phoneType: PhoneType;
    phoneNumber: string | null;
    notices: string | null;
    addresses: Address[];
    endpoints: Endpoint[] | null;
}

export enum LocaleType {
    Main,
    Private,
    Bussines,
    Additional
}

export enum PhoneType {
    Main,
    Personal,
    Bussines,
    Fax
}