﻿namespace InSharpAssessment.Services.Models.ServiceDTOs
{

    public class PagedServiceDTO<T>
    {
        public int Total { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int? PreviousPage { get; set; }
        public int? NextPage { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
