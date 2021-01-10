using AutoMapper;
using Proyecto.Domain.Entities;
using Proyecto.Domain.Models.Request;
using Proyecto.Domain.Services.Commands;
using Proyecto.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto.Application.ServicesImplementation.Commands
{
    public class GrupoGraduadoServiceCommand : IGrupoGraduadoServiceCommand
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GrupoGraduadoServiceCommand(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Delete(int id)
        {
            var grupoDeleted = await _unitOfWork.grupoGraduadoRepository.Delete(id);
            return grupoDeleted ? true : false;
        }

        public async Task<bool> Save(GrupoGraduadoRequest entity)
        {
            var grupo = _mapper.Map<GrupoGraduado>(entity);
            var grupoSaved = await _unitOfWork.grupoGraduadoRepository.Save(grupo);

            return grupoSaved != null ? true : false;
        }

        public async Task<bool> Update(int id, GrupoGraduadoRequest entity)
        {
            var grupo = _mapper.Map<GrupoGraduado>(entity);
            grupo.Id = id;
            var grupoUpdated = await _unitOfWork.grupoGraduadoRepository.Update(grupo);

            return grupoUpdated != null ? true : false;
        }
    }
}
