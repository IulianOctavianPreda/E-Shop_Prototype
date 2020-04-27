import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { NgxSelectModule } from "ngx-select-ex";

import { CategoryProductsComponent } from "./components/category-products/category-products.component";
import { ProductGridComponent } from "./components/product-grid/product-grid.component";
import { ProductItemComponent } from "./components/product-item/product-item.component";
import { DashboardComponent } from "./layout/dashboard/dashboard.component";
import { DefaultLayoutComponent } from "./layout/default-layout/default-layout.component";
import { LayoutHeaderComponent } from "./layout/layout-header/layout-header.component";

@NgModule({
  declarations: [
    ProductGridComponent,
    ProductItemComponent,
    CategoryProductsComponent,
    DefaultLayoutComponent,
    LayoutHeaderComponent,
    DashboardComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    HttpClientModule,
    NgxSelectModule,
    FormsModule,
  ],
  exports: [
    ProductGridComponent,
    ProductItemComponent,
    CategoryProductsComponent,
    DefaultLayoutComponent,
    LayoutHeaderComponent,
    DashboardComponent,
    HttpClientModule,
    NgxSelectModule,
    FormsModule,
  ],
  providers: [HttpClientModule],
})
export class SharedModule {}
