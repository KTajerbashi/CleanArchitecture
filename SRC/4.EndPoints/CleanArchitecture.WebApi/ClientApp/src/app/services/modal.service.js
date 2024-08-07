import { __decorate } from "tslib";
import { Injectable } from "@angular/core";
let AppModalService = class AppModalService {
    alert = (message) => UIkit.modal.alert(message);
};
AppModalService = __decorate([
    Injectable({ providedIn: "root" })
], AppModalService);
export default AppModalService;
//# sourceMappingURL=modal.service.js.map