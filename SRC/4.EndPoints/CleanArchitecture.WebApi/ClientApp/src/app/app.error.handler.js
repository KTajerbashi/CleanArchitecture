import { __decorate } from "tslib";
import { HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
let AppErrorHandler = class AppErrorHandler {
    appModalService;
    constructor(appModalService) {
        this.appModalService = appModalService;
    }
    handleError(error) {
        if (error instanceof HttpErrorResponse && error.error) {
            this.appModalService.alert(error.error);
        }
    }
};
AppErrorHandler = __decorate([
    Injectable({ providedIn: "root" })
], AppErrorHandler);
export default AppErrorHandler;
//# sourceMappingURL=app.error.handler.js.map