﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IStatementHelper
    {
        string Save(int housekeeperOid, string housekeeperName, DateTime statementDate);
    }

    public class StatementHelper : IStatementHelper
    {
        public string Save(int housekeeperOid, string housekeeperName, DateTime statementDate)
        {
            var report = new HousekeeperStatementReport(housekeeperOid, statementDate);

            if (!report.HasData)
                return string.Empty;

            report.CreateDocument();

            var filename = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                $"Sandpiper Statement {statementDate:yyyy-MM} {housekeeperName}.pdf");

            report.ExportToPdf(filename);

            return filename;
        }
    }
}
