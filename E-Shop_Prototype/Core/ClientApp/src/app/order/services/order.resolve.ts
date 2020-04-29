import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve } from "@angular/router";
import { Observable } from "rxjs";

@Injectable()
export class OrderResolve implements Resolve<Observable<any>> {
  constructor(private service: HttpClient) {}

  resolve(activatedRoute: ActivatedRouteSnapshot): Observable<any> {
    return this.service.get(
      `https://localhost:44374/Order/9592611B-7FCB-4210-98D0-C19F5A569B0E`
    );
  }
}
