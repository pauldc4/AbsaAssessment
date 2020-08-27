import { Component, OnInit } from '@angular/core';
import { PhoneBookComponent } from '../phone-book/phone-book.component';
import { PhoneBookServiceService } from '../phone-book-service.service';

@Component({
  selector: 'app-add-phone-book',
  templateUrl: './add-phone-book.component.html',
  styleUrls: ['./add-phone-book.component.css']
})
export class AddPhoneBookComponent implements OnInit {

  public numbers: any[];
  public firstName: string;
  public lastName: string;
  public type: string;
  public number: string;

  constructor(private phoneBookService: PhoneBookServiceService) { }

  ngOnInit() {
    this.numbers = [];
  }

  public AddNumber() {
    this.numbers.push({ name: this.type, telephoneNumber: this.number })
    this.number = '';
    this.type = '';
  }

  public Save() {
    var data = {
      firstName: this.firstName, lastname: this.lastName, entry: this.numbers
    }

    this.phoneBookService.AddToDirectory(data).subscribe(response => {
      alert('Number Successfully added');
      this.numbers = [];
      this.firstName = '';
      this.lastName = '';
    });
  }


}
