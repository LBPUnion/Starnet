using System.Text.Json;

namespace LBPUnion.Starnet.Helpers;

internal static class SerializationHelper
{
    /// <summary>
    ///     The <see cref="JsonSerializerOptions" /> used for deserializing Lighthouse API responses.
    /// </summary>
    private static readonly JsonSerializerOptions lighthouseJsonOptions = new()
    {
        AllowTrailingCommas = true,
        PropertyNameCaseInsensitive = true,
        ReadCommentHandling = JsonCommentHandling.Skip,
    };

    /// <summary>
    ///     Extension method to deserialize a Lighthouse API response (<see cref="HttpResponseMessage" />)
    ///     to a target type (<typeparamref name="T" />).
    /// </summary>
    /// <param name="lighthouseResponse">The Lighthouse API response to deserialize.</param>
    /// <typeparam name="T">The target type of the deserialized response.</typeparam>
    /// <returns>A target type (<typeparamref name="T" />) representation of the deserialized response.</returns>
    internal static async Task<T?> DeserializeLighthouseResponse<T>
        (this HttpResponseMessage lighthouseResponse) =>
        JsonSerializer.Deserialize<T>(await lighthouseResponse.Content.ReadAsStringAsync(), lighthouseJsonOptions);
}
