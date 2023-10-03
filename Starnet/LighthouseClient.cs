using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text.Json;
using JetBrains.Annotations;
using LBPUnion.Starnet.Exceptions;
using LBPUnion.Starnet.Types.Entities.RichPresence;
using LBPUnion.Starnet.Types.Entities.Slots;
using LBPUnion.Starnet.Types.Entities.Statistics;
using LBPUnion.Starnet.Types.Entities.Users;

namespace LBPUnion.Starnet;

/// <summary>
///     Base class for the LighthouseClient.
/// </summary>
[MeansImplicitUse(ImplicitUseTargetFlags.WithMembers)]
public class LighthouseClient : IDisposable
{
    /// <summary>
    ///     Singleton HTTP Client.
    /// </summary>
    private readonly HttpClient httpClient = new();

    /// <summary>
    ///     Initializes a new instance of the <see cref="LighthouseClient" /> class.
    /// </summary>
    /// <param name="authenticationToken">(optional) API authentication token.</param>
    /// <param name="host">(optional) Web address of the host.</param>
    public LighthouseClient([Optional] string? authenticationToken, string host = "https://lighthouse.lbpunion.com")
    {
        // Set the base address of the HTTP Client.
        this.httpClient.BaseAddress = new Uri($"{host.TrimEnd('/')}/api/v1/");

        // Set the user agent of the HTTP Client.
        this.httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("LighthouseClient", "1.0"));

        // Set the authentication key of the HTTP Client, if provided.
        if (authenticationToken == null) return;

