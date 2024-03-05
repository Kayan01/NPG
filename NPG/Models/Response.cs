namespace NPG.Models
{
    
        public class Response<T>
        {
            public T Data { get; set; }
            public bool IsSuccess { get; set; }
            public string ErrorMessage { get; set; }
            public int StatusCode { get; set; }


            public static Response<T> Success(T data, int statusCode = StatusCodes.Status200OK)
            {
                return new Response<T>
                {
                    Data = data,
                    StatusCode = statusCode,
                    IsSuccess = true
                };
            }

            public static Response<T> Failed(string errorMessage, int statusCode = StatusCodes.Status400BadRequest)
            {
                return new Response<T>
                {
                    StatusCode = statusCode,
                    IsSuccess = false,
                    ErrorMessage = errorMessage
                };
            }
        }
    }

