import { Injectable } from '@angular/core';
import { HOST } from '../Utils/api-url';
import { HttpClient } from '@angular/common/http';
import { CursoResponse } from '../models/Curso';

@Injectable({
	providedIn: 'root',
})
export class CursoService {
	private url: string = `${HOST}/Cursos`;

	constructor(private http: HttpClient) {}

	GetAll() {
		return this.http.get<CursoResponse[]>(this.url);
	}
}
