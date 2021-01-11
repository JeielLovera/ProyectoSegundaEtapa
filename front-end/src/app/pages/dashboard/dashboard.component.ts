import { Component, OnInit } from '@angular/core';
import { GrupoGraduadoService } from '../../services/grupo-graduado.service';
import { GrupoGraduado } from '../../models/GrupoGraduado';

@Component({
	selector: 'app-dashboard',
	templateUrl: './dashboard.component.html',
	styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent implements OnInit {
	grupos: GrupoGraduado[] = [];

	constructor(private grupoGraduadoService: GrupoGraduadoService) {}

	ngOnInit() {
		this.grupoGraduadoService.GetAll().subscribe((resp) => {
			this.grupos = resp.filter((e) => e.id <= 20);
			console.log(this.grupos);
		});
	}
}
