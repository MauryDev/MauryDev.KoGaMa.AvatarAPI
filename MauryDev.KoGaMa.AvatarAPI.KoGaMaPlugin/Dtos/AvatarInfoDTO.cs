using MauryDev.KoGaMa.ModelAPI.KoGaMaTools;

namespace MauryDev.KoGaMa.AvatarAPI.KoGaMaTools.Dtos
{
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
