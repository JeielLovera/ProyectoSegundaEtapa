import { Component, OnInit } from '@angular/core';
import { GrupoGraduadoService } from '../../services/grupo-graduado.service';
import { GrupoGraduadoResponse } from '../../models/GrupoGraduado';
import { Router } from '@angular/router';
import { ChartDataSets, ChartOptions, ChartType } from 'chart.js';
import { GrupoGraduadoPagedResponse } from 'src/app/models/PagedResponse';

@Component({
	selector: 'app-application',
	templateUrl: './application.component.html',
	styleUrls: ['./application.component.css'],
})
export class ApplicationComponent implements OnInit {
	pagedGrupo: GrupoGraduadoPagedResponse;
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

	constructor(private router: Router, private grupoGraduadoService: GrupoGraduadoService) {
		this.pagedGrupo = <GrupoGraduadoPagedResponse>{
			data: [],
			pageNumber: 0,
			pageSize: 0,
			maxPage: 0,
			total: 0,
			nextPage: '',
			previousPage: '',
		};
	}

	ngOnInit() {
		this.loadTable();
		this.loadGraph(this.graphYear);
		this.showGraph = false;
	}

	loadTable(query: string = '') {
		this.grupoGraduadoService.GetAllPaged(query).subscribe((resp: GrupoGraduadoPagedResponse) => {
			this.pagedGrupo = resp;
			this.since = (resp.pageNumber - 1) * resp.pageSize + 1;
			this.until = resp.pageNumber * resp.pageSize > resp.total ? resp.total : resp.pageNumber * resp.pageSize;
		});
	}

	nextPage() {
		this.loadTable(this.pagedGrupo.nextPage);
	}

	previousPage() {
		this.loadTable(this.pagedGrupo.previousPage);
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
			this.loadTable();
			this.loadGraph(this.graphYear);
		});
	}
}
