﻿using System.Globalization;
using CsvHelper;
using Travel.Application.Common.Interfaces;
using Travel.Application.TourLists.Queries.ExportTours;

namespace Travel.Shared.Files;

public class CvsFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTourPackagesFile(IEnumerable<TourPackageRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}