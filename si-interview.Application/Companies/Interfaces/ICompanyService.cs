using si_interview.Application.Companies.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace si_interview.Application.Companies.Interfaces;

public interface ICompanyService
{
    Task<AsxListedCompanyDTO> GetByAsxCode(string asxCode);
}
