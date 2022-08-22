import { z } from "zod";

export const createUserRequestSchema = z.object({
  firstName: z.string().min(1).max(64),
  lastName: z.string().min(1).max(64),
  userName: z
    .string()
    .min(6)
    .max(64)
    .regex(/^[a-zA-Z0-9_-]*$/, {
      message:
        "Only letters, numbers, underscores (_) and hyphens (-) are allowed",
    }),
  email: z.string().email().max(256),
  password: z
    .string()
    .min(9)
    .regex(/[a-z]/, { message: "Must contain at least one lowercase letter" })
    .regex(/[A-Z]/, { message: "Must contain at least one uppercase letter" })
    .regex(/[\d]/, { message: "Must contain at least one number" })
    .regex(/[\W]/, { message: "Must contain at least one special character" }),
});

export const createUserResponseSchema = z.object({
  userName: z.string().max(64),
});

export const userLoginRequestSchema = z.object({
  userNameOrEmail: z.string().min(1).max(256),
  password: z.string().min(1).max(256),
});

export const userLoginResponseSchema = z.object({
  id: z.number().int(),
  firstName: z.string(),
  lastName: z.string(),
  userName: z.string(),
  token: z.string(),
});

export type CreateUserRequest = z.infer<typeof createUserRequestSchema>;
export type CreateUserResponse = z.infer<typeof createUserResponseSchema>;
export type UserLoginRequest = z.infer<typeof userLoginRequestSchema>;
export type UserLoginResponse = z.infer<typeof userLoginResponseSchema>;
