using MauryDev.KoGaMa.AvatarAPI.KoGaMaTools.Dtos;
using MauryDev.KoGaMa.ModelAPI.KoGaMaTools;
using System;
using System.Collections.Generic;
using System.Text;

namespace MauryDev.KoGaMa.AvatarAPI.KoGaMaTools.Mapping
{
    public class AvatarMapper : IAvatarMapper
    {
        public AvatarInfoDTO ToDto(AvatarInfo avatarInfo)
        {
            var parts = avatarInfo.Parts;
            return new AvatarInfoDTO
            {
                Head = ModelMapper.MapToDtoArray(parts[Enums.PartIndex.Head]),
                Torso = ModelMapper.MapToDtoArray(parts[Enums.PartIndex.Torso]),
                RArm = ModelMapper.MapToDtoArray(parts[Enums.PartIndex.RArm]),
                LArm = ModelMapper.MapToDtoArray(parts[Enums.PartIndex.LArm]),
                RUpLeg = ModelMapper.MapToDtoArray(parts[Enums.PartIndex.RUpLeg]),
                RLowLeg = ModelMapper.MapToDtoArray(parts[Enums.PartIndex.RLowLeg]),
                LUpLeg = ModelMapper.MapToDtoArray(parts[Enums.PartIndex.LUpLeg]),
                LLowLeg = ModelMapper.MapToDtoArray(parts[Enums.PartIndex.LLowLeg])
            };
        }

        public AvatarInfo ToDomain(AvatarInfoDTO dto)
        {
            var avatar = new AvatarInfo();

            var mapping = new Dictionary<Enums.PartIndex, CubeInfoDTO[]>
            {
                { Enums.PartIndex.Head, dto.Head },
                { Enums.PartIndex.Torso, dto.Torso },
                { Enums.PartIndex.RArm, dto.RArm },
                { Enums.PartIndex.LArm, dto.LArm },
                { Enums.PartIndex.RUpLeg, dto.RUpLeg },
                { Enums.PartIndex.RLowLeg, dto.RLowLeg },
                { Enums.PartIndex.LUpLeg, dto.LUpLeg },
                { Enums.PartIndex.LLowLeg, dto.LLowLeg }
            };

            foreach (var entry in mapping)
            {
                avatar[entry.Key] = ModelMapper.MapToModel(entry.Value);
            }

            return avatar;
        }
    }
}
