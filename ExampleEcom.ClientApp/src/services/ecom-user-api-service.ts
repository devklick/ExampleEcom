import { ApiResponse } from "../schemas/base-api-schema";
import { CreateUserRequest, CreateUserResponse } from "../schemas/user-schemas";
import apiService from "./api-service";
import ecomApiProxy from "./ecom-api-proxy";

const createUser = async (
  request: CreateUserRequest
): Promise<ApiResponse<CreateUserResponse>> => {
  return await apiService.post<CreateUserResponse>(ecomApiProxy, {
    body: request,
    endpoint: "user",
  });
};

const userService = {
  createUser,
};

export default userService;
