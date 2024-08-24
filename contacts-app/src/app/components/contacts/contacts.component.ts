import { Component } from '@angular/core';
import { Contact } from '../../models/contact.interface';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrl: './contacts.component.scss',
})
export class ContactsComponent {
  contacts: Contact[] = [
    { firstName: 'John', lastName: 'Doe', phoneNumber: '123-456-7890' },
    { firstName: 'Jane', lastName: 'Smith', phoneNumber: '987-654-3210' },
  ];

  selectedContact!: Contact;

  selectContact(contact: Contact) {
console.log(contact);
    this.selectedContact = contact;
  }
}
