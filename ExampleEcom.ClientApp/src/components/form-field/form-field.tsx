import { HTMLInputTypeAttribute } from "react";
import { FieldErrorsImpl, FieldValues, UseFormRegister } from "react-hook-form";
import { ApiResponseErrors } from "../../schemas/base-api-schema";
import { camelToTitle } from "../../utilities/string-utilities";
import styles from "./form-field.module.scss";

export interface FormFieldProps<FormDataType extends { [key: string]: any }> {
  fieldName: keyof FormDataType & string;
  displayName?: string;
  register: UseFormRegister<FieldValues>;
  formErrors: FieldErrorsImpl<{
    [x: string]: any;
  }>;
  apiErrors?: ApiResponseErrors;
  type?: HTMLInputTypeAttribute;
}

const FormField = <TFormDataType extends { [key: string]: any }>({
  fieldName,
  register,
  formErrors,
  type,
  displayName,
  apiErrors,
}: FormFieldProps<TFormDataType>) => {
  displayName = displayName ?? camelToTitle(fieldName);

  const errorMessages: string[] = [];
  const formFieldError = formErrors[fieldName]?.message?.toString();
  if (formFieldError) errorMessages.push(formFieldError);
  if (apiErrors && apiErrors[fieldName])
    apiErrors[fieldName].forEach((e) => errorMessages.push(e));

  const hasErrors = !!errorMessages.length;

  return (
    <div className={styles["form-field"]}>
      <label className={styles["form-field__label"]}>{displayName}</label>
      <input
        className={styles["form-field__input"]}
        {...register(fieldName)}
        aria-invalid={hasErrors}
        type={type}
      />
      {
        <p className={styles["form-field__input-errors"]}>
          {hasErrors && errorMessages}
        </p>
      }
    </div>
  );
};

export default FormField;
