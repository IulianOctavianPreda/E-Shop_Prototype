import { Component, Input, OnChanges, OnInit } from "@angular/core";

import { CategoryItem } from "./../../../api/types/category-item";

@Component({
  selector: "app-category-products",
  templateUrl: "./category-products.component.html",
  styleUrls: ["./category-products.component.scss"],
})
export class CategoryProductsComponent implements OnInit, OnChanges {
  @Input() categoryItems: Array<CategoryItem>;

  constructor() {}
  ngOnChanges(changes: import("@angular/core").SimpleChanges): void {
    if (changes.categoryItems) {
      console.log(changes.categoryItems.currentValue);
    }
  }

  ngOnInit(): void {}
}
