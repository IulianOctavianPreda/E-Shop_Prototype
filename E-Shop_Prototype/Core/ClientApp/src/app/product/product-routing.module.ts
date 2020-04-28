import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { ProductDetailComponent } from "./product-detail/product-detail.component";
import { ProductOverviewComponent } from "./product-overview/product-overview.component";
import { ProductSearchResolve } from "./services/product-search.resolve";
import { ProductResolve } from "./services/product.resolve";

const routes: Routes = [
  {
    path: "product",
    children: [
      {
        path: "",
        redirectTo: "overview",
        pathMatch: "full",
      },
      {
        path: "overview",
        component: ProductOverviewComponent,
        resolve: {
          products: ProductSearchResolve,
        },
      },
      {
        path: ":id",
        component: ProductDetailComponent,
        resolve: {
          product: ProductResolve,
        },
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ProductRoutingModule {}
