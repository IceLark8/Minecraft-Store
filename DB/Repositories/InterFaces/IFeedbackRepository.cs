using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.Entities;

namespace DAL.Repositories.InterFaces
{
    public interface IFeedbackRepository : IBaseRepository<Feedback, int>
    {
    }
}
