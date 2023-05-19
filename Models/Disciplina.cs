using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool_WebApi.Models
{
    public class Disciplina
    {
        
       public int id { get; set;}
       public string nome { get; set;}
       public int  ProfessorId { get; set; }  
       public Professor? Professor { get; set; } 
       
       public IEnumerable<AlunoDisciplina>?AlunoDisciplinas {get;set;}





        
        public  Disciplina(int id,string nome, int professorId) 
        {
            this.id = id;
            this.nome = nome;
            this.ProfessorId = professorId;
                 
        }
    }



     
       
}