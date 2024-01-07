using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //Bu sınıf encapsulation yapmak için var 
        //Constractır 


        public Result(bool success, string message) : this(success) // : işaretinden sonra diyoruzki git success rsesultıda çalıştır
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }

        //Yukarıdaki kod aşağıdakinin iyileştirilmiş halidir. Aşağıdaki kod hem tek parametre hemde iki parametreyi karşılamak için yazıldı. O yğzden iki tane aynı method farklı parametrelerle oluşturuldu
        //public Result(bool success, string message)
        //{
        //    Success = success;
        //    Message = message;
        //}
        //public Result(bool success)
        //{
        //    Success = success;
        //}



        public bool Success { get; }
        public string Message { get; }
    }
}
