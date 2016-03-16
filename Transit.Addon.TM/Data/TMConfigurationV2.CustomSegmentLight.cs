using System;

namespace Transit.Addon.TM.Data
{
    public partial class TMConfigurationV2
    {
        [Serializable]
        public class CustomSegmentLight
        {
            public ushort nodeId;
            public ushort segmentId;
            public int currentMode;
            public RoadBaseAI.TrafficLightState leftLight;
            public RoadBaseAI.TrafficLightState mainLight;
            public RoadBaseAI.TrafficLightState rightLight;
        }
    }
}