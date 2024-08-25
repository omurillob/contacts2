import { Component, OnInit } from '@angular/core';
import { Contact } from '../../models/contact.interface';
import { ContactService } from '../../services/contact.service';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrl: './contacts.component.scss',
})
export class ContactsComponent implements OnInit {
  contacts: Contact[] = [];
  selectedContact: Contact | null = null;

  constructor(private contactService: ContactService) {}

  ngOnInit(): void {
    this.contactService.getContacts().subscribe((data) => {
      this.contacts = data;
    });
  }

  selectContact(contact: Contact): void {
    this.selectedContact = contact;
  }

  updateContact(): void {
    if (this.selectedContact) {
      this.contactService.updateContact(this.selectedContact);
    }
  }
}
