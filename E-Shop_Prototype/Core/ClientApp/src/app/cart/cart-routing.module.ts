import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { CartComponent } from "./cart.component";
import { CartResolve } from "./services/card.resolve";

const routes: Routes = [
  {
    path: "",
    component: CartComponent,
    resolve: {
      products: CartResolve,
    },
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CartRoutingModule {}
