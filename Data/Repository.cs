using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartSchool_WebApi.Models;

namespace SmartSchool_WebApi.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Aluno[]> GetAllAlunosAsync(bool includeDisciplina = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeDisciplina)
            {
                query = query.Include(pe => pe.AlunosDisciplinas)
                             .ThenInclude(ad => ad.disciplina)
                             .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking()
                         .OrderBy(c => c.id);

            return await query.ToArrayAsync();
        }
        public async Task<Aluno> GetAlunoAsyncById(int alunoId, bool includeDisciplina)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeDisciplina)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                             .ThenInclude(ad => ad.disciplina)
                             .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking()
                         .OrderBy(aluno => aluno.id)
                         .Where(aluno => aluno.id == alunoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Aluno[]> GetAlunosAsyncByDisciplinaId(int disciplinaId, bool includeDisciplina)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeDisciplina)
            {
                query = query.Include(p => p.AlunosDisciplinas)
                             .ThenInclude(ad => ad.disciplina)
                             .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking()
                         .OrderBy(aluno => aluno.id)
                         .Where(aluno => aluno.AlunosDisciplinas.Any(ad => ad.disciplinaId == disciplinaId));

            return await query.ToArrayAsync();
        }

        public async Task<Professor[]> GetProfessoresAsyncByAlunoId(int alunoId, bool includeDisciplina)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeDisciplina)
            {
                query = query.Include(p => p.Disciplina);
            }

            query = query.AsNoTracking()
                         .OrderBy(aluno => aluno.id)
                         ////////////////////////////////////////      ////////////////////////////// /////////////////////////////////////////
                         .Where(aluno => aluno.Disciplina.Any(d =>
                            d.AlunoDisciplinas.Any(ad => ad.alunoId == alunoId)));

            return await query.ToArrayAsync();
        }

        public async Task<Professor[]> GetAllProfessoresAsync(bool includeDisciplinas = true)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeDisciplinas)
            {
                query = query.Include(c => c.Disciplina);
            }

            query = query.AsNoTracking()
                         .OrderBy(professor => professor.id);

            return await query.ToArrayAsync();
        }
        public async Task<Professor> GetProfessorAsyncById(int professorId, bool includeDisciplinas = true)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeDisciplinas)
            {
                query = query.Include(pe => pe.Disciplina);
            }

            query = query.AsNoTracking()
                         .OrderBy(professor => professor.id)
                         .Where(professor => professor.id == professorId);

            return await query.FirstOrDefaultAsync();
        }

        public Task GetAlunoAsyncById(bool v)
        {
            throw new NotImplementedException();
        }

        public async Task<Utilizador[]> GetAllUtilizadoresAsync()
        {

            var utilisadores = await _context.Utilizadores.Select(u => new Utilizador(u.id, u.nome, u.email, "", u.estado, u.funcao)).ToArrayAsync();

            return utilisadores;

        }
        //
        public async Task<Utilizador> GetUtilizadorAsyncById(int utilizadorId)
        {

            var utilizador = await _context.Utilizadores.SingleAsync(u => u.id == utilizadorId);

            return utilizador;
        }


         public async Task<Utilizador> GetEmailPasswordAsync( string password,string email){


             var utilizadorEmailSenha = await _context.Utilizadores.FirstAsync(u=>u.email==email && u.senha==password );
           System.Console.WriteLine("ok");
               return utilizadorEmailSenha;
         }



//  public string Decrypt(string cipher)
//     {
//         if (cipher == null) throw new ArgumentNullException("cipher");

//         //parse base64 string
//         byte[] data = Convert.FromBase64String(cipher);

//         //decrypt data
//         byte[] decrypted = ProtectedData.Unprotect(data, null, Scope);
//         return Encoding.Unicode.GetString(decrypted);
//     }
//    public string decryptPassword(string senha){

//           if(string.IsNullOrEmpty(senha)){
//             return null;
//           }
//           else{
//                 byte[] encryptedPassword= Converter(senha);
//           }

//        }

    }
}
    