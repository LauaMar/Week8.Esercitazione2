using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8.Es1.Core.Models
{
   public class ResultBL
    {
       public bool Success { get; set; }
        public string Message { get; set; }
        public Exception InnerException { get; set; }

        public ResultBL(bool success, string message, Exception ex = null)
        {
            Success = success;
            Message = message;
            InnerException = ex;
        }
    }
}
