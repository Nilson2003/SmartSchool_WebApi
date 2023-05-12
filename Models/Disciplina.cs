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
       public int  professorId { get; set; } 
       public IEnumerable<Professor> Professor { get; set; } 





        
        public  Disciplina(int id,string nome, int professorId) 
        {
            this.id = id;
              this.nome = nome;
                this.professorId = professorId;
                 
        }
    }



     
       
}