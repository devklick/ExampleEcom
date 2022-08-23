import React, {
  HTMLInputTypeAttribute,
  useContext,
  useEffect,
  useRef,
  useState
} from "react";
import { useForm } from "react-hook-form";
import { useNavigate } from "react-router-dom";
import UserContext from "../../context/user-context";
import { ApiResponseErrors } from "../../schemas/base-api-schema";
import ContentContainer from "../content-container/content-container";
import FileUpload from "../file-upload/file-upload";
import Form from "../form/form";
import { zodResolver } from "@hookform/resolvers/zod";
import {
  CreateProductSchema,
  createProductSchema
} from "../../schemas/product-schema";
import FormField from "../form-field/form-field";

import styles from "./add-product.form.module.scss";

export interface AddProductFormProps {}

const AddProductForm: React.FC<AddProductFormProps> = () => {
  const imageUrlsRef = useRef<string[]>([]);

  const [apiErrors, setErrors] = useState<ApiResponseErrors>({});
  const { isSiteAdmin } = useContext(UserContext);
  const navigate = useNavigate();

  useEffect(() => {
    if (!isSiteAdmin()) navigate("/");
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [isSiteAdmin]);

  const {
    register,
    handleSubmit,
    formState: { errors }
  } = useForm({
    resolver: zodResolver(createProductSchema)
  });

  const handleSubmitRegistration = async (request: CreateProductSchema) => {
    // const result = await userService.createUser(request);
    // setErrors(result.errors);
  };

  const formField = (
    fieldName: keyof CreateProductSchema,
    type: HTMLInputTypeAttribute = "text"
  ) => (
    <FormField<CreateProductSchema>
      fieldName={fieldName}
      type={type}
      register={register}
      formErrors={errors}
      apiErrors={apiErrors}
    />
  );

  const onFileUploaded = (url: string) => {
    imageUrlsRef.current.push(url);
  };

  return (
    <div className={styles["add-product-form"]}>
      <ContentContainer>
        <h1 className={styles["add-product-form-content__header"]}>
          Add Product
        </h1>

        <Form
          formClassName={styles["add-product-form-content__form"]}
          submitButtonClassName={styles["add-product-form__form-submit"]}
          submitButtonText="Submit registration"
          onSubmit={handleSubmit(
            async d => await handleSubmitRegistration(d as CreateProductSchema)
          )}
        >
          <div className={styles["add-product-form-content__form-fields"]}>
            {formField("name")}
            {formField("categories")}
            {formField("prices")}
          </div>
          <FileUpload onFileUploaded={onFileUploaded}></FileUpload>
        </Form>
      </ContentContainer>
    </div>
  );
};
export default AddProductForm;
