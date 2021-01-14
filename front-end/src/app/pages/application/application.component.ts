import { Component, OnInit } from '@angular/core';
import { GrupoGraduadoService } from '../../services/grupo-graduado.service';
import { GrupoGraduadoResponse } from '../../models/GrupoGraduado';
import { Router } from '@angular/router';
import { ChartDataSets, ChartOptions, ChartType } from 'chart.js';

@Component({
	selector: 'app-application',
	templateUrl: './application.component.html',
	styleUrls: ['./application.component.css'],
})
export class ApplicationComponent implements OnInit {
	allGrupos: GrupoGraduadoResponse[] = [];
	pageGrupo: GrupoGraduadoResponse[] = [];
	maxPage: number;
	pageSize: number = 10;
	page: number = 0;
	since: number = 0;
	until: number = 0;
	graphYear: number = 1993;
	showGraph: boolean = false;
	barChartType: ChartType = 'horizontalBar';
	barChartLabels: string[];
	barChartData: ChartDataSets[] = [];
	barChartColors = [{ backgroundColor: 'rgba(173, 238, 104, 1)' }];
	barChartOptions: ChartOptions = {
		responsive: true,
	};
	selectedGrupoId: number = 0;

	constructor(private router: Router, private grupoGraduadoService: GrupoGraduadoService) {}

	ngOnInit() {
		this.loadTable();
		this.loadGraph(this.graphYear);
		this.showGraph = false;
	}

	loadTable() {
		this.grupoGraduadoService.GetAll().subscribe((resp) => {
			this.allGrupos = resp;
			this.maxPage = Math.ceil(this.allGrupos.length / this.pageSize);
			this.nextPage();
		});
	}

	async nextPage() {
		this.page++;
		this.pageGrupo = await this.sliceCollection();
	}

	async previousPage() {
		this.page--;
		this.pageGrupo = await this.sliceCollection();
	}

	sliceCollection() {
		let start = (this.page - 1) * this.pageSize;
		let end = (this.page - 1) * this.pageSize + this.pageSize;
		this.since = start + 1;
		this.until = end > this.allGrupos.length ? this.allGrupos.length : end;
		return this.allGrupos.slice(start, end);
	}

	editRegistry(id: number) {
		this.router.navigate(['app/graduados', id]);
	}

	async loadGraph(year: number) {
		this.barChartData = [];
		let res = await this.grupoGraduadoService.GetSumGraduadosByCursoByAnyo(year).toPromise();
		let data = JSON.stringify(res);
		let array = JSON.parse(data);
		this.barChartLabels = array.map((e) => e.curso);
		this.barChartData.push({
			data: array.map((e) => e.cantidad),
			label: year.toString(),
			backgroundColor: 'rgb(173, 238, 104)',
		});
	}

	nextYear() {
		this.graphYear++;
		this.loadGraph(this.graphYear);
	}

	previousYear() {
		this.graphYear--;
		this.loadGraph(this.graphYear);
	}

	selectToDelete(selected: number) {
		this.selectedGrupoId = selected;
	}

	deleteSelectedGrupo() {
		return this.grupoGraduadoService.Delete(this.selectedGrupoId).subscribe(() => {
			this.page = 0;
			this.loadTable();
			this.loadGraph(this.graphYear);
		});
	}
}
