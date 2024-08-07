import { __decorate } from "tslib";
import { Injectable } from "@angular/core";
let AppSettingsService = class AppSettingsService {
    http;
    settings;
    constructor(http) {
        this.http = http;
        this.http.get("./assets/settings.json").subscribe((settings) => this.settings = settings);
    }
};
AppSettingsService = __decorate([
    Injectable({ providedIn: "root" })
], AppSettingsService);
export default AppSettingsService;
//# sourceMappingURL=settings.service.js.map