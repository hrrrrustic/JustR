using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Accessibility;
using JustR.Desktop.Services.Abstractions;
using JustR.Desktop.Services.Implementations;
using JustR.Models.Dto;

namespace JustR.Desktop.ViewModel
{
    public class SearchViewModel : BaseViewModel
    {
        private readonly ISearchService _searchService = new DummySearchService();

        public SearchViewModel()
        {
        }
        
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