using LBPUnion.Starnet.Entities;
using Xunit;

namespace LBPUnion.Starnet.Tests.Integration;

[Trait("Category", "Unit")]
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
}