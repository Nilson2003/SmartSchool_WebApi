using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartSchool_WebApi.Data;
using SmartSchool_WebApi.Models;

namespace SmartSchool_WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class AlunoController : ControllerBase
    {
        public IRepository _repo { get; }
        public AlunoController(IRepository repo)
        {
            _repo = repo;

        }

         //API listagem
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            { // se adecionar falso  retorna somente alunos, se passar falso dentro metodo
            //GetAllAlunosAsync() nao vai fazer join nem com AlunosDisciplinas ,discipliena e professor
            // No caso for adecionado false deve retornar somente alunos
                var result = await _repo.GetAllAlunosAsync(false);
                return Ok(result);
            }
            
            catch (System.Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");

            }

        }

        [HttpGet("{AlunoId}")]
        public async Task<IActionResult> GetByAlunoId(int alunoId)
        {
            try
            {
                var result = await _repo.GetAlunoAsyncById(alunoId, true);
                
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");

            }

        }

        [HttpGet("ByDisciplina/{disciplinaId}")]
        public async Task<IActionResult> GetByDisciplinaId(int disciplinaId)
        {

            //return Ok("okkk");
            try
            { //pega todos os alunos que estao matriculado a um determinado desciplina,para pegar 
             //somente aluno adecionana falso no metodo GetAlunosAsyncByDisciplinaId(disciplinaId, false)  
                var result = await _repo.GetAlunosAsyncByDisciplinaId(disciplinaId, false);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");

            }

        }

        //Metodo post ,metdo para inserir alunos
        [HttpPost]
        public async Task<IActionResult> Post(Aluno model)
        {
           System.Console.WriteLine("ok");
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
        [HttpPut("{alunoId}")]
        public async Task<IActionResult> put(int alunoId, Aluno model)
        {
            try
            {
             
                var aluno = await _repo.GetAlunoAsyncById(alunoId, false);

                if (aluno == null) return NotFound();
                   //  pegar id de url atribuir ao model
                   model.id=alunoId;

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

        //Metudo delete, metudo para apagar  alunos registado
        [HttpDelete("{alunoId}")]
        public async Task<IActionResult> delete(int alunoId, Aluno model)
        {
            try
            {
                //_repo.Add(model);
                var aluno = await _repo.GetAlunoAsyncById(alunoId, false);

                if (aluno == null) return NotFound();
               
                    _repo.Delete(aluno);
                  
                //aqui salva aluno deletado
                if (await _repo.SaveChangesAsync())
                {
                   //mostra que o aluno foi deletado
                    return Ok("Aluno Deletado");

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