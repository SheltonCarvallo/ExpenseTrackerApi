using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Models
{
    public record SavedAuthorization
    {
        public bool CouldBeSaved { get; init; }
    }
}
