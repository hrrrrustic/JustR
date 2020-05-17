using System;
using System.Collections.ObjectModel;
using JustR.Models.Dto;

namespace JustR.Desktop.ViewModel
{
    public class DialogViewModel
    {
        public ObservableCollection<MessageDto> Messages { get; set; } = new ObservableCollection<MessageDto> 
        {
            new MessageDto
            {
                MessageText = "Message 1",
                SendDate = DateTime.MinValue
            },
            new MessageDto
            {
                MessageText = "Message 2",
                SendDate = DateTime.MaxValue
            }
        };
    }
}