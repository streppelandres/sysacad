
namespace Application.Wrappers
{
    public class ResponseWrapper<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }

        public ResponseWrapper()
        {

        }

        public ResponseWrapper(string message)
        {
            Success = false;
            Message = message;
        }

        public ResponseWrapper(T data, string message = null)
        {
            Success = true;
            Message = message;
            Data = data;
        }
    }
}
