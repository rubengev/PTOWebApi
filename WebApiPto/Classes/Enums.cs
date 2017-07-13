using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WebApiPto.Classes
{
    public static class Enums
    {
        public enum enFormType
        {
            [Description("Lower Body")]
            LB = 1,
            [Description("Neck / Upper Body")]
            NeckUB = 2,
            [Description("Neck / Lower Body")]
            NeckLB = 3,
            [Description("Uper Extremites")]
            UE = 4,
            [Description("Lower Extremites")]
            LE = 5,
            [Description("Elbow / Hand")]
            ElbowHand = 6

        }

    }
}