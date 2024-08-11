using si_interview.Domain.Companies.Models;

namespace si_interview.Domain.Companies.Interfaces;

public interface IListedCompaniesRepository
{
    Task<AsxListedCompany> GetByAsxCode(string asxCode);
}
