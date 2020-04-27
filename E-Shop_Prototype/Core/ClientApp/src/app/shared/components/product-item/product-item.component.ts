import { HttpClient } from "@angular/common/http";
import { Component, Input, OnInit } from "@angular/core";
import { ProductItem } from "src/app/api/types/product-item";

@Component({
  selector: "app-product-item",
  templateUrl: "./product-item.component.html",
  styleUrls: ["./product-item.component.scss"],
})
export class ProductItemComponent implements OnInit {
  @Input() item: ProductItem;

  constructor(public http: HttpClient) {}

  ngOnInit(): void {}

  quickAdd(item) {
    this.http.post(
      `https://localhost:44374/cart/9592611B-7FCB-4210-98D0-C19F5A569B0E/${item.id}`,
      null
    );
  }
}
