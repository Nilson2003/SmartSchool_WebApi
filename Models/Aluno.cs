using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool_WebApi.Models
{
    public class Aluno
    { 
       // public  int MyProperty {get,set};

              
       public int id { get; set;}
       public string nome { get; set;}
       public string sobrenome { get; set; } 
       public int telefone { get; set; }
    
      
    public Aluno(int id , string nome,string sobrenome, int telefone) 
    {
            this.id=id;
            this.nome=nome;
             this.sobrenome=sobrenome;
            this.telefone = telefone;
   
    }
        
    }
}