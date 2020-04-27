import { ProductItem } from "./product-item";

export interface CategoryItem {
  id?: string;
  name?: string;
  products?: Array<ProductItem>;
}
