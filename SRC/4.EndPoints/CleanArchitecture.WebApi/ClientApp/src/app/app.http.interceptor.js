import { inject } from "@angular/core";
import AppAuthService from "./services/auth.service";
export const appHttpInterceptor = (request, next) => {
    const appAuthService = inject(AppAuthService);
    request = request.clone({
        setHeaders: { Authorization: `Bearer ${appAuthService.token()}` }
    });
    return next(request);
};
//# sourceMappingURL=app.http.interceptor.js.map