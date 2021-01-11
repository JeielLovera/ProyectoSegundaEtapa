import { Injectable } from '@angular/core';
import { HOST } from '../Utils/api-url';
import { HttpClient } from '@angular/common/http';
import { GrupoGraduado } from '../models/GrupoGraduado';

@Injectable({
	providedIn: 'root',
})
export class GrupoGraduadoService {
	private url: string = `${HOST}/GrupoGraduados`;

	constructor(private http: HttpClient) {}

	GetAll() {
		return this.http.get<GrupoGraduado[]>(this.url);
	}
}
