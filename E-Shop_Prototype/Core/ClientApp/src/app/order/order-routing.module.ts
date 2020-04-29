import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { OrderComponent } from "./order.component";
import { OrderResolve } from "./services/order.resolve";

const routes: Routes = [
  {
    path: "",
    component: OrderComponent,
    resolve: {
      orders: OrderResolve,
    },
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class OrderRoutingModule {}