        this.httpClient.DefaultRequestHeaders.Authorization = authenticationToken.StartsWith("$")
            ? new AuthenticationHeaderValue(authenticationToken)
            : throw new ApiKeyException("The format of the API key is invalid.");
    }

    /// <summary>
    ///     Releases all resources used by the current instance of the <see cref="LighthouseClient" /> class.
    /// </summary>
    public void Dispose()
    {
        this.httpClient.Dispose();
        GC.SuppressFinalize(this);
    }

    #region Status requests

    /// <summary>
    ///     Gets the status of the server.
    /// </summary>
    /// <returns>Integer status code</returns>
    public async Task<int> GetStatusAsync()
    {
        HttpResponseMessage statusReq = await this.httpClient.GetAsync("status");
        return (int)statusReq.StatusCode;
    }

    #endregion

    #region Statistics requests

    /// <summary>
    ///     Gets the statistics of the server.
    /// </summary>
    /// <returns>Deserialized StatisticsEntity</returns>
    public async Task<StatisticsEntity?> GetStatisticsAsync()
    {
        HttpResponseMessage statisticsReq = await this.httpClient.GetAsync("statistics");
        if (!statisticsReq.IsSuccessStatusCode)
        {
            return null; // Return null if the request failed.
        }

        // Deserialize the statistics.
        StatisticsEntity? stats = JsonSerializer.Deserialize<StatisticsEntity?>(await statisticsReq.Content.ReadAsStringAsync());

        // Return the statistics. Will return null if the statistics are null.
        return stats;
    }

    #endregion

    #region Rich presence requests

    /// <summary>
    ///     Gets the RPC configuration from the server.
    /// </summary>
    /// <returns>Deserialized RichPresenceEntity</returns>
    public async Task<RichPresenceEntity?> GetRpcConfigurationAsync()
    {
        // Get the RPC configuration from the API.
        HttpResponseMessage rpcReq = await this.httpClient.GetAsync("rpc");
        if (!rpcReq.IsSuccessStatusCode)
        {
            return null; // Return null if the request failed.
        }

        // Deserialize the RPC configuration.
        RichPresenceEntity? rpc = JsonSerializer.Deserialize<RichPresenceEntity?>(await rpcReq.Content.ReadAsStringAsync());

        // Return the RPC configuration. Will return null if the RPC configuration is null.
        return rpc;
    }

    #endregion

    #region User requests

    /// <summary>
    ///     Gets a user from the server.
    /// </summary>
    /// <param name="userId">Numerical ID of the user on the server.</param>
    /// <returns>Deserialized UserEntity</returns>
    public async Task<UserEntity?> GetUserAsync(int userId)
    {
        // Get the user from the API.
        HttpResponseMessage userReq = await this.httpClient.GetAsync($"user/{userId}");
        if (!userReq.IsSuccessStatusCode)
        {
            return null; // Return null if the request failed.
        }

        // Deserialize the user.
        UserEntity? user = JsonSerializer.Deserialize<UserEntity>(await userReq.Content.ReadAsStringAsync());

        // Return the user. Will return null if the user is null.
        return user;
    }

    /// <summary>
    ///     Gets a user from the server. Overload of <see cref="GetUserAsync(int)" /> that takes a string username instead.
    /// </summary>
    /// <param name="username">String username of the user on the server.</param>
    /// <returns>Deserialized UserEntity</returns>
    public async Task<UserEntity?> GetUserAsync(string username)
    {
        // Get the user from the API.
        HttpResponseMessage userReq = await this.httpClient.GetAsync($"username/{username}");
        if (!userReq.IsSuccessStatusCode)
        {
            return null; // Return null if the request failed.
        }

        // Deserialize the user.
        UserEntity? user = JsonSerializer.Deserialize<UserEntity>(await userReq.Content.ReadAsStringAsync());

        // Return the user. Will return null if the user is null.
        return user;
    }

    /// <summary>
    ///     Gets a user's status from the server.
    /// </summary>
    /// <param name="userId">Numerical ID of the user on the server.</param>
    /// <returns>Deserialized UserStatusEntity</returns>
    public async Task<UserStatusEntity?> GetUserStatusAsync(int userId)
    {
        // Get the user from the API.
        HttpResponseMessage userStatusReq = await this.httpClient.GetAsync($"user/{userId}/status");
        if (!userStatusReq.IsSuccessStatusCode)
        {
            return null; // Return null if the request failed.
        }

        // Deserialize the user.
        UserStatusEntity? status = JsonSerializer.Deserialize<UserStatusEntity>(await userStatusReq.Content.ReadAsStringAsync());

        // Return the user status. Will return null if the user status is null.
        return status;
    }

    /// <summary>
    ///     Gets a list of users from the server based on a query.
    /// </summary>
    /// <param name="query">String search query.</param>
    /// <returns>List of deserialized UserEntities</returns>
    public async Task<List<UserEntity?>?> SearchUsersAsync(string query)
    {
        // Get the list of user results from the API.
        HttpResponseMessage userSearchReq = await this.httpClient.GetAsync($"search/user?query={query}");
        if (!userSearchReq.IsSuccessStatusCode)
        {
            return null; // Return null if the request failed.
        }

        // Deserialize the list of users.
        List<UserEntity?>? users = JsonSerializer.Deserialize<List<UserEntity?>>(await userSearchReq.Content.ReadAsStringAsync());

        // Return the list of users. Will return null if the list of users is null.
        return users;
    }

    /// <summary>
    ///     Posts a request to create a user invite token.
    /// </summary>
    /// <param name="username">String username of the user on the server.</param>
    /// <returns>String invite token</returns>
    /// <exception cref="ApiAuthenticationException">The client is not authenticated, or the API key is invalid.</exception>
    /// <exception cref="ApiRegistrationException">Registration is not enabled on this server, or the API Key is invalid.</exception>
    /// <remarks>Requires a valid API key on the host server.</remarks>
    [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
    public async Task<string?> CreateUserInviteTokenAsync(string username)
    {
        // Post a request to create a user invite token.
        HttpResponseMessage userInviteTokenReq = await this.httpClient.PostAsync($"user/inviteToken/{username}", null);

        // Handle both 403 and 404 errors.
        switch ((int)userInviteTokenReq.StatusCode)
        {
            case 403:
                throw new ApiAuthenticationException("The client is not authenticated, or the API key is invalid.");
            case 404:
                if (this.httpClient.DefaultRequestHeaders.Authorization != null)
                {
                    throw new ApiRegistrationException("Registration is not enabled on this server, or the API key is invalid.");
                }
                throw new ApiAuthenticationException("The client is not authenticated, or the API key is invalid.");
        }

        // Handle any other errors.
        if (!userInviteTokenReq.IsSuccessStatusCode)
        {
            return null; // Return null if the request failed.
        }

        return await userInviteTokenReq.Content.ReadAsStringAsync();
    }

    #endregion

    #region Slot requests

    /// <summary>
    ///     Gets a list of slots from the server.
    /// </summary>
    /// <param name="limit">Number of slots to retrieve.</param>
    /// <param name="skip">Number of slots to skip.</param>
    /// <returns>List of deserialized SlotEntities</returns>
    public async Task<List<SlotEntity?>?> GetSlotsAsync(int limit = 20, int skip = 0)
    {
        // Get the list of slots from the API.
        HttpResponseMessage slotsReq = await this.httpClient.GetAsync("slots");
        if (!slotsReq.IsSuccessStatusCode)
        {
            return null; // Return null if the request failed.
        }

        // Deserialize the list of slots.
        List<SlotEntity?>? slots = JsonSerializer.Deserialize<List<SlotEntity?>>(await slotsReq.Content.ReadAsStringAsync());

        // Return the list of slots. Will return null if the list of slots is null.
        return slots;
    }

    /// <summary>
    ///     Gets a slot from the server.
    /// </summary>
    /// <param name="slotId">Numerical ID of the slot on the server</param>
    /// <returns>Deserialized SlotEntity</returns>
    public async Task<SlotEntity?> GetSlotAsync(int slotId)
    {
        // Get the slot from the API.
        HttpResponseMessage slotReq = await this.httpClient.GetAsync($"slot/{slotId}");
        if (!slotReq.IsSuccessStatusCode)
        {
            return null; // Return null if the request failed.
        }

        // Deserialize the slot.
        SlotEntity? slot = JsonSerializer.Deserialize<SlotEntity?>(await slotReq.Content.ReadAsStringAsync());

        // Return the slot. Will return null if the slot is null.
        return slot;
    }

    #endregion
}