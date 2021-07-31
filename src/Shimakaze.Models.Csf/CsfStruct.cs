using System;

namespace Shimakaze.Models.Csf
{
    public class CsfStruct
    {
        public CsfHead Head { get; set; }
        public CsfLabel[] Datas { get; set; } = Array.Empty<CsfLabel>();
    }
}