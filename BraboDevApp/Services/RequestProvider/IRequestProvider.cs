namespace BraboDevApp.Services.RequestProvider
{
    public interface IRequestProvider
    {
        Task<TResult> PostAsync<TResult, TSend>(string uri, TSend data, string token = "");
    }
}
