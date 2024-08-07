import { inject } from "@angular/core";
import AppAuthService from "./services/auth.service";
export const appCanActivate = () => {
    const appAuthService = inject(AppAuthService);
    if (appAuthService.authenticated()) {
        return true;
    }
    appAuthService.signin();
    return false;
};
//# sourceMappingURL=app.can.activate.js.map