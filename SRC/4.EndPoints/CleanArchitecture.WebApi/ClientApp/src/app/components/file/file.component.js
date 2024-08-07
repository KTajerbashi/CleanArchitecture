var AppFileComponent_1;
import { __decorate } from "tslib";
import { CommonModule } from "@angular/common";
import { Component, Input } from "@angular/core";
import { FormsModule, ReactiveFormsModule, NG_VALUE_ACCESSOR } from "@angular/forms";
import AppComponent from "../component";
let AppFileComponent = AppFileComponent_1 = class AppFileComponent extends AppComponent {
    appFileService;
    class;
    disabled = false;
    formControlName;
    text;
    files = new Array();
    constructor(appFileService) {
        super();
        this.appFileService = appFileService;
    }
    change(files) {
        if (!files) {
            return;
        }
        for (let index = 0; index < files.length; index++) {
            const file = files.item(index);
            const upload = { id: "", name: file.name, progress: 0 };
            this.files.push(upload);
            this.appFileService.upload(file).subscribe((result) => {
                upload.progress = result.progress;
                if (result.id) {
                    this.value.push({ id: result.id, name: file.name, progress: upload.progress });
                    this.files = this.files.filter((x) => x.progress < 100);
                }
            });
        }
    }
};
__decorate([
    Input()
], AppFileComponent.prototype, "class", void 0);
__decorate([
    Input()
], AppFileComponent.prototype, "disabled", void 0);
__decorate([
    Input()
], AppFileComponent.prototype, "formControlName", void 0);
__decorate([
    Input()
], AppFileComponent.prototype, "text", void 0);
AppFileComponent = AppFileComponent_1 = __decorate([
    Component({
        selector: "app-file",
        templateUrl: "./file.component.html",
        standalone: true,
        providers: [{ provide: NG_VALUE_ACCESSOR, useExisting: AppFileComponent_1, multi: true }],
        imports: [
            CommonModule,
            FormsModule,
            ReactiveFormsModule
        ]
    })
], AppFileComponent);
export default AppFileComponent;
//# sourceMappingURL=file.component.js.map