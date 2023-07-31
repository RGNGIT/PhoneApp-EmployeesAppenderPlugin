using System.Collections.Generic;
using System.IO;
using PhoneApp.Domain.Attributes;
using PhoneApp.Domain.DTO;
using PhoneApp.Domain.Interfaces;
using Newtonsoft.Json;
using NLog;
using System.Linq;

namespace EmployeesAppenderPlugin
{
    [Author(Name = "Rageon")]
    public class Plugin : IPluggable
    {
        public IEnumerable<DataTransferObject> Run(IEnumerable<DataTransferObject> args)
        {
            string jsonStringRead = File.ReadAllText("directory.json");
            List<EmployeesDTO> source = JsonConvert.DeserializeObject<List<EmployeesDTO>>(jsonStringRead);
            Plugin.logger.Info(string.Format("Loaded {0} employees from directory", source.Count<EmployeesDTO>()));
            return source.Cast<DataTransferObject>();
        }

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
    }
}
