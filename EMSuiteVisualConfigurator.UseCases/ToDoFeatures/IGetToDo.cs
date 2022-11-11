using EMSuiteVisualConfigurator.CoreBusiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSuiteVisualConfigurator.UseCases.ToDoFeatures
{
    public interface IGetToDo
    {
        ToDo Execute();
    }
}
