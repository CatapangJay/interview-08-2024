using si_interview.Application.Companies.DTOs;
using si_interview.Application.Companies.Interfaces;
using si_interview.Domain.Companies.Interfaces;

namespace si_interview.Application.Companies.Services
{
    public class AsxListedCompaniesService : ICompanyService
    {
        private readonly IListedCompaniesRepository _companyRepository;

        public AsxListedCompaniesService(IListedCompaniesRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<AsxListedCompanyDTO> GetByAsxCode(string asxCode)
        {
            var company = await _companyRepository.GetByAsxCode(asxCode);
            if (company is null) return null;

            return new AsxListedCompanyDTO
            {
                AsxCode = company.AsxCode,
                CompanyName = company.CompanyName,
                GicsIndustryGroup = company.GicsIndustryGroup
            };
        }
    }
}
