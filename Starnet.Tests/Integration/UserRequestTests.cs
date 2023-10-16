using LBPUnion.Starnet.Exceptions;
using LBPUnion.Starnet.Types.Entities.Users;
using Xunit;

namespace LBPUnion.Starnet.Tests.Integration;

[Trait("Category", "Integration")]
public class UserRequestTests
{
    private readonly LighthouseClient client = new();

    [Fact]
    public async Task UserRequests_CanGetUserById()
    {
        UserEntity? userEntity = await this.client.GetUserAsync(992);
        Assert.NotNull(userEntity);

        Assert.Equal(992, userEntity.UserId);
        Assert.Equal("littlebigmolly", userEntity.Username);
    }

    [Fact]
    public async Task UserRequests_CanGetUserByUsername()
    {
        UserEntity? userEntity = await this.client.GetUserAsync("littlebigmolly");
        Assert.NotNull(userEntity);

        Assert.Equal(992, userEntity.UserId);
        Assert.Equal("littlebigmolly", userEntity.Username);
    }

    /// <summary>
    ///     This can't be effectively tested, as the user status is not constant.
    /// </summary>
    [Fact]
    public async Task UserRequests_CanGetUserStatusById()
    {
        UserStatusEntity? userStatusEntity = await this.client.GetUserStatusAsync(992);
        Assert.NotNull(userStatusEntity);
    }

    // ReSharper disable once CommentTypo
    [Fact]
    public async Task UserRequests_CanSearchUsersByQuery()
    {
        List<UserEntity?>? userEntities = await this.client.SearchUsersAsync("littlebig");
        Assert.NotNull(userEntities);

        UserEntity? firstResult = userEntities.FirstOrDefault(u => u is { Username: "littlebigmolly" });
        Assert.NotNull(firstResult);

        Assert.Equal(992, firstResult.UserId);
        Assert.Equal("littlebigmolly", firstResult.Username);

        UserEntity? secondResult = userEntities.FirstOrDefault(u => u is { Username: "LittleBigArchive" });
        Assert.NotNull(secondResult);

        Assert.Equal(237, secondResult.UserId);
        Assert.Equal("LittleBigArchive", secondResult.Username);
    }

    [Fact]
    public async Task UserRequests_InviteTokenThrowOnRegistrationIssue()
    {
        await Assert.ThrowsAsync<ApiRegistrationException>(async () =>
        {
            LighthouseClient badRegistrationClient = new("$");
            await badRegistrationClient.CreateUserInviteTokenAsync("littlebigmolly");
        });
    }

    [Fact(Skip = "Infinite is running into billing issues at the moment, disabling until it comes back online.")]
    public async Task UserRequests_InviteTokenThrowOnAuthenticationIssue()
    {
        await Assert.ThrowsAsync<ApiAuthenticationException>(async () =>
        {
            LighthouseClient badAuthenticationClient = new("$", "https://lnfinite.site");
            await badAuthenticationClient.CreateUserInviteTokenAsync("Qo_Toyo_oQ");
        });
    }
}