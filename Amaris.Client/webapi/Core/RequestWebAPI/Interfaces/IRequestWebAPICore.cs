using Amaris.WebAPI.Models;
using System.Net;

namespace Amaris.WebAPI.Core.RequestWebAPI.Interfaces
{
    public interface IRequestWebAPICore
    {
        Task<string> CallApi();
        Task<string> CallApi(string idEmployee);
    }
}
