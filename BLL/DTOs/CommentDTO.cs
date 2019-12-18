using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    class CommentDTO
    {
        public int Int { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public string Text { get; set; }
    }
}
