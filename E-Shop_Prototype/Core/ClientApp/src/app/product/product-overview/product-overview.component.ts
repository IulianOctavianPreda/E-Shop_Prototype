import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-product-overview",
  templateUrl: "./product-overview.component.html",
  styleUrls: ["./product-overview.component.scss"],
})
export class ProductOverviewComponent implements OnInit {
  products;
  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.products = this.route.snapshot.data.products;
    console.log(this.products);
  }
}
