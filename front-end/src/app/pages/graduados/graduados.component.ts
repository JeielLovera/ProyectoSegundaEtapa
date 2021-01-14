import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { GrupoGraduadoRequest, GrupoGraduadoResponse } from '../../models/GrupoGraduado';
import { CursoResponse } from '../../models/Curso';
import { CursoService } from '../../services/curso.service';
import { GrupoGraduadoService } from '../../services/grupo-graduado.service';

@Component({
	selector: 'app-graduados',
	templateUrl: './graduados.component.html',
	styleUrls: ['./graduados.component.css'],
})
export class GraduadosComponent implements OnInit {
	newRegistry = { anyo: '', sexo: '', curso: 1, cantidad: null };
	cursos: CursoResponse[] = [];
	alert: boolean = false;
	texto: string = '';

	constructor(
		private router: Router,
		private activateRoute: ActivatedRoute,
		private grupoGraduadoService: GrupoGraduadoService,
		private cursoService: CursoService
	) {}

	ngOnInit() {
		this.cursoService.GetAll().subscribe((resp) => {
			this.cursos = resp;
		});
		this.activateRoute.params.subscribe((params) => {
			if (params.id == 'nuevo') {
				this.texto = 'Agregar';
			} else {
				this.texto = 'Editar';
				this.grupoGraduadoService.GetById(params.id).subscribe((resp: GrupoGraduadoResponse) => {
					this.newRegistry = {
						anyo: resp.anyo.toString().slice(0, 4),
						sexo: resp.sexo,
						curso: resp.curso.id,
						cantidad: resp.cantidad,
					};
				});
			}
		});
	}

	Save(form: NgForm) {
		if (form.invalid) {
			return;
		}

		let grupoGraduado = <GrupoGraduadoRequest>{
			anyo: new Date(`${this.newRegistry.anyo}-01-01`),
			sexo: this.newRegistry.sexo,
			cursoId: Number(this.newRegistry.curso),
			cantidad: this.newRegistry.cantidad,
		};

		let id: any;
		this.activateRoute.params.subscribe((params) => (id = params.id));

		if (id == 'nuevo') {
			this.grupoGraduadoService.Save(grupoGraduado).subscribe((resp) => {
				this.alert = true;
				let time = new Promise(() => {
					setTimeout(() => {
						this.router.navigate(['/app']);
					}, 1500);
				});
			});
		} else {
			this.grupoGraduadoService.Update(grupoGraduado, Number(id)).subscribe((resp) => {
				this.alert = true;
				let time = new Promise(() => {
					setTimeout(() => {
						this.router.navigate(['/app']);
					}, 1500);
				});
			});
		}
	}
}
