using AutoMapper;
using BLL.DTO;
using DAL.Entities;
namespace BLL;

/// <summary> Профіль конвертації EF сутностей та DTO класів. </summary>
public class EntityProfile : Profile
{
    public EntityProfile()
    {
        #region User

        CreateMap<User, UserDTO>()
            .ReverseMap();

        #endregion
    }
}
