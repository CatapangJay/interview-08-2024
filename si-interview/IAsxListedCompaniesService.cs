namespace si_interview
{
    public interface IAsxListedCompaniesService
    {
        Task<AsxListedCompany> GetByAsxCode(string asxCode);
    }
}
