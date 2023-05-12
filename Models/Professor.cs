using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool_WebApi.Models
{
    public class Professor
    {
       public int id { get; set;}
       public string? nome { get; set;}
       public IEnumerable<Disciplina>? Disciplina { get; set; } 

         public Professor()
         {
            
         }
        public Professor(int id,string nome) 
        {
            this.id = id;
            this.nome=nome;
            
        }
    

    }
}