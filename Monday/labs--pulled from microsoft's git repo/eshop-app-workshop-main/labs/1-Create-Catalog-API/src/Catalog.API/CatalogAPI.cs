using Catalog.API.Model;
using eShop.Catalog.Data;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.AspNetCore.Builder
{
    public static class CatalogAPI
    {
        public static IEndpointRouteBuilder MapCatalogApi(this IEndpointRouteBuilder app)
        {
            app.MapGet("/items", async ([AsParameters] PaginationRequest paginationRequest, CatalogDbContext db) =>
            {
                var pageSize = paginationRequest.PageSize;
                var pageIndex = paginationRequest.PageIndex;

                var count = await db.CatalogItems.LongCountAsync();

                var data = await db.CatalogItems
                                    .OrderBy(i => i.Name)
                                    .Skip(pageIndex * pageSize)
                                    .Take(pageSize)
                                    .AsNoTracking()
                                    .ToListAsync();

            return new PaginatedItems<CatalogItem>(pageIndex, pageSize, count, data);
            });
            return app;
        }
    }
}
