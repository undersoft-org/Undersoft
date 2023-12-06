import { Model } from "@/models/model";

export interface Company extends Model {
    taxId: string | null;
    companySize: string | null;
    revenue: string | null;
}