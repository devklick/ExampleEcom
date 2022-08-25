import React, { useContext, useEffect, useRef, useState } from "react";
import { useForm } from "react-hook-form";
import { useNavigate } from "react-router-dom";
import UserContext from "../../context/user-context";
import { ApiResponseErrors } from "../../schemas/base-api-schema";
import ContentContainer from "../content-container/content-container";
import FormFileUpload from "../form-file-upload/form-file-upload";
import Form from "../form/form";
import { zodResolver } from "@hookform/resolvers/zod";
import {
  CreateProductSchema,
  createProductSchema,
  ProductPrice,
  productPriceSchema,
} from "../../schemas/product-schema";
import FormField, {
  FormFieldType,
  SelectableItem,
} from "../form-field/form-field";

import styles from "./add-product-form.module.scss";
import productService from "../../services/ecom-product-api-service";
import FormFieldGroup from "../form-field-group/form-field-group";

export interface AddProductFormProps {}

const AddProductForm: React.FC<AddProductFormProps> = () => {
  const { isSiteAdmin, cacheLoaded } = useContext(UserContext);
  const navigate = useNavigate();

  const imageDataUrls = useRef<string[]>([]);
  const [apiErrors, setErrors] = useState<ApiResponseErrors>({});
  const [_categories, setCategories] = useState<string[]>([]);

  const [currencies, setCurrencies] = useState<SelectableItem[]>([]);

  useEffect(() => {
    if (cacheLoaded && !isSiteAdmin()) {
      navigate("/");
    }
    //eslint-disable-next-line react-hooks/exhaustive-deps
  }, [cacheLoaded, isSiteAdmin]);

  useEffect(() => {
    const getCurrenciesAsync = async () => {
      var currencies = await productService.getCurrencies();
      if (currencies.statusType === "success") {
        setCurrencies(
          currencies.value.map(
            (c): SelectableItem => ({
              label: `${c.code} | ${c.name} (${c.symbol})`,
              value: c.code,
            })
          )
        );
      }
    };
    getCurrenciesAsync();
  }, []);

  const {
    register: registerCreateProductSchema,
    handleSubmit,
    formState: { errors: createProductSchemaErrors },
    setValue: setCreateProductSchemaValue,
  } = useForm({
    resolver: zodResolver(createProductSchema),
  });

  const {
    register: registerProductPriceSchema,
    formState: { errors: productPriceSchemaErrors },
    setValue: setProductPriceValue,
  } = useForm({
    resolver: zodResolver(productPriceSchema),
  });

  const onCategoriesChanged = (newValue: unknown) => {
    setCategories((newValue as SelectableItem[]).map((c) => c.label));
    setCreateProductSchemaValue("categories", _categories);
  };

  const onFilesUploaded = (urls: string[]) => {
    imageDataUrls.current = urls;
    setCreateProductSchemaValue("imageDataUrls", urls);
  };

  const onCurrencyChange = (newValue: unknown) => {
    const selected = newValue as SelectableItem;
    const code = selected.value;
  };

  const handleSubmitRegistration = async (request: CreateProductSchema) => {
    // const result = await userService.createUser(request);
    // setErrors(result.errors);
  };

  const formField = (
    fieldName: keyof CreateProductSchema,
    type: FormFieldType = "text",
    selectableItems: SelectableItem[] = [],
    onChange?: (newValue: unknown) => void
  ) => (
    <FormField<CreateProductSchema>
      fieldName={fieldName}
      type={type}
      register={registerCreateProductSchema}
      formErrors={createProductSchemaErrors}
      apiErrors={apiErrors}
      selectableItems={selectableItems}
      onChange={onChange}
    />
  );

  return (
    <div className={styles["add-product-form"]}>
      <ContentContainer width="large">
        <h1 className={styles["add-product-form-content__header"]}>
          Add Product
        </h1>

        <Form
          formClassName={styles["add-product-form-content__form"]}
          submitButtonClassName={styles["add-product-form__form-submit"]}
          submitButtonText="Submit product"
          onSubmit={handleSubmit(
            async (d) =>
              await handleSubmitRegistration(d as CreateProductSchema)
          )}
        >
          <div className={styles["add-product-form-content__form-fields"]}>
            {formField("name")}
            {formField(
              "categories",
              "creatable-select-multiple",
              [],
              onCategoriesChanged
            )}
            <FormFieldGroup<ProductPrice>
              groupName="Price"
              flowDirection={"left-right"}
              fields={[
                {
                  fieldName: "value",
                  formErrors: productPriceSchemaErrors,
                  register: registerProductPriceSchema,
                  apiErrors,
                  type: "number",
                  step: 0.01,
                  onChange: (newValue) =>
                    setProductPriceValue("value", newValue),
                },
                {
                  fieldName: "currency",
                  formErrors: productPriceSchemaErrors,
                  register: registerProductPriceSchema,
                  apiErrors,
                  type: "searchable-select",
                  selectableItems: currencies,
                  onChange: (newValue) => setProductPriceValue("prices", []),
                },
              ]}
            />
            <FormFileUpload<CreateProductSchema>
              className="add-product-form-content__file-upload"
              fieldName="imageDataUrls"
              displayName="Images"
              apiErrors={apiErrors}
              formErrors={createProductSchemaErrors}
              register={registerCreateProductSchema}
              onFilesUploaded={onFilesUploaded}
            />
          </div>
        </Form>
      </ContentContainer>
    </div>
  );
};
export default AddProductForm;
