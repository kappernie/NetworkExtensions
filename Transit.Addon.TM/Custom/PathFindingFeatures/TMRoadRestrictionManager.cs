﻿using System;
using TrafficManager.Traffic;
using Transit.Framework;
using Transit.Framework.ExtensionPoints.PathFindingFeatures.Contracts;
using Transit.Framework.Network;

namespace TrafficManager.Custom.PathFindingFeatures
{
    public class TMRoadRestrictionManager : IRoadRestrictionManager
    {
        public bool CanUseLane(uint laneId, ushort? segmentId, uint? laneIndex, ExtendedUnitType unitType)
        {
            if ((unitType & TMSupported.UNITS) == 0)
            {
                return true;
            }

            var laneInfo = NetManager.instance.GetLaneInfo(laneId);

            if (laneInfo == null)
            {
                return true;
            }

            if ((laneInfo.m_vehicleType & TMSupported.VEHICLETYPES) == 0)
            {
                return true;
            }

            if (segmentId == null)
            {
                segmentId = NetManager.instance.GetLaneNetSegmentId(laneId);
            }
            if (segmentId == null)
            {
                throw new Exception("TM: Segment not found for LaneID " + laneId);
            }

            if (laneIndex == null)
            {
                laneIndex = NetManager.instance.GetLaneIndex(laneId);
            }
            if (laneIndex == null)
            {
                throw new Exception("TM: LaneIndex not found for LaneID " + laneId);
            }

            var allowedVehicleTypes = VehicleRestrictionsManager.GetAllowedVehicleTypes(segmentId.Value, laneIndex.Value, laneId, laneInfo);
            var allowedUnitTypes = allowedVehicleTypes.ConvertToUnitType();

#if DEBUGPF
            	if (debug) {
            		Log._Debug($"CanUseLane: segmentId={segmentId} laneIndex={laneIndex} laneId={laneId}, unitType={unitType} _vehicleTypes={_vehicleTypes} _laneTypes={_laneTypes} _transportVehicle={_transportVehicle} _isHeavyVehicle={_isHeavyVehicle} allowedTypes={allowedTypes} res={((allowedTypes & unitType) != ExtVehicleType.None)}");
                }
#endif

            return ((allowedUnitTypes & unitType) != 0);
        }
    }
}