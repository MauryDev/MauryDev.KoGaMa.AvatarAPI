using MauryDev.KoGaMa.ModelAPI.KoGaMaTools;
using MessagePack;

namespace MauryDev.KoGaMa.AvatarAPI.KoGaMaTools.Dtos
{
    [MessagePackObject(keyAsPropertyName: true)]
    public class AvatarInfoDTO
    {
        public CubeInfoDTO[] Head { get; set; }
        public CubeInfoDTO[] Torso { get; set; }
        public CubeInfoDTO[] RArm { get; set; }
        public CubeInfoDTO[] LArm { get; set; }
        public CubeInfoDTO[] RUpLeg { get; set; }
        public CubeInfoDTO[] RLowLeg { get; set; }
        public CubeInfoDTO[] LUpLeg { get; set; }
        public CubeInfoDTO[] LLowLeg { get; set; }
    }
}
