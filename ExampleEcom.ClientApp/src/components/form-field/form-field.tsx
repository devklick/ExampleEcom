import { HTMLInputTypeAttribute, useState } from "react";
import { FieldErrorsImpl, FieldValues, UseFormRegister } from "react-hook-form";
import Select from "react-select";
import { ApiResponseErrors } from "../../schemas/base-api-schema";
import { camelToTitle } from "../../utilities/string-utilities";
import styles from "./form-field.module.scss";

export type FormFieldType = HTMLInputTypeAttribute | "searchable-select";

export type SelectableItem = {
  value: string;
  label: string;
};

export interface FormFieldProps<FormDataType extends { [key: string]: any }> {
  fieldName: keyof FormDataType & string;
  displayName?: string;
  register: UseFormRegister<FieldValues>;
  formErrors: FieldErrorsImpl<{
    [x: string]: any;
  }>;
  apiErrors?: ApiResponseErrors;
  type?: FormFieldType;
  selectableItems?: SelectableItem[];
}

const FormField = <TFormDataType extends { [key: string]: any }>({
  fieldName,
  register,
  formErrors,
  type = "text",
  displayName,
  apiErrors,
  selectableItems = [],
}: FormFieldProps<TFormDataType>) => {
  displayName = displayName ?? camelToTitle(fieldName);

  const [selected, setSelected] = useState<SelectableItem | null>(null);

  const errorMessages: string[] = [];
  const formFieldError = formErrors[fieldName]?.message?.toString();
  if (formFieldError) errorMessages.push(formFieldError);
  if (apiErrors && apiErrors[fieldName])
    apiErrors[fieldName].forEach((e) => errorMessages.push(e));

  const hasErrors = !!errorMessages.length;

  const renderField = () => {
    if (type === "searchable-select") {
      return (
        <Select<SelectableItem>
          value={selected}
          getOptionLabel={(item) => item.label}
          getOptionValue={(animal) => animal.value}
          options={selectableItems}
          isClearable={true}
          backspaceRemovesValue={true}
          onChange={(option) => setSelected(option)}
        />
      );
    }

    return (
      <input
        className={styles["form-field__input"]}
        {...register(fieldName)}
        aria-invalid={hasErrors}
        type={type}
      />
    );
  };

  return (
    <div className={styles["form-field"]}>
      <label className={styles["form-field__label"]}>{displayName}</label>
      {renderField()}
      {
        <p className={styles["form-field__input-errors"]}>
          {hasErrors && errorMessages}
        </p>
      }
    </div>
  );
};

export default FormField;
