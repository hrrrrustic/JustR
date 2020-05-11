using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using JustR.Desktop.Commands;
using JustR.Desktop.View;
using JustR.Models.Dto;
using JustR.Models.Entity;

namespace JustR.Desktop.ViewModel
{
    public class UserDialogsViewModel : BaseViewModel
    {
        public ObservableCollection<DialogPreviewDto> DialogsPreview { get; set; }= new ObservableCollection<DialogPreviewDto>
        {
            new DialogPreviewDto
            {
                DialogName = "Dialog 1",
                LastMessageText = "Message 1",
                LastMessageTime = new DateTime(2020, 1, 14, 3, 14, 4)
            },
            new DialogPreviewDto
            {
                DialogName = "Dialog 2",
                LastMessageText = "Message 1",
                LastMessageTime = new DateTime(2020, 2, 15, 4, 15, 5)
            },
            new DialogPreviewDto
            {
                DialogName = "Dialog 3",
                LastMessageText = "Message 1",
                LastMessageTime = new DateTime(2020, 3, 16, 5, 16, 6)
            },
        };

        public ICommand Test => new ActionCommand(() => CurrentDialog = new DialogPage());

        private Page _currentDialog = new DialogEmptyPage();
        public Page CurrentDialog
        {
            get => _currentDialog;
            set
            {
                _currentDialog = value;
                OnPropertyChanged();
            }
        }
    }
}