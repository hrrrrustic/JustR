using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using JustR.Models.Dto;
using JustR.Models.Entity;

namespace JustR.Desktop.ViewModel
{
    public class UserDialogsViewModel
    {
        public ObservableCollection<DialogPreviewDto> DialogsPreview { get; set; }= new ObservableCollection<DialogPreviewDto>
        {
            new DialogPreviewDto
            {
                DialogName = "Dialog 1"
            },
            new DialogPreviewDto
            {
                DialogName = "Dialog 2"
            },
            new DialogPreviewDto
            {
                DialogName = "Dialog 3"
            },
        };
    }
}