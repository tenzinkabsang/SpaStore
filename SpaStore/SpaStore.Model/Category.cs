using System;
using System.Collections.Generic;

namespace SpaStore.Model
{
    public class Category : CategoryBrief, IAuditInfo
    {
        public IList<Product> Products { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}