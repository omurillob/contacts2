import { Component, OnInit } from '@angular/core';
import { ContactService } from '../../services/contact.service';
import { Contact } from '../../models/contact.interface';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit-contact',
  templateUrl: './edit-contact.component.html',
  styleUrls: ['./edit-contact.component.scss'],
})
export class EditContactComponent implements OnInit {
  contact: Contact | null = null;

  constructor(
    private route: ActivatedRoute,
    private contactService: ContactService,
    private router: Router
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.contactService.getContactById(Number(id)).subscribe({
        next: (contact) => {
          this.contact = contact;
        },
        error: (err) => {
          console.error('Error fetching contact:', err);
        },
      });
    } else {
      this.contact = { id: 0, firstName: '', lastName: '', phoneNumber: '' };
    }
  }

  saveChanges() {
    if (this.contact) {
      this.contactService.updateContact(this.contact).subscribe(() => {
        this.router.navigate(['/contacts']);
      });
    }
  }
}
