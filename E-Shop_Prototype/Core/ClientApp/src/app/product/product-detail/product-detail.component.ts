import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { take } from "rxjs/operators";

@Component({
  selector: "app-product-detail",
  templateUrl: "./product-detail.component.html",
  styleUrls: ["./product-detail.component.scss"],
})
export class ProductDetailComponent implements OnInit {
  product;
  constructor(
    private activatedRoute: ActivatedRoute,
    public http: HttpClient
  ) {}

  ngOnInit(): void {
    this.product = this.activatedRoute.snapshot.data.product;
  }

  quickAdd(item) {
    this.http
      .post(
        `https://localhost:44374/cart/9592611B-7FCB-4210-98D0-C19F5A569B0E/${item.id}`,
        null
      )
      .pipe(take(1))
      .subscribe(() => {});
  }
}
