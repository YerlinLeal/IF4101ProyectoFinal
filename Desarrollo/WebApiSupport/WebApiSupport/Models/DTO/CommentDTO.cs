using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiSupport.Models.DTO
{
    public class CommentDTO
    {
        public int comment_Id { get; set; }
        public string description { get; set; }
        public DateTime? comment_Timestamp { get; set; }
        public int report_Number { get; set; }
        public bool state { get; set; }
        public DateTime? creation_Date { get; set; }
        public DateTime? modify_Date { get; set; }
        public int? created_By { get; set; }
        public int? modified_By { get; set; }

        public CommentDTO()
        {

        }
        
    }
}
