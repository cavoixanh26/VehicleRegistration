namespace VRP.API.ViewModels.BaseDtos
{
    public class BasePagingRequest
    {
        public string? KeyWords { get; set; }
        public int Page { get; set; } = 1;
        public int ItemsPerPage { get; set; } = 5;
        public int Skip => (Page - 1) * ItemsPerPage;
        public int Take { get => ItemsPerPage; }
        public string? SortField { get; set; }
    }
}
