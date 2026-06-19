using MauryDev.KoGaMa.AvatarAPI.Enums;
using MauryDev.KoGaMa.AvatarAPI.MauryDev.KoGaMa.AvatarAPI.Models;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace MauryDev.KoGaMa.AvatarAPI
{
    public static class AvatarPartRegistry
    {
        private static readonly Dictionary<PartIndex, PartDefinition> Definitions = new Dictionary<PartIndex, PartDefinition>
        {
            { PartIndex.Head,    new PartDefinition("Head",    new Vector3(0f, -7.7f, -1.5f), 20, new Vector3(-4f, 7f, -2f), new Vector3(3f, 14f, 5f)) },
            { PartIndex.Torso,   new PartDefinition("Torso",   new Vector3(0f, -2.8f, -1.5f), 20, new Vector3(-4f, 2f, -2f), new Vector3(3f, 8f, 5f)) },
            { PartIndex.RArm,    new PartDefinition("RArm",    new Vector3(0.5f, -7.5f, 2f),   3, new Vector3(-2f, 1f, -3f), new Vector3(1f, 7f, -2f)) },
            { PartIndex.LArm,    new PartDefinition("LArm",    new Vector3(0.5f, -7.5f, 2f),   3, new Vector3(-2f, 1f, -3f), new Vector3(1f, 7f, -2f)) },
            { PartIndex.RUpLeg,  new PartDefinition("RUpLeg",  new Vector3(-1f, -1.5f, 0f),   3, new Vector3(-1f, 0f, -1f), new Vector3(3f, 2f, 2f)) },
            { PartIndex.RLowLeg, new PartDefinition("RLowLeg",  new Vector3(-1f, -1.5f, 0f),   3, new Vector3(-1f, 0f, -1f), new Vector3(2f, 1f, 2f)) },
            { PartIndex.LUpLeg,  new PartDefinition("LUpLeg",  new Vector3(-1f, -1.5f, 0f),   3, new Vector3(-1f, 0f, -1f), new Vector3(3f, 2f, 2f)) },
            { PartIndex.LLowLeg, new PartDefinition("LLowLeg",  new Vector3(-1f, -1.5f, 0f),   3, new Vector3(-1f, 0f, -2f), new Vector3(2f, 1f, 1f)) },
            { PartIndex.Holster, new PartDefinition("Holster", new Vector3(0, 0, 0),           0, new Vector3(0, 0, 0),    new Vector3(0, 0, 0)) },
        };

        public static PartDefinition GetDefinition(PartIndex index)
        {
            if (Definitions.TryGetValue(index, out var definition))
            {
                return definition;
            }
            throw new KeyNotFoundException(string.Format("Definition for part {0} not found.", index));
        }
    }
}
