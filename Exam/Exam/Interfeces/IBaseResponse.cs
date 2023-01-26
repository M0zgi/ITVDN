namespace Exam.Interfeces
{
    public interface IBaseResponse <out T>
    {
        T Data { get; }
        ResultStatusCode Status { get; set; }
    }

    public enum ResultStatusCode
    {
        Ok = 200,
        NotFound = 404,
        Error = 500
    }
}
