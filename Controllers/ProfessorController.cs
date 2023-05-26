using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartSchool_WebApi.Data;
using SmartSchool_WebApi.Models;

namespace SmartSchool_WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ProfessorController : ControllerBase
    {
        public readonly IRepository _repo;

        public ProfessorController(IRepository repo)
        {


            _repo = repo;


        }

        //Metodo que lista os professores e os respectivo disciplina
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllProfessoresAsync(true);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");

            }
        }
        // Metodo que retorna professor e os sus respectivo desciplina
        [HttpGet("{professorId}")]
        public async Task<IActionResult> GetByProfessorId(int professorId)
        {
            try{
                var result = await _repo.GetProfessorAsyncById(professorId, true);

                return Ok(result);

            }
            catch (System.Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");

            }

        }

        [HttpGet("ByAluno/{alunoId}")]
        public async Task<IActionResult> GetByAlunoId(int alunoId)
        {

            try
            {

                var result = await _repo.GetProfessoresAsyncByAlunoId(alunoId, false);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");

            }
        }

        //Metodo post ,metdo para inserir professor
        [HttpPost]
        public async Task<IActionResult> Post(Professor model)
        {

            try
            {
                _repo.Add(model);

                //se salvar alguma coisa retornar com sucesso
                if (await _repo.SaveChangesAsync())
                {

                    return Ok(model);

                }

            }
            catch (System.Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");

            }
            return BadRequest();

        }
        //Metudo put metudo para atualizar alunos
        [HttpPut("{professorId}")]
        public async Task<IActionResult> put(int professorId, Professor model)
        {
            try
            {

                var aluno = await _repo.GetProfessorAsyncById(professorId, false);

                if (aluno == null) return NotFound();
                //  pegar id de url atribuir ao model
                model.id = professorId;

                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                {
                    //return Ok("ok");
                    return Ok(model);

                }

            }

            catch (System.Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");

            }

            return BadRequest();

        }

        //Metodo para pagar professor
        [HttpDelete("{professorId}")]
         
        public async Task<IActionResult> delete(int professorId)
        { 
            try
            {  
                var professsor = await _repo.GetProfessorAsyncById(professorId,false);
                if (professsor == null) return NotFound();

                _repo.Delete(professsor);
                if (await _repo.SaveChangesAsync())
                {
                    return Ok(new {message=" Professor Deletado"});

                }
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");

            }

            return BadRequest();


        }



    }
}