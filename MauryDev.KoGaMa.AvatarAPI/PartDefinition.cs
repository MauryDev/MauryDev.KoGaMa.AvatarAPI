using System;
using System.Collections.Generic;
using System.Text;

namespace MauryDev.KoGaMa.AvatarAPI
{
    using System.Numerics;

    namespace MauryDev.KoGaMa.AvatarAPI.Models
    {
        public class PartDefinition
        {
            public string Name { get; }
            public Vector3 BonePosition { get; }
            public int MinCubes { get; }
            public Vector3 BoxMin { get; }
            public Vector3 BoxMax { get; }

            public PartDefinition(string name, Vector3 bonePosition, int minCubes, Vector3 boxMin, Vector3 boxMax)
            {
                Name = name;
                BonePosition = bonePosition;
                MinCubes = minCubes;
                BoxMin = boxMin;
                BoxMax = boxMax;
            }
        }
    }

}
