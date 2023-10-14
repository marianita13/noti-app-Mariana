using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using APINOTI.Dtos;
using AutoMapper;
using Core.Entities;
using Infraestructura.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APINOTI.Controllers
{
    public class ModuloMaestrosController : ControllerBase
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public ModuloMaestrosController (UnitOfWork unitOfWork, IMapper mapper)
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<ModuloMaestrosDto>>> Get(){
            var moduloMaestros = await _UnitOfWork.ModuloMaestros.GetAllAsync();
            return Ok(moduloMaestros);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ModuloMaestrosDto>> GetId(int id){
            var moduloMaestros = await _UnitOfWork.ModuloMaestros.GetIdAsync(id);
            if (moduloMaestros == null){
                return NotFound();
            }
            return Ok(moduloMaestros);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ModuloMaestrosDto>> Post(ModuloMaestrosDto moduloMaestrosDto){
            var moduloMaestros = _mapper.Map<ModulosMaestros>(moduloMaestrosDto);
            _UnitOfWork.ModuloMaestros.Add(moduloMaestros);
            await _UnitOfWork.SaveAsync();
            if (moduloMaestros == null){
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new {id = moduloMaestrosDto.Id}, moduloMaestrosDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ModuloMaestrosDto>> Put(int id, ModuloMaestrosDto moduloMaestrosDto){
            if (moduloMaestrosDto.Id == 0){
                moduloMaestrosDto.Id = id;
            }
            if (moduloMaestrosDto.Id != id){
                return NotFound();
            }
            if (moduloMaestrosDto == null){
                return BadRequest();
            }
            var moduloMaestros = _mapper.Map<ModulosMaestros>(moduloMaestrosDto);
            _UnitOfWork.ModuloMaestros.Update(moduloMaestros);
            await _UnitOfWork.SaveAsync();
            return moduloMaestrosDto;
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ModuloMaestrosDto>> Delete(int id){
            var moduloMaestros = await _UnitOfWork.ModuloMaestros.GetIdAsync(id);
            if (moduloMaestros == null){
                return NotFound();
            }
            _UnitOfWork.ModuloMaestros.Remove(moduloMaestros);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
    }
}