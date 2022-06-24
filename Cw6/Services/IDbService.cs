using Cw6.Models;
using Cw6.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cw6.DataAccess
{
    public interface IDbService
    {
        Task<IList<SomeKindOfDoctor>> GetDoctors();
        Task<bool> AddDoctor(SomeKindOfDoctor someKindOfDoctor);
        Task<bool> UpdateDoctor(int idDoctor, SomeKindOfDoctor someKindOfDoctor);
        Task<bool> RemoveDoctor(int idDoctor);
        Task<SomePrescription> GetPrescription(int id);
    }
}
