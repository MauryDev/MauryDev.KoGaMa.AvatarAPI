using MauryDev.KoGaMa.AvatarAPI.KoGaMaTools.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MauryDev.KoGaMa.AvatarAPI.KoGaMaTools.Mapping
{
    public interface IAvatarMapper
    {
        AvatarInfoDTO ToDto(AvatarInfo avatarInfo);
        AvatarInfo ToDomain(AvatarInfoDTO avatarDto);
    }
}
