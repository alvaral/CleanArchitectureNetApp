﻿

namespace CleanArchitecture.Domain.Common
{
    public class BaseDomainModel
    {
        public int Id { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public string? LastModifiedBy { get; set; }
    }
}
