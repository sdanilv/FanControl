using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Temperature
{
    public interface IVisitor
    {
        void VisitHardware(IHardware hardware);
        void VisitSensor(ISensor sensor);
        void VisitParameter(IParameter parameter);
    }
}
