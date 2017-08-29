using System;
using System.Threading.Tasks;

namespace EFCoreBench.Commands
{

    public interface ITestPerformanceRunner
    {
        Task ConnectionTask(Func<AppDb, Task> cb, int ops);
    }

}
