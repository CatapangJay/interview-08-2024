using si_interview.Domain.Companies.Interfaces;
using si_interview.Domain.Companies.Models;

namespace si_interview.Infrastructure.Persistence;

public class ListedCompaniesRepository : IListedCompaniesRepository
{
    private readonly HttpClient _httpClient;
    private readonly List<AsxListedCompany> _companiesCache;

    public ListedCompaniesRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _companiesCache = LoadCompaniesFromCSV();
    }

    public async Task<AsxListedCompany> GetByAsxCode(string asxCode)
    {
        throw new NotImplementedException();
    }

    private async Task<List<AsxListedCompany>> LoadCompaniesFromCSV()
    {
        var csvData = await DownloadCsvData();

        using (var reader = new StringReader(csvData))
        using (var csv = new CsvReader(reader, new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture)))
        {
            csv.Context.RegisterClassMap<AsxListedCompanyMap>();
            return csv.GetRecords<AsxListedCompany>().ToList();
        }
    }

    private async Task<string> DownloadCsvData()
    {
        var response = await _httpClient.GetStringAsync("https://www.asx.com.au/asx/research/ASXListedCompanies.csv");
        return response;
    }
}
