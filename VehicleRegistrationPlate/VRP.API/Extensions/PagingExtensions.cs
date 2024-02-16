using System.Linq;
using VRP.API.ViewModels.BaseDtos;

namespace VRP.API.Extensions
{
    public static class PagingExtensions
    {
        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> pagingList, BasePagingRequest paging) => pagingList.Skip(paging.Skip).Take(paging.Take);

        public static PagingResponseInfo GetPagingResponse(this BasePagingRequest request, int totalRecord)
        {
            return new PagingResponseInfo
            {
                CurrentPage = request.Page,
                ItemsPerPage = request.ItemsPerPage,
                ToTalPage = (totalRecord / request.ItemsPerPage) + ((totalRecord % request.ItemsPerPage) == 0 ? 0 : 1),
                ToTalRecord = totalRecord
            };
        }
    }
}
