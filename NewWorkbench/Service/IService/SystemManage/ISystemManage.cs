using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewWorkbench.Service.IService
{
    public interface ISystemManage : IRepository<Domain.SYS_SYSTEM>
    {
        dynamic LoadSystemInfo(List<string> systems);
    }
}
