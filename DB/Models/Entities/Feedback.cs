using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Models.Entities.Abstarction;

namespace DB.Models.Entities
{
    public enum FeedbackMark
    {
        Terrible = 0,
        Bad,
        Common,
        Good,
        Great
    }
    public class Feedback : DbItem<int>
    {
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public FeedbackMark Mark { get; set; }
    }
}
