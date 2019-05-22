using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSweep.Models.Enums
{
    public enum UpdateStatus
    {
        None = 0,
        OK,
        Hit,
        Error,
        Close,
        Reset,
        Lost,
        Terminate,
        ShowHelp,
        ShowSettings
    }
}
