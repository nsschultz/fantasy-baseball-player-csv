using FantasyBaseball.CommonModels.Exceptions;
using FantasyBaseball.PlayerServiceCsv.Services;
using Xunit;

namespace FantasyBaseball.PlayerServiceCsv.UnitTests.Services
{
    public class CsvFileReaderServiceTest
    {
        [Fact] public void BadFileTest() => Assert.Throws<CsvFileException>(() => new CsvFileReaderService().ReadCsvData("bad.csv"));

        [Fact] public void NullFileTest() => Assert.Throws<CsvFileException>(() => new CsvFileReaderService().ReadCsvData(null));
    }
}