import { Component, OnInit, Input } from '@angular/core';
import { Contact } from '../../contracts/login-data';
import { ContactDataService } from '../../services/component-providers/contact/contact-data.service';

@Component({
  selector: 'app-contact-details',
  templateUrl: './contact-details.component.html',
  styleUrls: ['./contact-details.component.scss'],
  providers: [ContactDataService]
})
export class ContactDetailsComponent implements OnInit {

  @Input() title: string;

  editable: boolean;
  viewMode: boolean;

  @Input() contact: Contact;

  constructor(private contactDataService: ContactDataService) {
    this.contact = this.contact || new Contact();
  }

  ngOnInit(): void {
    this.viewMode = false;
    this.editable = false;
  }

  editDetails() {
    this.editable = !this.editable;
  }

  saveDetails() {
    this.editable = !this.editable;

    this.contactDataService.setDataById(this.contact, this.contact.id).subscribe(
      addedContactId => {
        console.log(addedContactId);
      },
      error => {
        console.log(error);
      }
    );
  }

  viewDetails() {
    this.viewMode = !this.viewMode;

    if (!this.viewMode) {
      this.reset();
    }
  }

  private reset() {
    this.ngOnInit();
  }

}
