import { Component, OnInit } from '@angular/core';
import { UserData } from '../../models/User';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { NgForm } from '@angular/forms';

@Component({
	selector: 'app-sign-up',
	templateUrl: './sign-up.component.html',
	styleUrls: ['./sign-up.component.css'],
})
export class SignUpComponent implements OnInit {
	userCredentials = { email: '', password: '', repeatPassword: '' };
	wrongPassword: boolean = false;
	wrongCredentials: boolean = false;
	errors: any[] = [];

	constructor(private router: Router, private authService: AuthService) {}

	ngOnInit() {}

	async SignUp(form: NgForm) {
		if (form.invalid) {
			return;
		}

		if (this.userCredentials.password !== this.userCredentials.repeatPassword) {
			this.wrongPassword = true;
			this.wrongCredentials = false;
			return;
		}

		const { email, password } = this.userCredentials;
		let userData = <UserData>{ email: email, password: password };

		let registered = await this.authService.SignUpUser(userData);

		if (registered.length > 0) {
			this.wrongCredentials = true;
			this.wrongPassword = false;
			this.errors = registered;
			return;
		} else {
			this.router.navigate(['/app']);
		}
	}
}
