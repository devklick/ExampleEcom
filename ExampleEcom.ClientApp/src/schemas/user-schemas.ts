import { z } from "zod";

export const createUserRequestSchema = z.object({
  firstName: z.string().max(64),
  lastName: z.string().max(64),
  userName: z.string().max(64),
  email: z.string().email().max(256),
  password: z.string(),
});

export const createUserResponseSchema = z.object({
  userName: z.string().max(64),
});

export type CreateUserRequest = z.infer<typeof createUserRequestSchema>;
export type CreateUserResponse = z.infer<typeof createUserResponseSchema>;
