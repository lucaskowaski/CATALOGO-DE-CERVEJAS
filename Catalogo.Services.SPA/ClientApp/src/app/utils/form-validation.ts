import { NgForm } from "@angular/forms";

export abstract class FormValidation {
    public static validateAndSetAllFieldsAsChanged(form: NgForm) {
        if (form.invalid) {
            Object.keys(form.controls).forEach(key => {
                form.controls[key].markAsTouched();
                form.controls[key].markAsDirty();
            })
            return false;
        } else return true;
    }
    public static setAsUnchanged(form: NgForm) {
        Object.keys(form.controls).forEach(key => {
            form.controls[key].markAsUntouched();
            form.controls[key].markAsPristine();
        })
    }
}