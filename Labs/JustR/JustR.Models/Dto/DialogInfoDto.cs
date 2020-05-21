using System;
using System.Collections.Generic;
using System.Text;

namespace JustR.Models.Dto
{
    public class DialogInfoDto
    {
        public Guid DialogId { get; set; }
        
        public String DialogName { get; set; }
        public UserPreviewDto Interlocutor { get; set; }
        
    }
}
