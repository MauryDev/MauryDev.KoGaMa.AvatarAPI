using MauryDev.KoGaMa.AvatarAPI.Enums;
using MauryDev.KoGaMa.ModelAPI.Interfaces;
using MauryDev.KoGaMa.ModelAPI.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MauryDev.KoGaMa.AvatarAPI
{
    public interface IMVBody
    {
        IEnumerable<IMVModelCube> GetParts();
        IMVModelCube GetPart(string name);
        IMVModelCube GetPart(PartIndex index);

    }
}
