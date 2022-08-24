import { ApiResponse } from "../schemas/base-api-schema";
import {
  GetCurrenciesRequest,
  GetCurrenciesResponse,
} from "../schemas/product-schema";
import apiService from "./api-service";
import ecomApiProxy from "./ecom-api-proxy";

const getCurrencies = async (
  request?: GetCurrenciesRequest
): Promise<ApiResponse<GetCurrenciesResponse>> => {
  return await apiService.get<GetCurrenciesResponse>(ecomApiProxy, {
    endpoint: "/product/currency",
    queryParams: request,
  });
};

const productService = {
  getCurrencies,
};

export default productService;
