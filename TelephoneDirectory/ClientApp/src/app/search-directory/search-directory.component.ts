import { Component, OnInit } from '@angular/core';
import { PhoneBookServiceService } from '../phone-book-service.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-search-directory',
  templateUrl: './search-directory.component.html',
  styleUrls: ['./search-directory.component.css']
})
export class SearchDirectoryComponent implements OnInit {
  public searchTerm: string;
  public phoneBooks: any[];

  phoneBookSub: Subscription;

  constructor(private phoneBookService: PhoneBookServiceService) { }

  ngOnInit() {
    this.phoneBookSub = this.phoneBookService.phoneBooksChanged.subscribe((OnDataChanged: boolean) => {
      this.phoneBooks = this.phoneBookService.phoneBookData;
    });

    this.phoneBookService.GetTelephoneDirectory();
  }

  public search() {

    this.phoneBookService.SearchDirectory(this.searchTerm);    

  }

}
