import { Component, OnInit } from '@angular/core';
import { GrupoGraduadoService } from '../../services/grupo-graduado.service';
import { GrupoGraduadoResponse } from '../../models/GrupoGraduado';
import { CursoResponse } from '../../models/Curso';
import { Router } from '@angular/router';

@Component({
	selector: 'app-dashboard',
	templateUrl: './dashboard.component.html',
	styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent implements OnInit {
	allGrupos: GrupoGraduadoResponse[] = [];
	pageGrupo: GrupoGraduadoResponse[] = [];
	maxPage: number;
	pageSize: number = 10;
	page: number = 0;
	since: number = 0;
	until: number = 0;

	datatest: GrupoGraduadoResponse[] = [
		<GrupoGraduadoResponse>{
			id: 1,
			anyo: new Date('1993-01-01'),
			sexo: 'Males',
			cursoId: 1,
			curso: <CursoResponse>{ id: 1, nombre: 'Education' },
			cantidad: 2000,
		},
		<GrupoGraduadoResponse>{
			id: 2,
			anyo: new Date('1993-01-01'),
			sexo: 'Males',
			cursoId: 1,
			curso: <CursoResponse>{ id: 1, nombre: 'Education' },
			cantidad: 1000,
		},
		<GrupoGraduadoResponse>{
			id: 3,
			anyo: new Date('1993-01-01'),
			sexo: 'Males',
			cursoId: 1,
			curso: <CursoResponse>{ id: 1, nombre: 'Education' },
			cantidad: 1500,
		},
		<GrupoGraduadoResponse>{
			id: 4,
			anyo: new Date('1993-01-01'),
			sexo: 'Males',
			cursoId: 1,
			curso: <CursoResponse>{ id: 1, nombre: 'Education' },
			cantidad: 3500,
		},
		<GrupoGraduadoResponse>{
			id: 5,
			anyo: new Date('1993-01-01'),
			sexo: 'Males',
			cursoId: 2,
			curso: <CursoResponse>{ id: 2, nombre: 'Arts' },
			cantidad: 1000,
		},
		<GrupoGraduadoResponse>{
			id: 6,
			anyo: new Date('1993-01-01'),
			sexo: 'Males',
			cursoId: 2,
			curso: <CursoResponse>{ id: 2, nombre: 'Arts' },
			cantidad: 500,
		},
		<GrupoGraduadoResponse>{
			id: 7,
			anyo: new Date('1993-01-01'),
			sexo: 'Males',
			cursoId: 2,
			curso: <CursoResponse>{ id: 2, nombre: 'Arts' },
			cantidad: 300,
		},
		<GrupoGraduadoResponse>{
			id: 8,
			anyo: new Date('1993-01-01'),
			sexo: 'Males',
			cursoId: 2,
			curso: <CursoResponse>{ id: 2, nombre: 'Arts' },
			cantidad: 2500,
		},
		<GrupoGraduadoResponse>{
			id: 9,
			anyo: new Date('1993-01-01'),
			sexo: 'Males',
			cursoId: 3,
			curso: <CursoResponse>{ id: 3, nombre: 'Science' },
			cantidad: 2000,
		},
		<GrupoGraduadoResponse>{
			id: 10,
			anyo: new Date('1993-01-01'),
			sexo: 'Males',
			cursoId: 3,
			curso: <CursoResponse>{ id: 3, nombre: 'Science' },
			cantidad: 1000,
		},
		<GrupoGraduadoResponse>{
			id: 11,
			anyo: new Date('1993-01-01'),
			sexo: 'Males',
			cursoId: 3,
			curso: <CursoResponse>{ id: 3, nombre: 'Science' },
			cantidad: 1500,
		},
		<GrupoGraduadoResponse>{
			id: 12,
			anyo: new Date('1993-01-01'),
			sexo: 'Males',
			cursoId: 3,
			curso: <CursoResponse>{ id: 3, nombre: 'Science' },
			cantidad: 3500,
		},
	];

	constructor(private router: Router, private grupoGraduadoService: GrupoGraduadoService) {}

	ngOnInit() {
		this.grupoGraduadoService.GetAll().subscribe((resp) => {
			this.allGrupos = resp;
			this.maxPage = Math.ceil(this.allGrupos.length / this.pageSize);
			this.nextPage();
		});
	}

	async nextPage() {
		this.page++;
		this.pageGrupo = await this.sliceCollection();
		this.since = this.pageGrupo[0].id;
		this.until = this.pageGrupo[this.pageGrupo.length - 1].id;
	}

	async previousPage() {
		this.page--;
		this.pageGrupo = await this.sliceCollection();
	}

	sliceCollection() {
		let start = (this.page - 1) * this.pageSize;
		let end = (this.page - 1) * this.pageSize + this.pageSize;
		return this.allGrupos.slice(start, end);
	}

	editRegistry(id: number) {
		this.router.navigate(['app/graduados', id]);
	}
}
