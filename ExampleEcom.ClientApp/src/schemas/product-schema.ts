import { z } from "zod";

export const productPrice = z.object({
  value: z.number().positive(),
  currency: z.string().length(3),
});

export const productCategoryPath = z.array(z.string());

export const createProductSchema = z.object({
  name: z.string().min(3).max(64),
  categories: z.array(productCategoryPath),
  prices: z.array(productPrice),
});

export type CreateProductSchema = z.infer<typeof createProductSchema>;
