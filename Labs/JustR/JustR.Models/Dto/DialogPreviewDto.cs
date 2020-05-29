using System;
using System.Collections.Generic;
using System.Text;
using JustR.Models.Entity;

namespace JustR.Models.Dto
{
    public class DialogPreviewDto
    {
        public Guid DialogId { get; set; }
        public DateTime LastMessageTime { get; set; }
        public String LastMessageText { get; set; }
        public UserPreviewDto InterlocutorPreview { get; set; }

        public void SetInterlocutorByUser(User user)
        {   
            InterlocutorPreview = UserPreviewDto.FromUser(user);
        }
    }
}
