import FormField, { FormFieldProps } from "../form-field/form-field";
import styles from "./form-field-group.module.scss";

export interface FormFieldGroupProps<
  FormDataType extends { [key: string]: any }
> {
  groupName: string;
  flowDirection: "left-right" | "top-bottom";
  fields: FormFieldProps<FormDataType>[];
}

const FormFieldGroup = <FormDataType extends { [key: string]: any }>({
  groupName,
  fields,
  flowDirection,
}: FormFieldGroupProps<FormDataType>) => {
  console.log(fields[0].formErrors);
  console.log(fields[1].formErrors);
  return (
    <div className={styles[`form-field-group`]}>
      <label className={styles["form-field-group__label"]}>{groupName}</label>
      <div
        className={
          styles[`form-field-group__fields-container__${flowDirection}`]
        }
      >
        {fields.map((field) => (
          <FormField<FormDataType> {...field} />
        ))}
      </div>
    </div>
  );
};

export default FormFieldGroup;
