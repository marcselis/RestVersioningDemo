using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace VersioningDemoCore.V2.Models
{
    /// <summary>
    /// Represents a Concern
    /// </summary>
    public class Concern
    {
        /// <summary>
        /// The concern number
        /// </summary>
        [DataMember(IsRequired = true, EmitDefaultValue = true)]
        public string Nr { get; set; } = "";
        /// <summary>
        /// The name of the concern.
        /// </summary>
        public string? Name { get; set; }
    }
}