import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-order",
  templateUrl: "./order.component.html",
  styleUrls: ["./order.component.scss"],
})
export class OrderComponent implements OnInit {
  orders;

  constructor(private route: ActivatedRoute, public http: HttpClient) {}

  ngOnInit(): void {
    this.orders = this.route.snapshot.data.orders;
    console.log(this.orders);
  }
}
