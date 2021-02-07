using System.Collections.Generic;
using FantasyBaseball.Common.Exceptions;
using FantasyBaseball.Common.Models;
using Xunit;

namespace FantasyBaseball.PlayerServiceCsv.Services.UnitTests
{
    public class CsvFileWriterServiceTest
    {
        [Fact] public void BadFileTest() => 
            Assert.Throws<CsvFileException>(() => new CsvFileWriterService().WriteCsvData("bad.csv", new List<BaseballPlayer>()));

        [Fact] public void NullFileTest() => 
            Assert.Throws<CsvFileException>(() => new CsvFileWriterService().WriteCsvData(null, new List<BaseballPlayer>()));
    }
}