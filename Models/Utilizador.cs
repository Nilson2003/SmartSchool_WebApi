using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool_WebApi.Models
{
    [AttributeUsage(AttributeTargets.Property,
    Inherited = false,
    AllowMultiple = false)]
    internal sealed class OptionalAttribute : Attribute { }

    public class Utilizador
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        [Optional]
        public string? estado { get; set; }
        [Optional]
        public string? funcao { get; set; }


           public Utilizador(){}
            
        // public Utilizador( int id ,string nome, string email, string? estado, string? funcao)
        // {   
        //     this.id=id;
        //     this.nome = nome;
        //     this.email = email;
        //     this.estado = estado;
        //    // this.senha="";
        //     this.funcao = funcao;

        // }
    public Utilizador(int id ,string nome, string email, string senha, string? estado, string? funcao)
        {
            this.id=id;
            this.nome = nome;
            this.email = email;
            this.senha = senha;
            this.estado = estado;
            this.funcao = funcao;

        }
         
        public Utilizador(string nome, string email, string senha, string? estado, string? funcao)
        {
            this.nome = nome;
            this.email = email;
            this.senha = senha;
            this.estado = estado;
            this.funcao = funcao;

        }
    }
}