import AppFilter from "./filter";
export default class AppFilters extends Array {
    add(property, comparison, value) {
        if (!property || !value) {
            return;
        }
        this.removeIndex(this.findIndex(x => x.property === property && x.comparison === comparison));
        this.push(new AppFilter(property, comparison, value));
    }
    addFromFormGroup(form) {
        if (!form || !form.controls) {
            return;
        }
        Object.keys(form.controls).forEach(key => this.add(key, "", form.controls[key].value));
    }
    remove(property) {
        if (!property) {
            return;
        }
        this.removeIndex(this.findIndex(x => x.property === property));
    }
    removeIndex(index) {
        if (index < 0) {
            return;
        }
        this.splice(index, 1);
    }
}
//# sourceMappingURL=filters.js.map