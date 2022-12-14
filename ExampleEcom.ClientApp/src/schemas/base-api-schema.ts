export type ApiResponseStatusType = "success" | "client-error" | "server-error";
export type ApiResponseErrors = Record<string, string[]>;

export type ApiResponse<T> = {
  statusCode: number;
  statusType: ApiResponseStatusType;
  value: T;
  errors: ApiResponseErrors;
};

export const isSuccess = <T>(response: ApiResponse<T>) =>
  response.statusType === "success";
