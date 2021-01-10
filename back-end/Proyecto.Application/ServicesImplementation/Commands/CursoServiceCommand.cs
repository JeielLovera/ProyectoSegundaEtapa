using AutoMapper;
using Proyecto.Domain.Entities;
using Proyecto.Domain.Models.Request;
using Proyecto.Domain.Services.Commands;
using Proyecto.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Application.ServicesImplementation.Commands
{
    public class CursoServiceCommand : ICursoServiceCommand
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CursoServiceCommand(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Delete(int id)
        {
            var cursoDeleted = await _unitOfWork.cursoReposotory.Delete(id);
            return cursoDeleted ? true : false;

        }

        public async Task<bool> Save(CursoRequest entity)
        {
            var curso = _mapper.Map<Curso>(entity);
            var cursoSaved = await _unitOfWork.cursoReposotory.Save(curso);

            return cursoSaved != null ? true : false;
        }

        public async Task<bool> Update(int id, CursoRequest entity)
        {
            var curso = _mapper.Map<Curso>(entity);
            curso.Id = id;
            var cursoUpdated = await _unitOfWork.cursoReposotory.Update(curso);

            return cursoUpdated != null ? true : false;
        }
    }
}
