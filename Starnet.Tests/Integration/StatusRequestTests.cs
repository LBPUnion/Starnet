using Xunit;

namespace LBPUnion.Starnet.Tests.Integration;

[Trait("Category", "Integration")]
public class StatusRequestTests
{
    private readonly LighthouseClient client = new();

    [Fact]
    public async Task StatusRequests_CanGetStatus() => Assert.IsType<int>(await this.client.GetStatusAsync());
}