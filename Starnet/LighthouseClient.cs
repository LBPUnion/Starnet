﻿using System.Net;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text.Json;
using JetBrains.Annotations;
using LBPUnion.Starnet.Exceptions;
using LBPUnion.Starnet.Types.Entities.Users;

namespace LBPUnion.Starnet;

/// <summary>
///     Base class for the LighthouseClient.
/// </summary>
[PublicAPI]
public class LighthouseClient : IDisposable
{
    /// <summary>
    ///     Singleton HTTP Client.
    /// </summary>
    private readonly HttpClient httpClient = new();

    public LighthouseClient([Optional] string? authenticationKey, string host = "https://lighthouse.lbpunion.com")
    {
        // Set the base address of the HTTP Client.
        this.httpClient.BaseAddress = new Uri($"{host.TrimEnd('/')}/api/v1/");

        // Set the user agent of the HTTP Client.
        this.httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("LighthouseClient", "1.0"));

        // Set the authentication key of the HTTP Client, if provided.
        if (authenticationKey != null)
        {
            this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authenticationKey);
        }
    }

    /// <summary>
    ///     Releases all resources used by the current instance of the <see cref="LighthouseClient" /> class.
    /// </summary>
    public void Dispose()
    {
        this.httpClient.Dispose();
        GC.SuppressFinalize(this);
    }

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

        // Return the user, or null if the user is null.
        return user ?? null;
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

        // Return the user, or null if the user is null.
        return user ?? null;
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
        UserStatusEntity? userStatus =
            JsonSerializer.Deserialize<UserStatusEntity>(await userStatusReq.Content.ReadAsStringAsync());

        // Return the user, or null if the user is null.
        return userStatus ?? null;
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

        // Return the list of users, or null if the list is null.
        return users ?? null;
    }

    /// <summary>
    ///     Posts a request to create a user invite token.
    /// </summary>
    /// <param name="username">String username of the user on the server.</param>
    /// <returns>String invite token</returns>
    /// <exception cref="AuthenticationFailureException">The client is not authenticated, or the API key is invalid.</exception>
    public async Task<string?> CreateUserInviteTokenAsync(string username)
    {
        // Post a request to create a user invite token.
        HttpResponseMessage userInviteTokenReq = await this.httpClient.PostAsync($"user/inviteToken/{username}", null);
        if (userInviteTokenReq.StatusCode == HttpStatusCode.Forbidden)
        {
            throw new AuthenticationFailureException("Client not authenticated or invalid API key provided");
        }
        if (!userInviteTokenReq.IsSuccessStatusCode)
        {
            return null; // Return null if the request failed.
        }

        return await userInviteTokenReq.Content.ReadAsStringAsync();
    }

    #endregion
}