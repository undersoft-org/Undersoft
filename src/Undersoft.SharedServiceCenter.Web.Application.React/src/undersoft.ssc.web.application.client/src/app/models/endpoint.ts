import { Model } from "@/models/model";

export interface Endpoint extends Model {
    host: string | null;
    iP: string | null;
    port: number | null;
    uRI: string | null;
}