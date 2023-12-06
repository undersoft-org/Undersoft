import { Model } from "@/models/model";


export interface Personal extends Model {
    FirstName?: string;
    SecondName?: string;
    LastName?: string;
    BirthDate?: string;
    Age?: number;
    Gender?: string;
}

