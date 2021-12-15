using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Application.Common.Interfaces
{
    public interface IDateTime
    {
        DateTime NowUtc { get; }
    }
}
