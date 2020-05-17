using System;
using System.Collections.Generic;
using System.Text;

namespace JustR.Models.Dto
{
    public class DialogInfoDto
    {
        public String DialogName { get; set; }
        public List<MessageDto> Messages { get; set; }
    }
}
