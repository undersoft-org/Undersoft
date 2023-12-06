import { SubcontractorAccount } from '@/app/models/servicer';
import Service from '@/services/service';

export default class ServicerService extends Service<SubcontractorAccount, SubcontractorAccount> {
    public constructor(endpoint: string) {
        super(endpoint);
    }
}

export const servicers = new ServicerService('Servicers');

export const currentSubcontractor: SubcontractorAccount = { Id: 0, Label: "" } as SubcontractorAccount;