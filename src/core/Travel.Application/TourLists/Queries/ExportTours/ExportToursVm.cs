﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Application.TourLists.Queries.ExportTours
{
    public class ExportToursVm
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
}
