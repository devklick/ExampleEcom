import { z } from "zod";

export const productPriceSchema = z.object({
  value: z.number().positive(),
  currency: z.string().length(3),
});

export const productCategoryPath = z.array(z.string());

export const createProductSchema = z.object({
  name: z.string().min(3).max(64),
  categories: z.array(productCategoryPath),
  prices: z.array(productPriceSchema),
  imageDataUrls: z.array(z.string()),
});

const CurrencySymbolOrientation = {
  BeforeValue: "BeforeValue",
  AfterValue: "AfterValue",
} as const;

const currencySymbolOrientations = z.nativeEnum(CurrencySymbolOrientation);

const getCurrenciesRequestSchema = z.object({
  search: z.string().optional(),
});
const getCurrenciesResponseSchema = z.array(
  z.object({
    name: z.string(),
    code: z.string(),
    number: z.string(),
    symbol: z.string(),
    symbolOrientation: currencySymbolOrientations,
    spacedSymbol: z.boolean(),
  })
);

export type CreateProductSchema = z.infer<typeof createProductSchema>;
export type GetCurrenciesRequest = z.infer<typeof getCurrenciesRequestSchema>;
export type GetCurrenciesResponse = z.infer<typeof getCurrenciesResponseSchema>;
export type CurrencySymbolOrientations = z.infer<
  typeof currencySymbolOrientations
>;

export type ProductPrice = z.infer<typeof productPriceSchema>;
