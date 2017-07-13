using System.ComponentModel;

namespace WebApiPto.Classes
{
    public static class Enums
    {
        public enum EnFormType
        {
            [Description("Lower Body")]
            Lb = 1,
            [Description("Neck / Upper Body")]
            NeckUb = 2,
            [Description("Neck / Lower Body")]
            NeckLb = 3,
            [Description("Uper Extremites")]
            Ue = 4,
            [Description("Lower Extremites")]
            Le = 5,
            [Description("Elbow / Hand")]
            ElbowHand = 6

        }

    }
}