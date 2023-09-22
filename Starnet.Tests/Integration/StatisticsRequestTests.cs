using LBPUnion.Starnet.Types.Entities.Statistics;
using Xunit;

namespace LBPUnion.Starnet.Tests.Integration;

[Trait("Category", "Integration")]
public class StatisticsRequestTests
{
    private readonly LighthouseClient client = new();
    
    [Fact]
    public async Task StatisticsRequests_CanGetStatistics()
    {
        StatisticsEntity? statistics = await this.client.GetStatisticsAsync();
        Assert.NotNull(statistics);

        Assert.True(statistics.Slots > 0);
        Assert.True(statistics.Users > 0);
        Assert.True(statistics.Photos > 0);
    }
}