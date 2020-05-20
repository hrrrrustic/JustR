using System.Collections.ObjectModel;
using JustR.Models.Dto;

namespace JustR.Desktop.ViewModel
{
    public class SearchViewModel : BaseViewModel
    {
        public ObservableCollection<UserPreviewDto> Users { get; set; } = new ObservableCollection<UserPreviewDto>
        {
            new UserPreviewDto
            {
                UniqueTag = "@Test1",
                UserName = "User 1"
            },
            new UserPreviewDto
            {
                UniqueTag = "@Test2",
                UserName = "User 2"
            }
        };
    }
}