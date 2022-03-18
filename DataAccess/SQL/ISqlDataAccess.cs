using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface ISqlDataAccess
    {
        Task<List<T>> GetDataAsync<T, U>(string cmd, U parameter);
        Task<List<T>> GetDataAsync<T>(string cmd);
        Task GiveDataAsync<T>(string cmd, T parameter);
    }
}