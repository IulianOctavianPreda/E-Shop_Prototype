import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";

import { OrderRoutingModule } from "./order-routing.module";
import { OrderComponent } from "./order.component";
import { OrderResolve } from "./services/order.resolve";

@NgModule({
  declarations: [OrderComponent],
  imports: [CommonModule, OrderRoutingModule],
  providers: [OrderResolve],
})
export class OrderModule {}
