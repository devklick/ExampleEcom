import React, { HTMLInputTypeAttribute, useState } from "react";
import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import { ApiResponseErrors } from "../../schemas/base-api-schema";
import {
  CreateUserRequest,
  UserLoginRequest,
  userLoginRequestSchema,
} from "../../schemas/user-schemas";
import userService from "../../services/ecom-user-api-service";
import FormField from "../form-field/form-field";
import styles from "./login-form.module.scss";
import ContentContainer from "../content-container/content-container";
import Form from "../form/form";

export interface LoginFormProps {}

const LoginForm: React.FC<LoginFormProps> = () => {
  const [apiErrors, setErrors] = useState<ApiResponseErrors>({});

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: zodResolver(userLoginRequestSchema),
  });

  const handleSubmitRegistration = async (request: UserLoginRequest) => {
    const result = await userService.login(request);
    setErrors(result.errors);
  };

  const formField = (
    fieldName: keyof UserLoginRequest,
    type: HTMLInputTypeAttribute = "text"
  ) => (
    <FormField<UserLoginRequest>
      fieldName={fieldName}
      type={type}
      register={register}
      formErrors={errors}
      apiErrors={apiErrors}
    />
  );

  return (
    <div className={styles["user-registration"]}>
      <ContentContainer>
        <h1 className={styles["user-registration-content__header"]}>
          User Login
        </h1>

        <Form
          formClassName={styles["user-registration-content__form"]}
          submitButtonClassName={
            styles["user-registration-content__form-submit"]
          }
          submitButtonText="Submit registration"
          onSubmit={handleSubmit(
            async (d) => await handleSubmitRegistration(d as UserLoginRequest)
          )}
        >
          <div className={styles["user-registration-content__form-fields"]}>
            {formField("userNameOrEmail")}
            {formField("password", "password")}
          </div>
        </Form>
      </ContentContainer>
    </div>
  );
};
export default LoginForm;
