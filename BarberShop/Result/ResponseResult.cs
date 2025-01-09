

namespace BarberShop.Result
{
    public class ResponseResult
    { 
        public dynamic? data { get; set; }    
        public bool success { get; set; }   
        public string? message { get; set; }
        public ResponseResult() { this.success = true; }

    }
}
