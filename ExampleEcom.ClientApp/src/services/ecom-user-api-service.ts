import { ApiResponse } from "../schemas/base-api-schema";
import {
  CreateUserRequest,
  CreateUserResponse,
  UserLoginRequest,
  UserLoginResponse,
} from "../schemas/user-schemas";
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

const login = async (
  request: UserLoginRequest
): Promise<ApiResponse<UserLoginResponse>> => {
  return await apiService.post<UserLoginResponse>(ecomApiProxy, {
    body: request,
    endpoint: "user/login",
  });
};

const userService = {
  createUser,
  login,
};

export default userService;
