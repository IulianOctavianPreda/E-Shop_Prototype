import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";

import { CartRoutingModule } from "./cart-routing.module";
import { CartComponent } from "./cart.component";
import { CartResolve } from "./services/card.resolve";

@NgModule({
  declarations: [CartComponent],
  imports: [CommonModule, CartRoutingModule],
  providers: [CartResolve],
})
export class CartModule {}
