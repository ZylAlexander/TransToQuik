using System.Linq;
using TransToQuik;
using Xunit;

namespace TransToQuik.Tests;

public class SubscriptionBuilderTests
{
    [Fact]
    public void Build_GroupsSecCodesByClassCode()
    {
        var subscription = new SubscriptionBuilder()
            .Add("TQBR", "SBER")
            .Add("TQBR", "GAZP")
            .Add("SPBFUT", "SiH6")
            .Build();

        Assert.Equal(2, subscription.Entries.Count);

        var tqbr = subscription.Entries.Single(x => x.ClassCode == "TQBR");
        Assert.Equal("GAZP|SBER", tqbr.SecCodes);

        var spbfut = subscription.Entries.Single(x => x.ClassCode == "SPBFUT");
        Assert.Equal("SiH6", spbfut.SecCodes);
    }
}
