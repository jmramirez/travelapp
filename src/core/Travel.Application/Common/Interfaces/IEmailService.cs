using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Travel.Application.Dtos;

namespace Travel.Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailDto emailRequest); 
    }
}
