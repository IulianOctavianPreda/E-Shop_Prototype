import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { DashboardComponent } from "./shared/layout/dashboard/dashboard.component";
import { LayoutHeaderComponent } from "./shared/layout/layout-header/layout-header.component";

const routes: Routes = [
  {
    path: "",
    component: LayoutHeaderComponent,
    outlet: "header",
  },
  {
    path: "",
    component: DashboardComponent,
  },
  {
    path: "product",
    loadChildren: () =>
      import("./product/product.module").then((m) => m.ProductModule),
  },
  {
    path: "cart",
    loadChildren: () => import("./cart/cart.module").then((m) => m.CartModule),
  },
  {
    path: "order",
    loadChildren: () =>
      import("./order/order.module").then((m) => m.OrderModule),
  },
];

// const routes: Routes = [
//   {
//     path: "",
//     component: DefaultLayoutComponent,
//     children: [
//       {
//         path: "",
//         component: LayoutHeaderComponent,
//         outlet: "header"
//       },
//       {
//         path: "",
//         component: DashboardComponent
//       },
//       // {
//       //   path: "product",
//       //   loadChildren: () =>
//       //     import("./product/product.module").then(m => m.ProductModule)
//       // }
//     ]
//   }
// ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
