using NUnit.Framework;
using SuperFarmer.PlayArea;
using SuperFarmer.DataModell;

namespace SuperFarmerTest
{
    public class TestDices
    {
        private AnimalEnum[] _reddice = { AnimalEnum.SmallDog,
            AnimalEnum.BigDog, AnimalEnum.Fox, AnimalEnum.Horse };

        private AnimalEnum[] _bluedice = { AnimalEnum.SmallDog,
            AnimalEnum.BigDog, AnimalEnum.Cow, AnimalEnum.Wolf };

        [Test]
        public void Test1()
        {
            Assert.True(true);

        }
    }
}