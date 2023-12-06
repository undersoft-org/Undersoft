import { Model } from "@/models/model";

export interface Address extends Model {
    cityName: string | null;
    streetName: string | null;
    buildingNumber: string | null;
    apartmentNumber: string | null;
    postcode: string | null;
    notices: string | null;
    addressType: AddressType | null;
    countryId: number | null;
    country: Country | null;
    stateId: number | null;
    countryState: CountryState | null;
}