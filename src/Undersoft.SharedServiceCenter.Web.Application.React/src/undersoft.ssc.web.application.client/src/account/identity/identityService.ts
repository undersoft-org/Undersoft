import { AccountIdentity } from '@/models/accountIdentity';
import Service from '@/services/service';

export class IdentityService extends Service<AccountIdentity, AccountIdentity> {
    public constructor(endpoint: string) {
        super(endpoint);
    }
}