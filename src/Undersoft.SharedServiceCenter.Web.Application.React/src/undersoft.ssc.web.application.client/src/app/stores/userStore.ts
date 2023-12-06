import StoreBase  from '@/store';
import { User } from '@/app/models/user';

export default class UserStore extends StoreBase<User, User> {
    public constructor(endpoint: string) {
        super(endpoint);
    }     
}

export const userAccounts = new UserStore('Users');

export const currentUser: User = { Id: 0, Label: "", Identity: { Info: { UserName: "", Email: "" } } } as User;