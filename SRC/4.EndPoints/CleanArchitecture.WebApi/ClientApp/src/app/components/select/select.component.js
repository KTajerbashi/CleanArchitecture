import AppComponent from "src/app/components/component";
export default class AppSelectComponent extends AppComponent {
    options = new Array();
    clear = () => this.options = new Array();
    load = (parameter) => this.get(parameter).subscribe((options) => this.options = options);
    writeValue(value) { this.value = value; this.change(); }
    change() {
        if (!this.child)
            return;
        let child = this.child;
        while (child) {
            child.value = undefined;
            child.clear();
            child = child.child;
        }
        this.child.load(this.value);
    }
}
//# sourceMappingURL=select.component.js.map