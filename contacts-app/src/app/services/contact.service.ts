import { Injectable } from '@angular/core';
import { Contact } from '../models/contact.interface';
import { map, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ApiRequestOptions } from './api-request-options';
@Injectable({
  providedIn: 'root',
})
export class ContactService {
  private readonly url = ApiRequestOptions.Url + '/contacts';

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
