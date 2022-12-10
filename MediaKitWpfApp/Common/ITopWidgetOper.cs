using System;

namespace AVideoWpfApp.Common
{
    public interface ITopWidgetOper
    {
        Action Menu { get; set; }
        Action Min { get; set; }
        Action Close { get; set; }
    }
}
