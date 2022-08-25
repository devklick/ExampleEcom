import React, {
  HTMLInputTypeAttribute,
  useContext,
  useEffect,
  useState,
} from "react";
import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import { ApiResponseErrors, isSuccess } from "../../schemas/base-api-schema";
import {
  UserLoginRequest,
  userLoginRequestSchema,
} from "../../schemas/user-schemas";
import userService from "../../services/ecom-user-api-service";
import FormField from "../form-field/form-field";
import styles from "./login-form.module.scss";
import ContentContainer from "../content-container/content-container";
import Form from "../form/form";
import { useNavigate } from "react-router-dom";
import UserContext from "../../context/user-context";

export interface LoginFormProps {}

const LoginForm: React.FC<LoginFormProps> = () => {
  const [apiErrors, setErrors] = useState<ApiResponseErrors>({});
  const { user, setUser } = useContext(UserContext);
  const navigate = useNavigate();

  const navigateHome = () => navigate("/");

  useEffect(() => {
    if (user) navigateHome();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [user]);

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
    if (isSuccess(result)) {
      setUser(result.value);
      navigateHome();
    }
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
    <div className={styles["login-form"]}>
      <ContentContainer width="regular">
        <h1 className={styles["login-form-content__header"]}>User Login</h1>

        <Form
          formClassName={styles["login-form-content__form"]}
          submitButtonClassName={styles["login-form-content__form-submit"]}
          submitButtonText="Submit Login"
          onSubmit={handleSubmit(
            async (d) => await handleSubmitRegistration(d as UserLoginRequest)
          )}
        >
          <div className={styles["login-form-content__form-fields"]}>
            {formField("userNameOrEmail")}
            {formField("password", "password")}
          </div>
        </Form>
      </ContentContainer>
    </div>
  );
};
export default LoginForm;
