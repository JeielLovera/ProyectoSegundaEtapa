import { Injectable } from '@angular/core';
import { HOST } from '../Utils/api-url';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CursoResponse } from '../models/Curso';

@Injectable({
	providedIn: 'root',
})
export class CursoService {
	private url: string = `${HOST}/Cursos`;
	private header: HttpHeaders;

	constructor(private http: HttpClient) {
		this.header = this.createHeader();
	}

	GetAll() {
		return this.http.get<CursoResponse[]>(this.url, { headers: this.header });
	}

	createHeader() {
		return new HttpHeaders({
			Authorization: `Bearer ${sessionStorage.getItem('token')}`,
		});
	}
}
