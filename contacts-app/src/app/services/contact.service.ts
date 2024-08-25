import { Injectable } from '@angular/core';
import { Contact } from '../models/contact.interface';
import { map, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root',
})
export class ContactService {
  readonly url = 'http://localhost:5194/api/contacts';

  constructor(private http: HttpClient) {}

  getContacts(): Observable<Contact[]> {
    return this.http.get<Contact[]>(this.url);
  }

  getContactById(id: number): Observable<Contact> {
    return this.http.get<Contact>(`${this.url}/${id}`);
  }

  updateContact(contact: Contact): Observable<Contact> {
    return this.http.put<Contact>(`${this.url}/${contact.id}`, contact);
  }
}
