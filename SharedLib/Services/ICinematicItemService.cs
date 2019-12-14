using SharedLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.Services
{
    public interface ICinematicItemService
    {
        Task<List<CinematicItem>> Get();
        Task<CinematicItem> Get(int id);
        Task<CinematicItem> Add(CinematicItem cinematicItem);
        Task<CinematicItem> Update(CinematicItem cinematicItem);
        Task<CinematicItem> Delete(int id);
    }
}
