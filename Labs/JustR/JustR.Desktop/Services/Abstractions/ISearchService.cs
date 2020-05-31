﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Documents;
using JustR.Core.Dto;

namespace JustR.Desktop.Services.Abstractions
{
    public interface ISearchService
    {
        Task<List<UserPreviewDto>> FindUsersByTagAsync(String query);
    }
}