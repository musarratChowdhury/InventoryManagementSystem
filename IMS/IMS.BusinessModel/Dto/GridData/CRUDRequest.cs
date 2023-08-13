using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.BusinessModel.Dto.GridData
{
    public class CRUDRequest<T>
    {
        public string action { get; set; }
        public T value { get; set; }
    }
}
