import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve } from "@angular/router";
import { forkJoin, Observable } from "rxjs";
import { map } from "rxjs/operators";

@Injectable()
export class ProductSearchResolve implements Resolve<Observable<any>> {
  constructor(private service: HttpClient) {}

  resolve(activatedRoute: ActivatedRouteSnapshot): Observable<any> {
    const search = activatedRoute.params.queryParams;
    if (!!search) {
      return forkJoin(
        this.service.get("https://localhost:44374/product/search", {
          params: { search: search },
        }),
        this.service.get("https://localhost:44374/product/luceneSearch", {
          params: { search: search },
        })
      ).pipe(
        map((x) => {
          let products = [];
          if ((<Array<object>>x[0])?.length > 0) {
            products.push({
              name: "Search",
              products: x[0],
            });
          }
          if ((<Array<object>>x[1])?.length > 0) {
            products.push({
              name: "Lucene Search",
              products: x[1],
            });
          }
          return products;
        })
      );
    }
    return this.service.get(`https://localhost:44374/product/`).pipe(
      map((x) => {
        return [
          {
            text: "Search",
            products: x,
          },
        ];
      })
    );
  }
}
