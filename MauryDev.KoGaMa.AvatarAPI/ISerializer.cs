using System.IO;

namespace MauryDev.KoGaMa.AvatarAPI
{
    public interface ISerializer
    {
        void Serialize(Stream stream, AvatarInfo avatar);
        AvatarInfo Deserialize(Stream stream);
    }
}
