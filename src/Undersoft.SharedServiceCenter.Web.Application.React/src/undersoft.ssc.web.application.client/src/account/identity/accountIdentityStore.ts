import { AccountIdentity } from '@/account/identity/accountIdentity';
import StoreBase from '@/store';

export class AccountIdentityStore extends StoreBase<AccountIdentity, AccountIdentity> {
    public constructor(endpoint: string) {
        super(endpoint);
    }
}