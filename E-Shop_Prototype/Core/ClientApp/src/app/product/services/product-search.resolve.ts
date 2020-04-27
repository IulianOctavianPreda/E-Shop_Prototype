import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve } from "@angular/router";
import { forkJoin, Observable } from "rxjs";
import { map } from "rxjs/operators";

@Injectable()
export class ProductSearchResolve implements Resolve<Observable<any>> {
  constructor(private service: HttpClient) {}

  resolve(activatedRoute: ActivatedRouteSnapshot): Observable<any> {
    const { params } = activatedRoute;
    if (!!params.search) {
      return forkJoin(
        this.service.get("https://localhost:44374/product/search", {
          params: { search: params.search },
        }),
        this.service.get("https://localhost:44374/product/search", {
          params: { search: params.search },
        })
      ).pipe(
        map((x) => {
          return [
            {
              name: "Search",
              products: x[0],
            },
            {
              name: "Lucerne Search",
              products: x[1],
            },
          ];
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
