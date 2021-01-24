using FantasyBaseball.CommonModels.Enums;
using FantasyBaseball.PlayerServiceCsv.Converters;
using Xunit;

namespace FantasyBaseball.PlayerServiceCsv.UnitTests.Converters
{
    public class LeagueStatusConverterTest
    {
        [Theory]
        [InlineData(      "x", LeagueStatus.X)]
        [InlineData(    " R ", LeagueStatus.R)]
        [InlineData("Scouted", LeagueStatus.S)]
        [InlineData(       "", LeagueStatus.A)]
        [InlineData(     null, LeagueStatus.A)]
        public void ConvertFromStringTest(string value, LeagueStatus expected) => 
            Assert.Equal(expected, new LeagueStatusConverter().ConvertFromString(value, null, null));

        [Theory]
        [InlineData(LeagueStatus.X, "X")]
        [InlineData          (null, "A")]
        public void ConvertToStringTest(object value, string expected) => 
            Assert.Equal(expected, new LeagueStatusConverter().ConvertToString(value, null, null));
    }
}