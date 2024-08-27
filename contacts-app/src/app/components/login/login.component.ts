import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { catchError, tap, throwError } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  email = new FormControl('omurillob@gmail.com', [
    Validators.required,
    Validators.email,
  ]);
  password = new FormControl('1234', [Validators.required]);

  loginForm = new FormGroup({
    email: this.email,
    password: this.password,
  });

  constructor(private router: Router, private authService: AuthService) {}

  onSubmit() {
    if (this.loginForm.valid && this.email.value && this.password.value) {
      this.authService
        .login(this.email.value, this.password.value)
        .pipe(
          tap(() => {
            this.router.navigate(['/contacts']);
          }),
          catchError((error) => {
            console.error('Login error:', error);
            return throwError(() => new Error('Login failed'));
          })
        )
        .subscribe();
    }
  }
}
