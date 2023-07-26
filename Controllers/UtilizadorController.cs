using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartSchool_WebApi.Models;
using SmartSchool_WebApi.Data;
using SmartSchool_WebApi.dto;

namespace SmartSchool_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UtilizadorController : ControllerBase
    {
        public IRepository _repo { get; }

        public static string Utilizador => utilizador;

        const string utilizador = null;
        const string nao_aprovado = "nao_aprovado";
        const string aprovado = "aprovado";
        public UtilizadorController(IRepository _repo)
        {
            this._repo = _repo;

        }


        //Metodo post ,metdo para cadastrar utilizador
        [HttpPost]
        public async Task<IActionResult> Post(Utilizador model)
        {
            System.Console.WriteLine("ok");
            try
            {
                // criar um repositorio para guardar na bd 
                model.funcao = utilizador;
                model.estado = nao_aprovado;
                //CalculateMD5Hash(model.Senha);
                //return Ok(CalculateMD5Hash(model.senha));
                model.senha = emcreptarSenha(model.senha);
                _repo.Add(model);
                //save na base de dados
                var result = await _repo.SaveChangesAsync();
                //se salvar alguma coisa retornar com sucesso
                if (result)
                {

                    return Ok(result);

                }
                else
                {
                    // returna um erro
                    return BadRequest();
                }

            }
            catch (System.Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");

            }

        }
        //Funcao para encrepitar password
        private string emcreptarSenha(string senha)
        {
            try
            {
                System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(senha);
                byte[] hash = md5.ComputeHash(inputBytes);
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                return sb.ToString(); // Retorna senha criptografada 
            }
            catch (Exception)
            {
                return null; // Caso encontre erro retorna nulo
            }
        }

        //API listagem
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {

                System.Console.WriteLine("okkkv");

                // se adecionar falso  retorna somente alunos, se passar falso dentro metodo
                //GetAllAlunosAsync() nao vai fazer join nem com AlunosDisciplinas ,discipliena e professor
                // return Ok(result,"Jair");
                // var result = await _repo.GetAllUtilizadoresAsync(false);
                var result = await _repo.GetAllUtilizadoresAsync();
                // return Ok(result,"Jair");
                return Ok(result);
            }

            catch (System.Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");

            }

        }

        //Metudo put metudo para atualizar funcao de Utilizador
        [HttpPut("{utilizadorId}")]
        public async Task<IActionResult> put(int utilizadorId, UpdateFuncaoDto model)
        {
            try
            {  // model.funcao="admin";
               // System.Console.WriteLine(utilizadorId);
               // return Ok(model.funcao+utilizadorId);
                var utilizador = await _repo.GetUtilizadorAsyncById(utilizadorId);


                if (utilizador == null || model.funcao == "")
                {
                    return NotFound();

                }

                utilizador.funcao = model.funcao;

                // //  pegar id de url atribuir ao model
                //     model.id = alunoId;

                // return Ok(utilizador);

                _repo.Update(utilizador);

                if (await _repo.SaveChangesAsync())
                {
                    //return Ok("ok");
                    return Ok(true);

                }

            }

            catch (System.Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");

            }

            return BadRequest();


        }

        //Metodo para aprovar utilizador
        [HttpPut("aprovar/{utilizadorId}")]
        public async Task<IActionResult> aprovarUtilizador(int utilizadorId)
        {
            try
            {
                var utilizador = await _repo.GetUtilizadorAsyncById(utilizadorId);

                if (utilizador.funcao != null)
                {
                    // return Ok("ok"+ utilizador.nome);
                    utilizador.estado = aprovado;
                    //fazes update de estado
                    _repo.Update(utilizador);

                    if (await _repo.SaveChangesAsync())
                    {
                        return Ok(utilizador);
                    }

                }
                else
                {
                    BadRequest($"Error: erro");
                }

            }

            catch (System.Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");

            }

            return BadRequest();


        }


        //Metodo para desativar utilizador
        [HttpPut("desativar/{utilizadorId}")]
        public async Task<IActionResult> desativarUtilizador(int utilizadorId)
        {

            try
            {
                var utilizador = await _repo.GetUtilizadorAsyncById(utilizadorId);
                utilizador.estado = nao_aprovado;
                _repo.Update(utilizador);

                if (await _repo.SaveChangesAsync())
                {

                    return Ok(utilizador);
                }
            }

            catch (System.Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");

            }

            return BadRequest();




        }
        // Metodo para fazer login 
        [HttpPost("login")]
        public async Task<IActionResult> login(LoginDto model)
        {
            try
            {
                model.senha = emcreptarSenha(model.senha);
                //System.Console.WriteLine("ok");
                var login = await _repo.GetEmailPasswordAsync(model.senha, model.email);
                // login.senha= "";
                  var lo= new Utilizador();
                  lo.id=login.id;
                  lo.nome=login.nome;
                  lo.email=login.email;
                  lo.estado=login.estado;
                  lo.funcao=login.funcao;
            
                System.Console.WriteLine(login?.id);

                if (lo?.estado == "aprovado")
                {

                    return Ok(lo);
                }

                else
                {

                    BadRequest($"Error: Utilizador ou Palavra Passe incorreto");
                }

            }
            catch (System.Exception ex)
            {
                // TODO
                return BadRequest($"Error: {ex.Message}");

            }


            return BadRequest();


        }

    }
}