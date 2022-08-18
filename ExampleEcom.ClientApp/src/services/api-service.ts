import { AxiosInstance, AxiosRequestConfig, Method } from "axios";

type ApiResponseStatus = "success" | "client-error" | "server-error";
type ApiResponse<TBody> = {
  status: ApiResponseStatus;
  body: TBody | null;
};

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

const executeRequest = async <TBody>(
  proxy: AxiosInstance,
  method: Method,
  options: RequestOptions
): Promise<ApiResponse<TBody>> => {
  const requestConfig: AxiosRequestConfig = {
    method,
    url: buildUrl(options.endpoint, options.queryParameters),
    data: options.body,
    headers: options.headers,
    responseType: "json",
  };
  const response = await proxy.request(requestConfig);

  console.log(response);

  const status = getApiResponseStatus(response.status);
  const body = getApiResponseBody<TBody>(response.data);

  return {
    status,
    body,
  };
};

const getApiResponseStatus = (status: number): ApiResponseStatus => {
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

const getApiResponseBody = <TBody>(data: any) => data as TBody;

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
