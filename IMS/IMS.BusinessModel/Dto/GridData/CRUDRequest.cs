using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.BusinessModel.Dto.GridData
{
    public class CRUDRequest<T>
    {
        public string action { get; set; }
        public int Key { get; set; }
        public string KeyColumn { get; set; }
        public T value { get; set; }
    }

    public class DeleteRequest
    {
        public string action { get; set; }
        public int Key { get; set; }
        public string KeyColumn { get; set; }
    }

}
