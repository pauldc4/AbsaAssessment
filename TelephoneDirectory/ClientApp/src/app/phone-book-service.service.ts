import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import "rxjs";
import { Subject } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class PhoneBookServiceService {
  private headers: HttpHeaders;
  private baseUrl: string = 'https://localhost:44305/api/PhoneBook/';

  public phoneBookData: any[];
  public phoneBooksChanged = new Subject<boolean>();

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }

  public GetTelephoneDirectory() {
    var url = this.baseUrl + 'GetPhoneBook';
    return this.http.get(url, { headers: this.headers }).subscribe(
      (data: any) => {
        this.phoneBookData = data;
        this.phoneBooksChanged.next(true);
      })
  }

  public SearchDirectory(searchTerm: string) {
    var url = this.baseUrl + 'SearchPhoneBook/' + searchTerm;
    return this.http.get(url, { headers: this.headers }).subscribe(
      (data: any) => {
        this.phoneBookData = data;
        this.phoneBooksChanged.next(true);
      })
  }

  public AddToDirectory(data) {
    var url = this.baseUrl + 'AddPhoneBook'
    return this.http.post(url, data, { headers: this.headers });
  }

  public UpdateDirectory(data) {
    var url = this.baseUrl + 'UpdatePhoneBook'
    return this.http.post(url, data, { headers: this.headers });
  }

  public DeleteDirectory(id) {
    var url = this.baseUrl + 'Delete/' + id;
    return this.http.get(url, { headers: this.headers })
  }

}
