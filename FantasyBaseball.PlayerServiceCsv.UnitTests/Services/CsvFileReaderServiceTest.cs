using FantasyBaseball.Common.Exceptions;
using Xunit;

namespace FantasyBaseball.PlayerServiceCsv.Services.UnitTests
{
    public class CsvFileReaderServiceTest
    {
        [Fact] public void BadFileTest() => 
            Assert.Throws<CsvFileException>(() => new CsvFileReaderService().ReadCsvData("bad.csv"));

        [Fact] public void NullFileTest() => 
            Assert.Throws<CsvFileException>(() => new CsvFileReaderService().ReadCsvData(null));
    }
}