﻿namespace Talabat.API.Helpers
{
    public class PaginationResponse<T>
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int TotalCount { get; set; }
        public IReadOnlyList<T> Data { get; set; }
        public PaginationResponse(int pageSize,int pageIndex,int totalCount,IReadOnlyList<T> data) 
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            TotalCount = totalCount;
            Data = data;
        }
    }
}
