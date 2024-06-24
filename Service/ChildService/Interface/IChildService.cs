using Core.Entites;
using Service.ChildService.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ChildService.Interface
{
    public interface IChildService
    {
        Task<ICollection<ChildDto>> GetChildrenAsync(string email);
        Task<ChildDetailsDto> GetChildByIdAsync(int id, string email);
        Task<bool> AddChild(ChildResultDto childDto, string email);
        Task<bool> DeleteChildAsync(int id);
        Task<bool> UpdateChildAsync(ChildDto childDto, string email);

        Task<bool> AddAllergisAsync(ChildAllergisDto childAllergis);
        Task<bool> DeleteAllergisAsync(ChildAllergisDto childAllergis);
        Task<bool> AddMedicalConditionAsync(ChildMedicalConditionDto childAllergis);
        Task<bool> DeleteMedicalConditionAsync(ChildMedicalConditionDto childAllergis);


        Task<ChildAllergisViewModel> GetChildAllergisByIdAsync(int id, string email);
        Task<ChildMedicalConditionViewModel> GetChildMedicalConditionsByIdAsync(int id, string email);

        Task<int> AddChildToCampAsync(ChildCampDto childCampDto);
        Task<bool> DeleteChildFromCamp(ChildCampDto childCampDto);






    }
}
