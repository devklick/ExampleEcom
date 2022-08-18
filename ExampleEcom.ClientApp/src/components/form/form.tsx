import React from "react";
import styles from "./form.module.scss";

export interface FormProps {
  children: React.ReactNode;
  onSubmit: () => void;
  formClassName?: string;
  submitButtonClassName?: string;
  submitButtonText?: string;
}

const Form: React.FC<FormProps> = ({
  children,
  formClassName,
  onSubmit,
  submitButtonText,
  submitButtonClassName: submitClassName,
}) => {
  return (
    <form
      className={`${styles["form"]} ${formClassName ?? ""}`}
      onSubmit={onSubmit}
    >
      {children}
      <input
        className={`${styles["form-submit"]} ${submitClassName ?? ""}`}
        type="submit"
        value={submitButtonText ?? "Submit"}
      />
    </form>
  );
};
export default Form;
