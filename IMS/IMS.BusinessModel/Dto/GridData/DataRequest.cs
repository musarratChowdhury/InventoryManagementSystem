using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.BusinessModel.Dto.GridData
{
    public class DataRequest
    {
        public bool RequiresCounts { get; set; }
        public List<FilterPredicate> Where { get; set; }
        public List<SortDescriptor> Sorted { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }

    public class FilterPredicate
    {
        public bool IsComplex { get; set; }
        public bool IgnoreCase { get; set; }
        public bool IgnoreAccent { get; set; }
        public string Condition { get; set; }
        public List<FieldPredicate> Predicates { get; set; }
    }

    public class FieldPredicate
    {
        public bool IsComplex { get; set; }
        public string Field { get; set; }
        public string Operator { get; set; }
        public object Value { get; set; }
        public bool IgnoreCase { get; set; }
        public bool IgnoreAccent { get; set; }
    }

    public class SortDescriptor
    {
        public string Name { get; set; }
        public string Direction { get; set; }
    }

}
