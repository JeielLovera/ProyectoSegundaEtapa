import { Injectable } from '@angular/core';
import { HOST } from '../Utils/api-url';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { GrupoGraduadoResponse, GrupoGraduadoRequest } from '../models/GrupoGraduado';
import { GrupoGraduadoPagedResponse } from '../models/PagedResponse';

@Injectable({
	providedIn: 'root',
})
export class GrupoGraduadoService {
	private url: string = `${HOST}/GrupoGraduados`;
	private header: HttpHeaders;
	constructor(private http: HttpClient) {
		this.header = this.createHeader();
	}

	GetAll() {
		return this.http.get<GrupoGraduadoResponse[]>(this.url, { headers: this.header });
	}

	GetAllPaged(query: string = '') {
		if (query === '') query = 'GrupoGraduados';
		return this.http.get<GrupoGraduadoPagedResponse>(`${HOST}/${query}`, { headers: this.header });
	}

	GetById(id: any) {
		return this.http.get<GrupoGraduadoResponse>(`${this.url}/${id}`, { headers: this.header });
	}

	GetSumGraduadosByCursoByAnyo(year: number) {
		return this.http.get(`${this.url}/sum_graduados/${year}`, { headers: this.header });
	}

	Save(body: GrupoGraduadoRequest) {
		return this.http.post<GrupoGraduadoRequest>(this.url, body, { headers: this.header });
	}

	Update(body: GrupoGraduadoRequest, id: number) {
		return this.http.put<GrupoGraduadoRequest>(`${this.url}/${id}`, body, { headers: this.header });
	}

	Delete(id: number) {
		return this.http.delete(`${this.url}/${id}`, { headers: this.header });
	}

	createHeader() {
		return new HttpHeaders({
			Authorization: `Bearer ${sessionStorage.getItem('token')}`,
		});
	}
}
