﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpdBaileyTechnology.Shared.WPF.Service.Services
{
    public interface IPrintFlowDocument
    {
        void Print(string caption, string flowDocumentXaml);
        void PrintPreview(string caption, string flowDocumentXaml);
    }
}
