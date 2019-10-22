using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace VersioningDemoCore.V1.Models
{
    /// <summary>
    /// Represents a Concern
    /// </summary>
    public class Concern
    {
        /// <summary>
        /// The concern number
        /// </summary>
        [JsonRequired]
        [Required]
        [DataMember(IsRequired =true, EmitDefaultValue =true)]
        public uint Number { get; set; }
        /// <summary>
        /// The name of the concern.
        /// </summary>
        public string? Name { get; set; }
    }
}