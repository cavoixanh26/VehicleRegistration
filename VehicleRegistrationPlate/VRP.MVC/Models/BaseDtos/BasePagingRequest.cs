﻿namespace VRP.MVC.Models.BaseDtos
{
    public class BasePagingRequest
    {
        public string? KeyWords { get; set; }
        public int Page { get; set; } = 1;
        public int ItemsPerPage { get; set; } = 2;
        public int Skip => (Page - 1) * ItemsPerPage;
        public int Take { get => ItemsPerPage; }
        public string? SortField { get; set; }
    }
}
