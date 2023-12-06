import StoreBase from '@/store';
import { Servicer } from '@/app/models/servicer';

export default class ServicerStore extends StoreBase<Servicer, Servicer> {
    public constructor(endpoint: string) {
        super(endpoint);
    }
}

export const servicers = new ServicerStore('Servicers');

export const currentSubcontractor: Servicer = { Id: 0, Label: "" } as Servicer;