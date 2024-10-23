using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.Order_Aggregate
{
    public enum Status
    {
        [EnumMember(Value = "Pending")]
        Pending,
        [EnumMember(Value = "Successeded")]
        Successeded,
        [EnumMember(Value = "Failed")]
        Failed
    }
}
