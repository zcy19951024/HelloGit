using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bedrock_WeCath_WeiXin.Models
{
    interface Interface1
    {
        IEnumerable<EmployeeInfo> GetAll();
        EmployeeInfo Get(int id);

        EmployeeInfo Add(EmployeeInfo item);
        void Remove(int id);
        bool Update(EmployeeInfo item);
    }
}
