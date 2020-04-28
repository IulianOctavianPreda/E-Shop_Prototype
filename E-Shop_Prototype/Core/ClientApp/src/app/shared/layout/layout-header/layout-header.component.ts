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
  searchValue = "";

  ngxValue;
  constructor(public http: HttpClient, private router: Router) {}

  ngOnInit(): void {}

  onType(typed: string) {
    this.searchValue = typed;
    this.searchCallback(typed);
  }

  searchCallback(search: string) {
    forkJoin([
      this.http.get("https://localhost:44374/product/search", {
        params: { search },
      }),
      this.http.get("https://localhost:44374/product/luceneSearch", {
        params: { search },
      }),
    ])
      .pipe(take(1))
      .subscribe((x) => {
        this.searchItems = [];
        this.searchItems.push({
          text: "Search",
          children: x[0] ?? [],
        });
        this.searchItems.push({
          text: "Lucene Search",
          children: x[1] ?? [],
        });
      });
  }

  goToProduct(productId) {
    this.router
      .navigateByUrl("/", { skipLocationChange: true })
      .then(() => this.router.navigate(["/product/detail", { id: productId }]));
  }

  search() {
    this.router
      .navigateByUrl("/", { skipLocationChange: true })
      .then(() =>
        this.router.navigate([
          "/product/overview",
          { queryParams: this.searchValue },
        ])
      );
  }
}
