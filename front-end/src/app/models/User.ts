export interface UserData {
	email: string;
	password: string;
}

export interface UserToken {
	token: string;
	expiration: Date;
}
