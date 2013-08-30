using System.Collections.Generic;
using System.Linq;

namespace SpaStore.Model
{
    public class ProductDto : ProductBrief
    {
        public IEnumerable<ImageDto> Images { get; set; }

        public bool IsActive { get; set; }

        private string _primaryUrl;
        public override string PrimaryUrl
        {
            get
            {
                if (!string.IsNullOrEmpty(_primaryUrl))
                    return _primaryUrl;

                return Images != null && Images.Any(i => i.IsPrimary)
                           ? Images.First(i => i.IsPrimary).Url
                           : string.Empty;
            }
            set
            {
                _primaryUrl = value;
            }
        }
    }
}