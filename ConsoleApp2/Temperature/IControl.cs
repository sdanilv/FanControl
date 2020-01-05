using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Temperature
{
    public enum ControlMode
    {
        Default,
        Software,
        Auto,
        DirtyDefault
    }

    public interface IControl
    {

        Identifier Identifier { get; }

        ControlMode ControlMode { get; }

        float SoftwareValue { get; }

        void SetDefault();

        void SetAuto();

        void SetDirtyDefault(int policy, int level);

        float MinSoftwareValue { get; }
        float MaxSoftwareValue { get; }
        int DefaultPolicy { get; }
        int DefaultLevel { get; }

        void SetSoftware(float value);

    }
}
