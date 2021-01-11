import { Curso } from './Curso';

export interface GrupoGraduado {
	id: number;
	anyo: Date;
	sexo: string;
	cursoId: number;
	cantidad?: number;

	curso: Curso;
}
