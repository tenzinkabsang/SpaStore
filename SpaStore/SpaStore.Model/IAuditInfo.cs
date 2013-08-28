using System;

namespace SpaStore.Model
{
    public interface IAuditInfo
    {
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}