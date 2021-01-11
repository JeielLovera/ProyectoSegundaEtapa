import { TestBed } from '@angular/core/testing';

import { GrupoGraduadoService } from './grupo-graduado.service';

describe('GrupoGraduadoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: GrupoGraduadoService = TestBed.get(GrupoGraduadoService);
    expect(service).toBeTruthy();
  });
});
