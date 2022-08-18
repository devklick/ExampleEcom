import { z } from "zod";

export const createUserRequestSchema = z.object({
  firstName: z.string().min(1).max(64),
  lastName: z.string().min(1).max(64),
  userName: z.string().min(6).max(64),
  email: z.string().email().max(256),
  password: z
    .string()
    .min(9)
    .regex(
      new RegExp(
        "^(?=.*[a-z])(?=.*[A-Z])(?=.*d)(?=.*[@$!%*?&])[A-Za-zd@$!%*?&]{8,}$"
      )
    ),
});

export const createUserResponseSchema = z.object({
  userName: z.string().max(64),
});

export type CreateUserRequest = z.infer<typeof createUserRequestSchema>;
export type CreateUserResponse = z.infer<typeof createUserResponseSchema>;
