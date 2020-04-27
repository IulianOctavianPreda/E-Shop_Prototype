import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve } from "@angular/router";
import { Observable } from "rxjs";

@Injectable()
export class ProductResolve implements Resolve<Observable<any>> {
  constructor(private service: HttpClient) {}

  resolve(activatedRoute: ActivatedRouteSnapshot): Observable<any> {
    const { params } = activatedRoute;
    return this.service.get(`https://localhost:44374/product/${params.id}`);
  }
}
