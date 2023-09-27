using LBPUnion.Starnet.Types.Entities.RichPresence;
using Xunit;

namespace LBPUnion.Starnet.Tests.Integration;

[Trait("Category", "Integration")]
public class RichPresenceRequestTests
{
    private readonly LighthouseClient client = new();
    
    [Fact]
    public async Task RichPresenceRequests_CanGetRichPresence()
    {
        RichPresenceEntity? richPresenceEntity = await this.client.GetRpcConfigurationAsync();
        Assert.NotNull(richPresenceEntity);
        Assert.NotNull(richPresenceEntity.Assets);

        Assert.Equal("1060973475151495288", richPresenceEntity.ApplicationId);
        Assert.Equal("beacon", richPresenceEntity.PartyIdPrefix);
        Assert.Equal("Integer", richPresenceEntity.UsernameType.ToString());
    }
}