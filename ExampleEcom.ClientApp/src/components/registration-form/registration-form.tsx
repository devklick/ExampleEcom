import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { HTMLInputTypeAttribute, useState } from "react";

import {
  CreateUserRequest,
  createUserRequestSchema,
} from "../../schemas/user-schemas";
import FormField from "../form-field/form-field";
import ContentContainer from "../content-container/content-container";
import userService from "../../services/ecom-user-api-service";
import Form from "../form/form";

import styles from "./registration-form.module.scss";
import { ApiResponseErrors } from "../../schemas/base-api-schema";

export interface UserRegistrationProps {}

const RegistrationForm: React.FC<UserRegistrationProps> = () => {
  const [apiErrors, setErrors] = useState<ApiResponseErrors>({});
  console.log("in reg form");

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: zodResolver(createUserRequestSchema),
  });

  const handleSubmitRegistration = async (request: CreateUserRequest) => {
    const result = await userService.createUser(request);
    setErrors(result.errors);
  };

  const formField = (
    fieldName: keyof CreateUserRequest,
    type: HTMLInputTypeAttribute = "text"
  ) => (
    <FormField<CreateUserRequest>
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
          User Registration
        </h1>

        <Form
          formClassName={styles["user-registration-content__form"]}
          submitButtonClassName={
            styles["user-registration-content__form-submit"]
          }
          submitButtonText="Submit registration"
          onSubmit={handleSubmit(
            async (d) => await handleSubmitRegistration(d as CreateUserRequest)
          )}
        >
          <div className={styles["user-registration-content__form-fields"]}>
            {formField("firstName")}
            {formField("lastName")}
            {formField("userName")}
            {formField("email", "email")}
            {formField("password", "password")}
          </div>
        </Form>
      </ContentContainer>
    </div>
  );
};

export default RegistrationForm;
