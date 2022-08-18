import { HTMLInputTypeAttribute } from "react";
import { FieldErrorsImpl, FieldValues, UseFormRegister } from "react-hook-form";
import { camelToTitle } from "../../utilities/string-utilities";
import styles from "./form-field.module.scss";

export interface FormFieldProps<FormDataType extends { [key: string]: any }> {
  fieldName: keyof FormDataType & string;
  displayName?: string;
  register: UseFormRegister<FieldValues>;
  errors: FieldErrorsImpl<{
    [x: string]: any;
  }>;
  type?: HTMLInputTypeAttribute;
}

const FormField = <TFormDataType extends { [key: string]: any }>({
  fieldName,
  register,
  errors,
  type,
  displayName,
}: FormFieldProps<TFormDataType>) => {
  displayName = displayName ?? camelToTitle(fieldName);
  return (
    <div className={styles["form-field"]}>
      <label className={styles["form-field__label"]}>{displayName}</label>
      <input
        className={styles["form-field__input"]}
        {...register(fieldName)}
        aria-invalid={!!errors[fieldName]}
        type={type}
      />
      {
        <p className={styles["form-field__input-errors"]}>
          {errors[fieldName]?.message?.toString()}
        </p>
      }
    </div>
  );
};

export default FormField;
