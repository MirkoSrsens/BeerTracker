using System.ComponentModel.DataAnnotations;

namespace Kernel.Database
{
    public class HasOid : IHasOid
    {
        [Key]
        public long Oid { get; set; }
    }
}
