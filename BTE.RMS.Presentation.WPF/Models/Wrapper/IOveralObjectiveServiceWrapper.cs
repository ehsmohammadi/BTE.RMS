using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTE.RMS.Presentation.WPF.Models.Wrapper
{
    public interface IOveralObjectiveServiceWrapper
    {
        void CreateOveralObjective(Action<CrudOveralObjective,Exception> action )
    }
}
