import { __decorate } from "tslib";
import { Injectable } from "@angular/core";
let AppAuthService = class AppAuthService {
    http;
    router;
    constructor(http, router) {
        this.http = http;
        this.router = router;
    }
    authenticated = () => !!this.token();
    auth(auth) {
        this.http
            .post("api/auths", auth)
            .subscribe((result) => {
            if (!result || !result.token)
                return;
            localStorage.setItem("token", result.token);
            this.router.navigate(["/main/home"]);
        });
    }
    signin = () => this.router.navigate(["/auth"]);
    signout() {
        localStorage.clear();
        this.signin();
    }
    token = () => localStorage.getItem("token");
};
AppAuthService = __decorate([
    Injectable({ providedIn: "root" })
], AppAuthService);
export default AppAuthService;
//# sourceMappingURL=auth.service.js.map