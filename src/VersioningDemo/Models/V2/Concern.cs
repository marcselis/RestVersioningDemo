using System.Runtime.Serialization;

namespace VersioningDemo.Models.V2
{
#nullable enable
    public class Concern
    {
        [DataMember(IsRequired = true, EmitDefaultValue = true)]
        public string Nr { get; set; } = "";
        public string? Name { get; set; }
    }
}