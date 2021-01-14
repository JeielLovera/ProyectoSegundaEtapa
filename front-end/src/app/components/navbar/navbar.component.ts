import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
	selector: 'app-navbar',
	templateUrl: './navbar.component.html',
	styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent implements OnInit {
	isLogged: boolean = false;
	constructor(private router: Router, private authService: AuthService) {
		let state = sessionStorage.getItem('state');
		if (state && state == 'logged') {
			this.isLogged = true;
		} else {
			this.isLogged = false;
		}
	}

	ngOnInit() {}

	LogOut() {
		this.authService.LogOut();
		this.isLogged = false;
		this.router.navigate(['/home']);
	}

	GoHome() {
		this.LogOut();
	}
}
