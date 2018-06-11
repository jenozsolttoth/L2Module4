using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HackathonService.Logic
{
    public interface ITeamManager
    {
        Task<string[]> AllAsync();
        Task<string> GetAsync(string challenge, string task, string team);
    }
}