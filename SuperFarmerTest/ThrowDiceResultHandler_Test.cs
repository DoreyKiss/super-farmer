using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using SuperFarmer.PlayArea;
using SuperFarmer.DataModell;

namespace SuperFarmerTest
{
    [TestFixture]
    public class DiceThrowResultHandler_Test
    {

        private CoinDeck _deck;
        private DiceThrowResultHandler _resultHandler = new DiceThrowResultHandler();
        private Hand _hand;
        private BlueDice _blueDice = new BlueDice();
        private RedDice _redDice = new RedDice();
        private List<HandEnum> _handEnums = new List<HandEnum>() { HandEnum.Bunny,
                                                                   HandEnum.Sheep,
                                                                   HandEnum.Pig,
                                                                   HandEnum.Cow,
                                                                   HandEnum.Horse,
                                                                   HandEnum.SmallDog,
                                                                   HandEnum.BigDog};

        [SetUp]
        public void Setup()
        {
            _hand = new Hand();
            _deck = new CoinDeck();
        }


        //lets not look of the fact that the elements in the hand are not substracted from the deck and it is
        //not possible to have 5 big dogs in a hand.
        //new elements to the deck shall only be added via coin exchange, or dicethrow
        [Test]
        public void Add_to_uneven_number_of_animals_throw_one_of_the_kind_Test()
        {
            HandEnum lastAnimal = _handEnums[_handEnums.Count-1];
            foreach (var animal in _handEnums)
            {
                _hand.AddAnimal(animal, 3);
                var exceptedCoinNumber = _deck.Coins[animal]-2;
                _resultHandler.GetResult(_hand,(AnimalEnum)animal, (AnimalEnum)lastAnimal, _deck);
                Assert.AreEqual(5, _hand.GetAnimal(animal));
                Assert.AreEqual(exceptedCoinNumber,_deck.Coins[animal]);
                lastAnimal = animal;
            }
        }

        [Test]
        public void Add_to_uneven_number_of_animals_throw_two_of_the_kind_Test()
        {
            foreach (var animal in _handEnums)
            {
                _hand.AddAnimal(animal, 3);
                var exceptedCoinNumber = _deck.Coins[animal] - 2;
                _resultHandler.GetResult(_hand, (AnimalEnum)animal, (AnimalEnum)animal, _deck);
                Assert.AreEqual(5, _hand.GetAnimal(animal));
                Assert.AreEqual(exceptedCoinNumber, _deck.Coins[animal]);
            }
        }

        [Test]
        public void Wolf_is_Comming_Test()
        {
            int numberOfAnimalsAdded = 1;
            foreach (var animal in _handEnums)
            {
                _hand.AddAnimal(animal, numberOfAnimalsAdded);
            }

            _resultHandler.GetResult(_hand, AnimalEnum.Pig ,AnimalEnum.Wolf, _deck);

            foreach (var animal in _hand.GetElementInHand)
            {
                if(animal.Key == HandEnum.BigDog)
                {
                    Assert.AreEqual(numberOfAnimalsAdded-1, animal.Value);
                    continue;
                }
                else if(animal.Key == HandEnum.Pig)
                {
                    Assert.AreEqual(numberOfAnimalsAdded+1, animal.Value);
                    continue;
                }
                Assert.AreEqual(numberOfAnimalsAdded, animal.Value);
            }

            _resultHandler.GetResult(_hand, AnimalEnum.Pig, AnimalEnum.Wolf, _deck);
            _hand.AddAnimal(HandEnum.BigDog, 1);

            for (int i = 0; i <_handEnums.Count ; i++)
            {
                if(i<(int)HandEnum.Horse)
                {
                    Assert.AreEqual(0,_hand.GetAnimal( _handEnums[i]));
                    continue;
                }
                Assert.AreEqual(numberOfAnimalsAdded, _hand.GetAnimal( _handEnums[i]));
            }               
        }

        [Test]
        public void Fox_is_Comming_Test()
        {
            _hand = new Hand();
            int numberOfAnimalsAdded = 1;
            foreach (var animal in _handEnums)
            {
                _hand.AddAnimal(animal, numberOfAnimalsAdded);
            }

            _resultHandler.GetResult(_hand, AnimalEnum.Fox, AnimalEnum.Bunny, _deck);

            foreach (var animal in _hand.GetElementInHand)
            {
                if (animal.Key == HandEnum.SmallDog)
                {
                    Assert.AreEqual(numberOfAnimalsAdded - 1, animal.Value, message: "1");
                    continue;
                }
                else if(animal.Key == HandEnum.Bunny)
                {
                    Assert.AreEqual(numberOfAnimalsAdded + 1, animal.Value, message: "2");
                    continue;
                }
                Assert.AreEqual(numberOfAnimalsAdded, animal.Value, message: "excepted number of " +animal +" was.. ");
            }

            _resultHandler.GetResult(_hand, AnimalEnum.Fox, AnimalEnum.Bunny, _deck);

            foreach (var animal in _hand.GetElementInHand)
            {
                if (animal.Key == HandEnum.Bunny || animal.Key == HandEnum.SmallDog)
                {
                    Assert.AreEqual(0, animal.Value);
                    continue;
                }
                Assert.AreEqual(numberOfAnimalsAdded, animal.Value);
            }
        }
    }
}
