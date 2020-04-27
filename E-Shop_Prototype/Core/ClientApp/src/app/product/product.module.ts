import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";

import { SharedModule } from "./../shared/shared.module";
import { ProductDetailComponent } from "./product-detail/product-detail.component";
import { ProductOverviewComponent } from "./product-overview/product-overview.component";
import { ProductRoutingModule } from "./product-routing.module";
import { ProductSearchResolve } from "./services/product-search.resolve";
import { ProductResolve } from "./services/product.resolve";

@NgModule({
  declarations: [ProductOverviewComponent, ProductDetailComponent],
  imports: [CommonModule, ProductRoutingModule, SharedModule],
  providers: [ProductResolve, ProductSearchResolve],
})
export class ProductModule {}
