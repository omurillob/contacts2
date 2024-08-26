import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { ApiRequestOptions } from './api-request-options';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly url = ApiRequestOptions.Url + '/auth';

  constructor(private http: HttpClient) {}

  login(username: string, password: string) {
    const body = { username, password };
    return this.http.post<any>(this.url + '/login', body).pipe(
      map((response) => {
        localStorage.setItem('token', response.token);
        //localStorage.setItem(‘access_token’, JSON.stringify(response.access_token));

        return response;
      })
    );
  }

  logout() {
    localStorage.removeItem('token');
  }

  isLoggedIn() {
    return !!localStorage.getItem('token');
  }

  getToken() {
    return localStorage.getItem('token');
  }

  setHeaders() {
    const token = this.getToken();
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return headers;
  }
}
