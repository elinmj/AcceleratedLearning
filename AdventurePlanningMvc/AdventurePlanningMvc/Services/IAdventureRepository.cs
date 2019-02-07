using AdventurePlanningMvc.Models;
using System.Collections.Generic;

namespace AdventurePlanningMvc.Services
{
    public interface IAdventureRepository
    {
        List<Adventure> GetAll();
        Adventure GetById(int id);
        void Add(Adventure adv);
        void GetLocation(string location);

    }
}