import { __decorate } from "tslib";
import { Injectable } from "@angular/core";
let AppUserService = class AppUserService {
    http;
    gridService;
    constructor(http, gridService) {
        this.http = http;
        this.gridService = gridService;
    }
    add = (user) => this.http.post("api/users", user);
    delete = (id) => this.http.delete(`api/users/${id}`);
    get = (id) => this.http.get(`api/users/${id}`);
    grid = (parameters) => this.gridService.get(`api/users/grid`, parameters);
    inactivate = (id) => this.http.patch(`api/users/${id}/inactivate`, {});
    list = () => this.http.get("api/users");
    update = (user) => this.http.put(`api/users/${user.id}`, user);
};
AppUserService = __decorate([
    Injectable({ providedIn: "root" })
], AppUserService);
export default AppUserService;
//# sourceMappingURL=user.service.js.map