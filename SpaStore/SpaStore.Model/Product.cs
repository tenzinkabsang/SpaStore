using System;
using System.Collections.Generic;

namespace SpaStore.Model
{
    public class Product: ProductBrief, IAuditInfo
    {
        public Category Category { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}