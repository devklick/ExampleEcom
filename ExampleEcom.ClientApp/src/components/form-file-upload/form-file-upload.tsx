import React from "react";
import { FieldErrorsImpl, FieldValues, UseFormRegister } from "react-hook-form";
import ImageUploading, { ImageListType } from "react-images-uploading";
import { ApiResponseErrors } from "../../schemas/base-api-schema";

import styles from "./form-file-upload.module.scss";

export interface FileUploadProps<FormDataType extends { [key: string]: any }> {
  onFilesUploaded: (urls: string[]) => void;
  fieldName: keyof FormDataType & string;
  displayName?: string;
  register: UseFormRegister<FieldValues>;
  formErrors: FieldErrorsImpl<{
    [x: string]: any;
  }>;
  apiErrors?: ApiResponseErrors;
  className?: string;
}

const FormFileUpload = <FormDataType extends { [key: string]: any }>({
  fieldName,
  displayName,
  formErrors,
  register,
  apiErrors,
  onFilesUploaded,
  className,
}: FileUploadProps<FormDataType>) => {
  const [images, setImages] = React.useState<ImageListType>([]);
  const maxNumber = 69;

  const onChange = (
    imageList: ImageListType,
    addUpdateIndex: number[] | undefined
  ) => {
    setImages(imageList);
    onFilesUploaded(
      imageList.map((i) => i.dataURL).filter((i) => i !== undefined) as string[]
    );
  };

  const errorMessages: string[] = [];
  const formFieldError = formErrors[fieldName]?.message?.toString();
  if (formFieldError) errorMessages.push(formFieldError);
  if (apiErrors && apiErrors[fieldName])
    apiErrors[fieldName].forEach((e) => errorMessages.push(e));

  const hasErrors = !!errorMessages.length;

  return (
    <div className={`${styles["form-file-upload"]} ${className ?? ""}`}>
      <ImageUploading
        multiple
        value={images}
        onChange={onChange}
        maxNumber={maxNumber}
      >
        {({ imageList, onImageUpload, isDragging }) => (
          <div className={styles["form-file-upload"]}>
            <label className={styles["form-file-upload__field-label"]}>
              {displayName}
            </label>
            <button
              className={styles["form-file-upload__upload-button"]}
              style={isDragging ? { color: "red" } : undefined}
              onClick={onImageUpload}
            >
              Click to browse
            </button>
            {imageList.length ? (
              <div className={styles["form-file-upload__images-container"]}>
                {imageList.map((image, index) => (
                  <div
                    key={index}
                    className={styles["form-file-upload__image-item"]}
                  >
                    <img
                      src={image.dataURL}
                      alt=""
                      className={styles["form-file-upload__image"]}
                    />
                  </div>
                ))}
              </div>
            ) : null}
            {
              <p className={styles["form-file-upload__input-errors"]}>
                {hasErrors && errorMessages}
              </p>
            }
          </div>
        )}
      </ImageUploading>
    </div>
  );
};
export default FormFileUpload;
