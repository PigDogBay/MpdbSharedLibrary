using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpdBaileyTechnology.Shared.WPF.Service.Services
{
    /// <summary>
    /// Dialog to select a folder
    /// </summary>
    public interface IFolderBrowserDialog
    {
        /// <summary>
        /// Show the folder browser dialog
        /// </summary>
        /// <param name="path">Directory path, if true returned</param>
        /// <returns>True - ok, false cancelled</returns>
        bool Show(ref string path);
    }
}
