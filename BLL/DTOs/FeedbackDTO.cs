using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public enum FeedbackMark
    {
        Terrible = 0,
        Bad,
        Common,
        Good,
        Great
    }
    class FeedbackDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public FeedbackMark Mark { get; set; }
    }
}
