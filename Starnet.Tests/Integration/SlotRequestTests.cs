using LBPUnion.Starnet.Types.Entities.Slots;
using Xunit;

namespace LBPUnion.Starnet.Tests.Integration;

[Trait("Category", "Integration")]
public class SlotRequestTests
{
    private readonly LighthouseClient client = new();

    [Fact]
    public async Task SlotRequests_CanGetSlots()
    {
        List<SlotEntity?>? slotEntities = await this.client.GetSlotsAsync();
        Assert.NotNull(slotEntities);

        Assert.True(slotEntities.Count == 20);
    }

    [Fact]
    public async Task SlotRequests_CanGetSlotById()
    {
        SlotEntity? slotEntity = await this.client.GetSlotAsync(7157);
        Assert.NotNull(slotEntity);

        Assert.Equal(311, slotEntity.CreatorId);
        Assert.Equal("The Endurance Test.", slotEntity.Name);

        Assert.Contains("How far can you go?", slotEntity.Description);
    }
}