import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { HTMLInputTypeAttribute } from "react";

import {
  CreateUserRequest,
  createUserRequestSchema,
} from "../../schemas/user-schemas";
import FormField from "../form-field/form-field";
import ContentContainer from "../content-container/content-container";
import userService from "../../services/ecom-user-api-service";
import Form from "../form/form";

import styles from "./user-registration.module.scss";

export interface UserRegistrationProps {}

const UserRegistration: React.FC<UserRegistrationProps> = () => {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: zodResolver(createUserRequestSchema),
  });

  const handleSubmitRegistration = async (request: CreateUserRequest) => {
    const result = await userService.createUser(request);
    // TODO: Check result and redirect
  };

  const formField = (
    fieldName: keyof CreateUserRequest,
    type: HTMLInputTypeAttribute = "text"
  ) => (
    <FormField<CreateUserRequest>
      fieldName={fieldName}
      type={type}
      register={register}
      errors={errors}
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

export default UserRegistration;
