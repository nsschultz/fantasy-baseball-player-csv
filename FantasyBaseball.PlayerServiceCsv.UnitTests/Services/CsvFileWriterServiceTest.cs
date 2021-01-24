using System.Collections.Generic;
using FantasyBaseball.CommonModels.Exceptions;
using FantasyBaseball.CommonModels.Player;
using FantasyBaseball.PlayerServiceCsv.Services;
using Xunit;

namespace FantasyBaseball.PlayerServiceCsv.UnitTests.Services
{
    public class CsvFileWriterServiceTest
    {
        [Fact] public void BadFileTest() => Assert.Throws<CsvFileException>(() => new CsvFileWriterService().WriteCsvData("bad.csv", new List<BaseballPlayer>()));

        [Fact] public void NullFileTest() => Assert.Throws<CsvFileException>(() => new CsvFileWriterService().WriteCsvData(null, new List<BaseballPlayer>()));
    }
}