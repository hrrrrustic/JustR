using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Accessibility;
using JustR.Desktop.Commands;
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
            SearchCommand = new ActionCommand<String>(async arg =>
            {
                Users.Clear();
                await _searchService
                    .FindUsersByTagAsync(arg)
                    .ContinueWith(task =>
                    {
                        foreach (UserPreviewDto user in task?.Result)
                        {
                            Users.Add(user);
                        }
                    }, TaskScheduler.FromCurrentSynchronizationContext());
            });
        }

        public ICommand SearchCommand { get; set; }

        public ObservableCollection<UserPreviewDto> Users { get; set; } = new ObservableCollection<UserPreviewDto>();
    }
}