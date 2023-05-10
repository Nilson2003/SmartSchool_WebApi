using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool_WebApi.Models
{
    public class AlunoDisciplina
    {
        
       public int alunoId { get; set;}
       public int disciplinaId { get; set;}
       public Aluno? aluno { get; set;}
       public Disciplina? disciplina { get; set; } 

       public AlunoDisciplina()
       {
        
       }


        public AlunoDisciplina(int alunoId,int disciplinaId) 
        {
            this.alunoId = alunoId;
            this.disciplinaId=disciplinaId;
           

        }
    }
}