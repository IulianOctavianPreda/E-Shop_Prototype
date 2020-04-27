import { CategoryItem } from "./category-item";

export interface ProductItem {
  id?: string;
  name?: string;
  description?: string;
  price?: number;
  productImage?: string;
  categoryId?: string;
  Category?: CategoryItem;
}
