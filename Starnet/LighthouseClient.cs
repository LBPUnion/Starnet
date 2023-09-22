﻿using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text.Json;
using JetBrains.Annotations;
using LBPUnion.Starnet.Entities;

namespace LBPUnion.Starnet;

/// <summary>
/// Base class for the LighthouseClient.
/// </summary>
[PublicAPI]
public class LighthouseClient : IDisposable
{
    /// <summary>
    /// Singleton HTTP Client.
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

    #region User requests

    /// <summary>
    /// Gets a user from the server.
    /// </summary>
    /// <param name="userId">Numerical ID of the user on the server.</param>
    /// <returns>Deserialized UserEntity</returns>
    public async Task<UserEntity?> GetUserAsync(int userId)
    {
        // Get the user from the API.
        HttpResponseMessage userReq = await this.httpClient.GetAsync($"user/{userId}");
        if (!userReq.IsSuccessStatusCode) return null; // Return null if the request failed.

        // Deserialize the user.
        UserEntity? user = JsonSerializer.Deserialize<UserEntity>(await userReq.Content.ReadAsStringAsync());

        // Return the user, or null if the user is null.
        return user ?? null;
    }

    /// <summary>
    /// Gets a user from the server. Overload of <see cref="GetUserAsync(int)"/> that takes a string username instead.
    /// </summary>
    /// <param name="username">String username of the user on the server.</param>
    /// <returns>Deserialized UserEntity</returns>
    public async Task<UserEntity?> GetUserAsync(string username)
    {
        // Get the user from the API.
        HttpResponseMessage userReq = await this.httpClient.GetAsync($"username/{username}");
        if (!userReq.IsSuccessStatusCode) return null; // Return null if the request failed.

        // Deserialize the user.
        UserEntity? user = JsonSerializer.Deserialize<UserEntity>(await userReq.Content.ReadAsStringAsync());

        // Return the user, or null if the user is null.
        return user ?? null;
    }

    #endregion

    public void Dispose()
    {
        this.httpClient.Dispose();
        GC.SuppressFinalize(this);
    }
}