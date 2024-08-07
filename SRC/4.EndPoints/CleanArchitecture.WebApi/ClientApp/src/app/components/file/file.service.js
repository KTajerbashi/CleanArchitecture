import { __decorate } from "tslib";
import { HttpEventType, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
let AppFileService = class AppFileService {
    http;
    constructor(http) {
        this.http = http;
    }
    upload(file) {
        const formData = new FormData();
        formData.append(file.name, file);
        const request = new HttpRequest("POST", "api/files", formData, { reportProgress: true });
        return new Observable((observable) => {
            this.http.request(request).subscribe((event) => {
                if (event.type === HttpEventType.Response) {
                    return observable.next({ id: event.body[0].id, progress: 100 });
                }
                if (event.type === HttpEventType.UploadProgress && event.total) {
                    return observable.next({ progress: Math.round(100 * event.loaded / event.total) });
                }
                return observable.next({ progress: 0 });
            });
        });
    }
};
AppFileService = __decorate([
    Injectable({ providedIn: "root" })
], AppFileService);
export default AppFileService;
//# sourceMappingURL=file.service.js.map