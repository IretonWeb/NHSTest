namespace NHSTest.Application.ResponseModels;

public class GenericResponseModel
{
    public bool Success { get; set; }
    public List<string> Errors { get; set; }
    public object Data { get; set; }

    public static GenericResponseModel Succeeded()
    {
        return new GenericResponseModel() { Success = true };
    }

    public static GenericResponseModel<T> Succeeded<T>(T data)
    {
        return new GenericResponseModel<T>() { Success = true, Data = data };
    }

    public static GenericResponseModel Failed(string error)
    {
        return new GenericResponseModel() { Success = false, Errors = new List<string>() { error } };
    }

    public static GenericResponseModel Failed(List<string> errors)
    {
        return new GenericResponseModel() { Success = false, Errors = errors };
    }

    public static GenericResponseModel<T> Failed<T>(string error, T data)
    {
        return new GenericResponseModel<T>() { Success = false, Errors = new List<string>() { error }, Data = data };
    }


}

public class GenericResponseModel<T> : GenericResponseModel
{
    public new T Data { get; set; }
}


