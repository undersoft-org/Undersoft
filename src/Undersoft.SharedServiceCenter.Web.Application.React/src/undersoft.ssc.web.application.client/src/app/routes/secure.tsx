import { Navigate } from 'react-router-dom';
import { currentUser } from '@/app/store/userStore'

export { SecuredRoute };

function SecuredRoute({ children }:any) {

    if (!currentUser.IsAuthorized) {
        return <Navigate to="/auth/signin" />
    }
    return children;
}