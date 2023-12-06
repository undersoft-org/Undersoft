import { AccountGroup } from "../enums/accountGroup";
import { Company } from "./company";
import { Location } from "./location";
import { Detail } from "./detail";
import { Model } from "@/models/model";
import { Identifier } from "./identifier";
import { Setting } from "./setting";

export interface Client extends Model {
    email: string | null;
    name: string | null;
    fullName: string | null;
    group: AccountGroup | null;
    location: Location | null;
    company: Company | null;
    details: Detail[] | null;
    settings: Setting[] | null;
    identifiers: Identifier<Client> | null;
}