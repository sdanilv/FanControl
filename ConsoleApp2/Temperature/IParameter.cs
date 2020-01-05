using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Temperature
{
    public interface IParameter : IElement
    {

        ISensor Sensor { get; }
        Identifier Identifier { get; }

        string Name { get; }
        string Description { get; }
        float Value { get; set; }
        float DefaultValue { get; }
        bool IsDefault { get; set; }
    }
}
