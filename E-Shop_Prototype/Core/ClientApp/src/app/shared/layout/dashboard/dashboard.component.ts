import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { BehaviorSubject } from "rxjs";

@Component({
  templateUrl: "./dashboard.component.html",
  styleUrls: ["./dashboard.component.scss"],
})
export class DashboardComponent implements OnInit {
  public categories$ = new BehaviorSubject<any>(undefined);

  constructor(private client: HttpClient) {}

  ngOnInit(): void {
    this.client
      .get("https://localhost:44374/product")
      .subscribe((x) => console.log(x));
    this.client
      .get("https://localhost:44374/category/dashboard")
      .subscribe((x) => this.categories$.next(x));
  }
}
