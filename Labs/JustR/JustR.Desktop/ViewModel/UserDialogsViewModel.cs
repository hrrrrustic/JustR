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