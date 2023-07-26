using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool_WebApi.dto
{
    public class UpdateFuncaoDto
    {
      public  string funcao  { get; set; }


      public  UpdateFuncaoDto( string funcao){

        this.funcao=funcao;
      }
    }


}