using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface ICrudService<TEntityDTO> where TEntityDTO : class, new()
    {
        Task<TEntityDTO> Get(int id);

        Task<IEnumerable<TEntityDTO>> GetAll();

        Task Add(TEntityDTO dto);

        Task<TEntityDTO> Update(TEntityDTO dto);

        Task Delete(int id);
    }
}
