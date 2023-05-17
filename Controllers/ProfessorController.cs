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

        public class ProfessorController : ControllerBase
    {
       public readonly IRepository _repo;
       
       public ProfessorController(IRepository repo )
       {


           _repo=repo;


       }
       
       
        [HttpGet]
        public async Task<IActionResult> Get()
        {
          try
          {   
            var result= _repo.GetAllProfessoresAsync(true);
            
            return Ok(result);
          }
          catch (Exception ex)
          {
            
          return BadRequest($"Error: {ex.Message}");
          
        }
      }

       //Metodo post ,metdo para inserir professor
        [HttpPost]
        public async Task<IActionResult> Post(Professor model)
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
        [HttpPut("{professorId}")]
        public async Task<IActionResult> put(int professorId, Professor model)
        {
            try
            {
             
                var aluno = await _repo.GetProfessorAsyncById(professorId, true);

                if (aluno == null) return NotFound();
                   //  pegar id de url atribuir ao model
                   model.id=professorId;

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


    }    
}