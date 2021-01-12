import { Injectable } from '@angular/core';
import { HOST } from '../Utils/api-url';
import { HttpClient } from '@angular/common/http';
import { GrupoGraduadoResponse, GrupoGraduadoRequest } from '../models/GrupoGraduado';

@Injectable({
	providedIn: 'root',
})
export class GrupoGraduadoService {
	private url: string = `${HOST}/GrupoGraduados`;

	constructor(private http: HttpClient) {}

	GetAll() {
		return this.http.get<GrupoGraduadoResponse[]>(this.url);
	}

	GetById(id: any) {
		return this.http.get<GrupoGraduadoResponse>(`${this.url}/${id}`);
	}

	Save(body: GrupoGraduadoRequest) {
		return this.http.post<GrupoGraduadoRequest>(this.url, body);
	}

	Update(body: GrupoGraduadoRequest, id: number) {
		return this.http.put<GrupoGraduadoRequest>(`${this.url}/${id}`, body);
	}
}
