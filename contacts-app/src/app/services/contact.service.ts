import { Injectable } from '@angular/core';
import { Contact } from '../models/contact.interface';
import { map, Observable, of, throwError } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class ContactService {
  private contacts: Contact[] = [
    // Sample contacts
    { id: 1, firstName: 'John', lastName: 'Doe', phoneNumber: '123-456-7890' },
    {
      id: 2,
      firstName: 'Jane',
      lastName: 'Smith',
      phoneNumber: '987-654-3210',
    },
  ];

  getContacts(): Contact[] {
    return this.contacts;
  }

  getContactById(id: number): Observable<Contact> {
    const contact = this.contacts.find((c) => c.id === id);
    return contact
      ? of(contact)
      : throwError(() => new Error('Contact not found'));
  }

  updateContact(contact: Contact): Observable<void> {
    const index = this.contacts.findIndex((c) => c.id === contact.id);
    if (index !== -1) {
      this.contacts[index] = contact;
      return of(void 0);
    } else {
      return throwError(() => new Error('Contact not found'));
    }
  }

  /* updateContact(contact: Contact): Observable<Contact> {
    return this.http.put<Contact>(`${this.contactsUrl}/${contact.id}`, contact);
  } */
}
