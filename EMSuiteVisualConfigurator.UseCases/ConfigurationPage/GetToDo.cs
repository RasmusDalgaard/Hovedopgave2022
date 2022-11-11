using EMSuiteVisualConfigurator.CoreBusiness.Entities;
using EMSuiteVisualConfigurator.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSuiteVisualConfigurator.UseCases
{
    public class GetToDo : IGetToDo
    {
        private readonly IToDoRepository toDoRepository;
        public GetToDo(IToDoRepository todoRepository)
        {
            this.toDoRepository = todoRepository;
        }

        public ToDo Execute()
        {
            return toDoRepository.GetToDo();
        }
    }
}
