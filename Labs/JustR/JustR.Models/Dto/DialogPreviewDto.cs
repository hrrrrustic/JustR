using System;
using System.Collections.Generic;
using System.Text;

namespace JustR.Models.Dto
{
    public class DialogPreviewDto
    {
        public String DialogName { get; set; }
        public DateTime LastMessageTime { get; set; }
        public String LastMessageText { get; set; }
        public UserPreviewDto InterlocutorPreview { get; set; }
    }
}
