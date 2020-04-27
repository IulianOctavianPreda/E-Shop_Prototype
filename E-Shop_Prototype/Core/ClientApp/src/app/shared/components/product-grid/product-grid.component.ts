import { Component, Input, OnInit } from "@angular/core";
import { ProductItem } from "src/app/api/types/product-item";

@Component({
  selector: "app-product-grid",
  templateUrl: "./product-grid.component.html",
  styleUrls: ["./product-grid.component.scss"]
})
export class ProductGridComponent implements OnInit {
  @Input() products: Array<ProductItem>;

  constructor() {}

  ngOnInit(): void {}
}
