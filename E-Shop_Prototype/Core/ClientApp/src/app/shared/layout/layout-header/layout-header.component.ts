import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { forkJoin } from "rxjs";
import { take } from "rxjs/operators";

@Component({
  selector: "app-layout-header",
  templateUrl: "./layout-header.component.html",
  styleUrls: ["./layout-header.component.scss"],
})
export class LayoutHeaderComponent implements OnInit {
  searchItems = [];

  ngxValue;
  constructor(public http: HttpClient, private router: Router) {}

  ngOnInit(): void {}

  searchCallback(search: string) {
    forkJoin(
      this.http.get("https://localhost:44374/product/search", {
        params: { search },
      }),
      this.http.get("https://localhost:44374/product/search", {
        params: { search },
      })
    )
      .pipe(take(1))
      .subscribe((x) => {
        this.searchItems = [
          {
            text: "Search",
            children: x[0],
          },
          {
            text: "Lucerne Search",
            children: x[1],
          },
        ];
        console.log(x);
        console.log(this.searchItems);
      });
  }

  goToProduct(product) {
    this.router.navigate(["/product/detail", { id: product.id }]);
  }
  search() {
    this.router.navigate(["/product", { search: this.ngxValue }]);
  }
}
