﻿using Transit.Framework;

namespace Transit.Addon.RoadExtensions.Roads.Common
{
    public static partial class RoadModels
    {
        public static NetInfo Setup8mNoSWMesh(this NetInfo info, NetInfoVersion version)
        {
            var highwayInfo = Prefabs.Find<NetInfo>(NetInfos.Vanilla.HIGHWAY_3L);
            var highwaySlopeInfo = Prefabs.Find<NetInfo>(NetInfos.Vanilla.HIGHWAY_3L_SLOPE);
            var defaultMaterial = highwayInfo.m_nodes[0].m_material;

            switch (version)
            {
                case NetInfoVersion.Ground:
                    var segments0 = info.m_segments[0];
                    var nodes0 = info.m_nodes[0];
                    var nodes1 = info.m_nodes[0].ShallowClone();

                    nodes0.m_flagsRequired = NetNode.Flags.None;
                    nodes0.m_flagsForbidden = NetNode.Flags.Transition;

                    nodes1.m_flagsRequired = NetNode.Flags.Transition;
                    nodes1.m_flagsForbidden = NetNode.Flags.None;

                    segments0
                        .SetFlagsDefault()
                        .SetMeshes(
                        @"Roads\Common\Meshes\8m\NoSW\Ground.obj");

                    nodes0
                        .SetMeshes(
                        @"Roads\Common\Meshes\8m\NoSW\Ground_Node.obj");

                    nodes1
                        .SetMeshes(
                        @"Roads\Common\Meshes\8m\NoSW\Ground_Trans.obj");

                    info.m_segments = new[] { segments0 };
                    info.m_nodes = new[] { nodes0, nodes1 };
                    break;
            }
            return info;
        }
    }
}