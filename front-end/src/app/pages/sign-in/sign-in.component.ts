import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { UserData } from '../../models/User';
import { Router } from '@angular/router';

@Component({
	selector: 'app-sign-in',
	templateUrl: './sign-in.component.html',
	styleUrls: ['./sign-in.component.css'],
})
export class SignInComponent implements OnInit {
	userData: UserData = { email: '', password: '' };
	badLogin: boolean = false;

	constructor(private router: Router, private authService: AuthService) {}

	ngOnInit() {}

	async SignIn(form: NgForm) {
		if (form.invalid) {
			return;
		}
		let logged = await this.authService.LogInUser(this.userData);
		if (logged) {
			this.router.navigate(['/app']);
		} else {
			this.badLogin = true;
		}
	}
}
