using MauryDev.KoGaMa.AvatarAPI.Enums;
using MauryDev.KoGaMa.ModelAPI.Model;
using System.Numerics;

namespace MauryDev.KoGaMa.AvatarAPI
{
    public class AvatarInfo
    {
        public ModelInfo[] Parts { get; set; } = new ModelInfo[8];

        public static readonly string[] PartNames = new string[]
        {
            "Head", "Torso", "RArm", "LArm", "RUpLeg", "RLowLeg", "LUpLeg", "LLowLeg", "Holster"
        };

        public static readonly Vector3[] PartBoneSpacePosition = new Vector3[]
        {
            new Vector3(0f, -7.7f, -1.5f),
            new Vector3(0f, -2.8f, -1.5f),
            new Vector3(0.5f, -7.5f, 2f),
            new Vector3(0.5f, -7.5f, 2f),
            new Vector3(-1f, -1.5f, 0f),
            new Vector3(-1f, -1.5f, 0f),
            new Vector3(-1f, -1.5f, 0f),
            new Vector3(-1f, -1.5f, 0f)
        };

        public static int[] PartConstraintsMinCubes { get; private set; } = new int[]
        {
            20, 20, 3, 3, 3, 3, 3, 3
        };
        public static float[][] PartConstraintsBoxMin { get; private set; } = new float[][]
            {
                new float[] { -4f, 7f, -2f },
                new float[] { -4f, 2f, -2f },
                new float[] { -2f, 1f, -3f },
                new float[] { -2f, 1f, -3f },
                new float[] { -1f, 0f, -1f },
                new float[] { -1f, 0f, -1f },
                new float[] { -1f, 0f, -1f },
                new float[] { -1f, 0f, -2f }
            };

        public static float[][] PartConstraintsBoxMax { get; private set; } = new float[][]
            {
                new float[] { 3f, 14f, 5f },
                new float[] { 3f, 8f, 5f },
                new float[] { 1f, 7f, -2f },
                new float[] { 1f, 7f, -2f },
                new float[] { 3f, 2f, 2f },
                new float[] { 2f, 1f, 2f },
                new float[] { 3f, 2f, 2f },
                new float[] { 2f, 1f, 1f }
            };

        

        public Vector3 GetBonePosition(PartIndex index)
        {
            int idx = (int)index;
            if (idx >= 0 && idx < PartBoneSpacePosition.Length)
                return PartBoneSpacePosition[idx];
            return new Vector3(0, 0, 0);
        }
        public ModelInfo this[PartIndex index]
        {
            get => this.Parts[(int)index];
        }

        
    }
}
