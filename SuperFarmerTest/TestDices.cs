using NUnit.Framework;
using SuperFarmer.PlayArea;
using SuperFarmer.DataModell;

namespace SuperFarmerTest
{
    public class TestDices
    {
        private AnimalEnum[] _reddice = { AnimalEnum.smallDog,
            AnimalEnum.bigDog, AnimalEnum.fox, AnimalEnum.horse };

        private AnimalEnum[] _bluedice = { AnimalEnum.smallDog,
            AnimalEnum.bigDog, AnimalEnum.cow, AnimalEnum.wolf };

        [Test]
        public void Test1()
        {
            (AnimalEnum, AnimalEnum) a = Dices.RollDices();
            Assert.IsNotNull(a.Item1);
            foreach(AnimalEnum impossibleAnimals in _reddice)
            {
                Assert.AreNotEqual(impossibleAnimals, a.Item1);
            }

            Assert.IsNotNull(a.Item2);
            foreach (AnimalEnum impossibleAnimals in _bluedice)
            {
                Assert.AreNotEqual(impossibleAnimals, a.Item1);
            }

        }
    }
}