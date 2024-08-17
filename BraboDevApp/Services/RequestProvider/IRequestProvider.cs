namespace BraboDevApp.Services.RequestProvider
{
    public interface IRequestProvider
    {
        Task<TResult> PostAsync<TResult, TSend>(string uri, TSend data, string token = "");
        Task<TResult> GetAsync<TResult>(string uri, string token = "");
    }
}
