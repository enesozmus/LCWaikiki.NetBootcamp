using System.Text.Json.Serialization;

namespace FirstWebAPI.ViewModels
{
    // Özelleştirilmiş status codes
    public class CustomResponseDto<T>
    {
        public T Data { get; set; }

        [JsonIgnore]            // swagger'da durum kodu zaten dönüyor, body'e ekleme
        public int StatusCode { get; set; }


        public IEnumerable<String> Errors { get; set; }


        public static CustomResponseDto<T> Success(int statusCode, T data)
        {
            return new CustomResponseDto<T> { Data = data, StatusCode = statusCode};
        }
        public static CustomResponseDto<T> Success(int statusCode)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode };
        }

        public static CustomResponseDto<T> Fail(int statusCode, List<string> errors)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = errors };
        }

        public static CustomResponseDto<T> Fail(int statusCode, string error)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }
    }
}
