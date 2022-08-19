import { AxiosInstance, AxiosRequestConfig, Method } from "axios";
import { ApiResponse, ApiResponseStatusType } from "../schemas/base-api-schema";

type PostOptions = {
  endpoint?: string;
  body?: object;
};

type RequestOptions = PostOptions & {
  queryParameters?: object;
  headers?: Record<string, string | number | boolean>;
};

const post = async <TResponseBody>(
  proxy: AxiosInstance,
  options?: PostOptions
): Promise<ApiResponse<TResponseBody>> => {
  return await executeRequest<TResponseBody>(proxy, "post", {
    ...options,
  });
};

const executeRequest = async <TResponse>(
  proxy: AxiosInstance,
  method: Method,
  options: RequestOptions
): Promise<ApiResponse<TResponse>> => {
  const requestConfig: AxiosRequestConfig = {
    method,
    url: buildUrl(options.endpoint, options.queryParameters),
    data: options.body,
    headers: options.headers,
    responseType: "json",
  };
  const response = await proxy.request<ApiResponse<TResponse>>(requestConfig);

  console.log(response);

  const statusType = getApiResponseStatus(response.status);

  return {
    ...response.data,
    statusType,
  };
};

const getApiResponseStatus = (status: number): ApiResponseStatusType => {
  const statusString = status.toString();
  switch (statusString.charAt(0)) {
    case "2":
      return "success";
    case "4":
      return "client-error";
    case "5":
      return "server-error";
    default:
      console.warn(`Unhandled response status ${status}`);
      return "server-error";
  }
};

const buildUrl = (endpoint?: string, urlParams?: object) =>
  `${endpoint}${buildQueryString(urlParams)}`;

const buildQueryString = (urlParams: object | undefined) =>
  urlParams
    ? `?${Object.entries(urlParams).map(
        (param) =>
          `${encodeURIComponent(param[0])}=${encodeURIComponent(param[1])}`
      )}`
    : "";

const apiService = {
  post,
};

export default apiService;
