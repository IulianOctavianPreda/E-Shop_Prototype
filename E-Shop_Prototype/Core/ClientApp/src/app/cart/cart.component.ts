import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { take } from "rxjs/operators";

@Component({
  selector: "app-cart",
  templateUrl: "./cart.component.html",
  styleUrls: ["./cart.component.scss"],
})
export class CartComponent implements OnInit {
  cart;

  constructor(private route: ActivatedRoute, public http: HttpClient) {}

  ngOnInit(): void {
    this.cart = this.route.snapshot.data.cart;
  }
  remove(id) {
    this.update(id, 0);
  }

  update(id, quantity) {
    this.http
      .post(
        `https://localhost:44374/cart/9592611B-7FCB-4210-98D0-C19F5A569B0E/update`,
        {
          productId: id,
          quantity: parseInt(quantity, 10),
        }
      )
      .pipe(take(1))
      .subscribe((x) => (this.cart = x));
  }

  order() {
    this.http
      .post(
        `https://localhost:44374/cart/9592611B-7FCB-4210-98D0-C19F5A569B0E/order`,
        null
      )
      .pipe(take(1))
      .subscribe((x) => (this.cart = x));
  }
}
