﻿using System.Linq;
using Transit.Framework;
using Transit.Framework.Network;

namespace Transit.Addon.RoadExtensions.Roads.Common
{
    public static partial class RoadModels
    {
        public static NetInfo Setup32m3mSW4mMdnMesh(this NetInfo info, NetInfoVersion version)
        {
            var highwayInfo = Prefabs.Find<NetInfo>(NetInfos.Vanilla.ROAD_6L);
            var slopeInfo = Prefabs.Find<NetInfo>(NetInfos.Vanilla.ROAD_4L_SLOPE);
            var defaultMaterial = highwayInfo.m_nodes[0].m_material;

            switch (version)
            {
                case NetInfoVersion.Ground:
                    {
                        var segments0 = info.m_segments[0].ShallowClone();
                        var segments1 = info.m_segments[1].ShallowClone();
                        var segments2 = info.m_segments[2].ShallowClone();
                        var segments3 = info.m_segments[0].ShallowClone();
                        var nodes0 = info.m_nodes[0].ShallowClone();
                        var nodes1 = info.m_nodes[0].ShallowClone();
                        segments0
                        .SetMeshes
                            (@"Roads\Common\Meshes\32m\3mSW4mMdn\Ground.obj");
                        segments1
                            .SetMeshes
                                (@"Roads\Common\Meshes\32m\3mSW4mMdn\Bus.obj");
                        segments2
                            .SetMeshes
                                (@"Roads\Common\Meshes\32m\3mSW4mMdn\BusBoth.obj");
                        segments3.SetMeshes(
                                @"Roads\Common\Meshes\32m\3mSW\Ground_Parking.obj");
                        nodes0
                            .SetMeshes
                                 (@"Roads\Common\Meshes\32m\3mSW\Ground_Node_Parking.obj");
                        nodes1.SetMeshes(
                                @"Roads\Common\Meshes\32m\3mSW\Ground_Parking.obj");
                        info.m_segments = new[] { segments0, segments1, segments2, segments3 };
                        info.m_nodes = new[] { nodes0, nodes1 };
                        break;
                    }
                case NetInfoVersion.GroundGrass:
                case NetInfoVersion.GroundTrees:
                case NetInfoVersion.GroundPavement:
                    {

                        var segments1 = info.m_segments[1].ShallowClone();
                        var segments2 = info.m_segments[2].ShallowClone();
                        var segments3 = info.m_segments[0].ShallowClone();
                        var segments4 = info.m_segments[1].ShallowClone();
                        var segments5 = info.m_segments[3].ShallowClone();
                        segments1.SetMeshes(
                            @"Roads\Common\Meshes\32m\3mSW4mMdn\Bus_Pavement.obj");
                        segments2.SetMeshes(
                            @"Roads\Common\Meshes\32m\3mSW4mMdn\BusBoth_Pavement.obj");
                        segments3.SetMeshes(
                            @"Roads\Common\Meshes\32m\3mSW\Ground_Pavement.obj");
                        segments4.SetMeshes(
                            @"Roads\Common\Meshes\32m\3mSW\Ground_Pavement_Bus.obj");
                        segments5.SetMeshes(
                            @"Roads\Common\Meshes\32m\3mSW\Ground_Pavement_Bus.obj");
                        var nodes0 = info.m_nodes[0].ShallowClone();
                        var nodes1 = info.m_nodes[1].ShallowClone();
                        nodes0.SetMeshes(
                            @"Roads\Common\Meshes\32m\3mSW\Ground_Node_Pavement.obj");
                        nodes1.SetMeshes(
                            @"Roads\Common\Meshes\32m\3mSW\Ground_Pavement.obj");
                        var segmentList = info.m_segments.ToList();
                        var nodeList = info.m_nodes.ToList();
                        segmentList[1] = segments1;
                        segmentList[2] = segments2;
                        segmentList[3] = segments3;
                        segmentList.Add(segments4);
                        segmentList.Add(segments5);
                        nodeList[0] = nodes0;
                        nodeList[1] = nodes1;
                        info.m_segments = segmentList.ToArray();
                        info.m_nodes = nodeList.ToArray();
                        break;
                    }
                case NetInfoVersion.Elevated:
                    {
                        var segments0 = info.m_segments[0].ShallowClone();
                        var nodes0 = info.m_nodes[0].ShallowClone();

                        segments0
                            .SetFlagsDefault()
                            .SetMeshes
                                (@"Roads\Common\Meshes\32m\3mSW4mMdn\Elevated.obj",
                                 @"Roads\Common\Meshes\32m\3mSW4mMdn\Elevated_LOD.obj");

                        nodes0
                            .SetMeshes
                                (@"Roads\Common\Meshes\32m\3mSW4mMdn\Elevated_Node.obj",
                                 @"Roads\Common\Meshes\32m\3mSW4mMdn\Elevated_Node_LOD.obj");

                        info.m_segments = new[] { segments0 };
                        info.m_nodes = new[] { nodes0 };
                        break;
                    }
                case NetInfoVersion.Bridge:
                    {
                        var segments0 = info.m_segments[0].ShallowClone();
                        var segments1 = info.m_segments[1].ShallowClone();
                        var nodes0 = info.m_nodes[0].ShallowClone();

                        segments0
                            .SetFlagsDefault()
                            .SetMeshes
                                (@"Roads\Common\Meshes\32m\3mSW4mMdn\Elevated.obj",
                                 @"Roads\Common\Meshes\32m\3mSW4mMdn\Elevated_LOD.obj");

                        segments1
                            .SetFlagsDefault()
                            .SetMeshes
                                (@"Roads\Common\Meshes\32m\3mSW4mMdn\Bridge_Cables.obj",
                                @"Roads\Common\Meshes\32m\3mSW4mMdn\Bridge_Cables_LOD.obj");

                        nodes0
                            .SetMeshes
                                (@"Roads\Common\Meshes\32m\3mSW4mMdn\Elevated_Node.obj",
                                 @"Roads\Common\Meshes\32m\3mSW4mMdn\Elevated_Node_LOD.obj");

                        info.m_segments = new[] { segments0, segments1 };
                        info.m_nodes = new[] { nodes0 };
                        break;
                    }
                case NetInfoVersion.Slope:
                    {
                        var segment0 = info.m_segments[0].ShallowClone();
                        var segment1 = slopeInfo.m_segments[1].ShallowClone();
                        var segment2 = info.m_segments[1].ShallowClone();

                        var node0 = info.m_nodes[0].ShallowClone();
                        var node1 = info.m_nodes[1].ShallowClone();
                        var node2 = node0.ShallowClone();
                        //segment0
                        //    .SetFlagsDefault()
                        //    **ToDo

                        segment2
                            .SetFlagsDefault()
                            .SetMeshes
                            (@"Roads\Common\Meshes\32m\3mSW4mMdn\Slope.obj",
                            @"Roads\Common\Meshes\32m\3mSW4mMdn\Slope_LOD.obj");

                        node1
                            .SetMeshes
                            (@"Roads\Common\Meshes\32m\3mSW4mMdn\Slope_Node.obj",
                            @"Roads\Common\Meshes\32m\3mSW4mMdn\Slope_Node_LOD.obj");

                        node2
                            .SetMeshes
                            (@"Roads\Common\Meshes\32m\3mSW4mMdn\Slope_U_Node.obj",
                            @"Roads\Common\Meshes\32m\3mSW4mMdn\Slope_U_Node_LOD.obj");

                        node2.m_material = defaultMaterial;

                        info.m_segments = new[] { segment0, segment1, segment2 };
                        info.m_nodes = new[] { node0, node1, node2 };

                        break;
                    }
                case NetInfoVersion.Tunnel:
                    {
                        var segment0 = info.m_segments[0].ShallowClone();
                        var segment1 = segment0.ShallowClone();

                        var node0 = info.m_nodes[0].ShallowClone();
                        var node1 = node0.ShallowClone();

                        segment1
                            .SetFlagsDefault()
                            .SetMeshes
                            (@"Roads\Common\Meshes\32m\3mSW4mMdn\Tunnel.obj",
                            @"Roads\Common\Meshes\32m\3mSW4mMdn\Tunnel_LOD.obj");

                        node1
                            .SetFlags(NetNode.Flags.None, NetNode.Flags.None)
                            .SetMeshes
                            (@"Roads\Common\Meshes\32m\3mSW4mMdn\Tunnel_Node.obj",
                            @"Roads\Common\Meshes\32m\3mSW4mMdn\Tunnel_Node_LOD.obj");

                        segment1.m_material = defaultMaterial;
                        node1.m_material = defaultMaterial;

                        info.m_segments = new[] { segment0, segment1 };
                        info.m_nodes = new[] { node0, node1 };

                        break;
                    }
            }
            return info;
        }
    }
}