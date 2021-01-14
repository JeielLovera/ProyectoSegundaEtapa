import { CursoResponse } from './Curso';

export interface GrupoGraduadoResponse {
	id: number;
	anyo: Date;
	sexo: string;
	cantidad?: number;
	curso: CursoResponse;
}

export interface GrupoGraduadoRequest {
	anyo: Date;
	sexo: string;
	cursoId: number;
	cantidad?: number;
}
