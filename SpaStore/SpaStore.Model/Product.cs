using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaStore.Model
{
    public class Product: ProductBrief, IAuditInfo
    {
        public Category Category { get; set; }

        public virtual IList<Image> Images { get; set; }

        public bool IsActive { get; set; }

        //public string PrimaryUrl
        //{
        //    get
        //    {
        //        if (Images != null && Images.Any(image => image.IsPrimary))
        //            return Images.First(image => image.IsPrimary).Url;

        //        return string.Empty; // some default image url
        //    }
        //}

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}