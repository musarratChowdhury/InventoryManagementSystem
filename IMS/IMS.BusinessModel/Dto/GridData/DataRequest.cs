using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.BusinessModel.Dto.GridData
{
    public class DataRequest
    {
        public bool requiresCount { get; set; }
        public List<SortInfo> Sorted { get; set; }
        public int skip { get; set; }
        public int take { get; set; }
    }

    public class SortInfo
    {
        public string Name { get; set; }
        public string Direction { get; set; }
    }
}
