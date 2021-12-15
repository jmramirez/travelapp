using System;
using System.Collections.Generic;
using System.Text;
using Travel.Application.Common.Mapping;
using Travel.Domain.Entities;

namespace Travel.Application.TourLists.Queries.ExportTours
{
    public class TourPackageRecord : ImapFrom<TourPackage>
    {
        public string Name { get; set; }
        public string MapLocation { get; set; }
    }
}
