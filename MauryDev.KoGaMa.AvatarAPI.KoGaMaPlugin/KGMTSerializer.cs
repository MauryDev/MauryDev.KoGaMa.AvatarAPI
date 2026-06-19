using MauryDev.KoGaMa.AvatarAPI.KoGaMaTools.Dtos;
using MauryDev.KoGaMa.AvatarAPI.KoGaMaTools.Mapping;
using MauryDev.KoGaMa.ModelAPI.KoGaMaTools;
using MessagePack;
using System;
using System.IO;

namespace MauryDev.KoGaMa.AvatarAPI.KoGaMaTools
{
    public class KGMTSerializer : ISerializer
    {
        private readonly IAvatarMapper _mapper;


        
        public KGMTSerializer(IAvatarMapper mapper = default)
        {
            _mapper = mapper ?? new AvatarMapper();
        }

        public AvatarInfo Deserialize(Stream stream)
        {
            var dto = MessagePackSerializer.Deserialize<AvatarInfoDTO>(stream);
            return _mapper.ToDomain(dto);
        }

        public void Serialize(Stream stream, AvatarInfo avatar)
        {
            var dto = _mapper.ToDto(avatar);
            MessagePackSerializer.Serialize(stream, dto);
        }
    }
}
