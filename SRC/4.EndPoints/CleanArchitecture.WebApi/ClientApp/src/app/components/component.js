export default class AppComponent {
    _value;
    get value() { return this._value; }
    set value(value) {
        if (this.value === value)
            return;
        this._value = value;
        if (this.onChange)
            this.onChange(value);
    }
    registerOnChange(onChange) { this.onChange = onChange; }
    registerOnTouched(_) { }
    writeValue(value) { this.value = value; }
    onChange;
}
//# sourceMappingURL=component.js.map