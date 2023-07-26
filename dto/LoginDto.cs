using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool_WebApi.dto
{
    public class LoginDto
    {
    public  string email { get; set; }
    public  string  senha { get; set; }


      public LoginDto( string email, string  senha ){

        this.senha=senha;
        this.email=email;
      }
    

    }
}