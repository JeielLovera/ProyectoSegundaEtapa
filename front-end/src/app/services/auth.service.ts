import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HOST } from '../Utils/api-url';
import { UserData, UserToken } from '../models/User';

@Injectable({
	providedIn: 'root',
})
export class AuthService {
	userToken: string;
	private url: string = `${HOST}/ApiUsers`;

	constructor(private http: HttpClient) {
		this.GetUserToken();
	}

	async LogInUser(userData: UserData) {
		try {
			let response = await this.http
				.post(`${this.url}/log-in`, userData)
				.toPromise()
				.then((res: UserToken) => res);
			this.SetUserToken(response);
			return true;
		} catch {
			return false;
		}
	}

	async SignUpUser(userData: UserData) {
		try {
			let response = await this.http
				.post(`${this.url}/sign-up`, userData)
				.toPromise()
				.then((res: UserToken) => res);
			this.SetUserToken(response);
			return [];
		} catch (err) {
			return err.error.errors.map((e: any) => e.description);
		}
	}

	LogOut() {
		sessionStorage.removeItem('token');
		sessionStorage.removeItem('maxTimeSession');
		sessionStorage.removeItem('state');
	}

	GetUserToken() {
		if (sessionStorage.getItem('token')) {
			this.userToken = sessionStorage.getItem('token');
		} else {
			this.userToken = '';
		}
		return this.userToken;
	}

	private SetUserToken(userResponse: UserToken) {
		this.userToken = userResponse.token;
		sessionStorage.setItem('token', userResponse.token);
		let maxTimeSession = new Date(userResponse.expiration);
		sessionStorage.setItem('maxTimeSession', maxTimeSession.getTime().toString());
		sessionStorage.setItem('state', 'logged');
	}

	isAuthenticated() {
		if (!this.userToken || this.userToken == '') {
			return false;
		}

		let expiration = Number(sessionStorage.getItem('maxTimeSession'));
		let expiraDate = new Date();
		expiraDate.setTime(expiration);
		let now = new Date();

		if (expiraDate > now) {
			return true;
		} else {
			return false;
		}
	}
}
