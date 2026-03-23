using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace IclPaths.API.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SortAndFilterBy
    {
        Name,
        Description,
        Length,
        Region,
        Difficulty
    }
}
