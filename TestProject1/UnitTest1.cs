using MauryDev.KoGaMa.AvatarAPI;
using MauryDev.KoGaMa.AvatarAPI.KoGaMaTools;
using MauryDev.KoGaMa.AvatarAPI.KoGaMaTools.Dtos;
using MauryDev.KoGaMa.AvatarAPI.KoGaMaTools.Mapping;
using MessagePack;
using ModelAPI = MauryDev.KoGaMa.ModelAPI;

namespace TestProject1
{
    
    [TestFixture]
    public class AvatarToolsTests
    {
        private AvatarMapper _mapper;
        private KGMTSerializer _serializer;

        [SetUp]
        public void Setup()
        {
            _mapper = new AvatarMapper();
            _serializer = new KGMTSerializer(_mapper);
        }

        [Test]
        public void AvatarMapper_ToDto_MapsCorrectly()
        {
            using var file = File.OpenRead("C:\\Users\\Maury\\Downloads\\Arquivos de Skins\\Arquivos de Skins\\Puppy Minecrft skin\\PuppyMinecraftSkin");
            ISerializer serializer = new KGMTSerializer();

            var test = serializer.Deserialize(file);
            Console.WriteLine(test);
            
        }

        
    }
}