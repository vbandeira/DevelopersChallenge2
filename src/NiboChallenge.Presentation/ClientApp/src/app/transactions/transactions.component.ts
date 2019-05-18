import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Transaction } from '../../models/transaction';

@Component({
  selector: 'app-transactions',
  templateUrl: './transactions.component.html'
})
export class TransactionsComponent {
  public transactions: Transaction[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Transaction[]>(baseUrl + 'api/Transaction').subscribe(result => {
      this.transactions = result;
    }, error => console.error(error));
  }
}

