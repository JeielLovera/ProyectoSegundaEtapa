import { GrupoGraduadoResponse } from './GrupoGraduado';

export interface GrupoGraduadoPagedResponse {
	data: GrupoGraduadoResponse[];
	pageNumber: number;
	pageSize: number;
	maxPage: number;
	total: number;
	nextPage: string;
	previousPage: string;
}
