using Marave.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestGame
{
    public class TestMerlin
    {
        [Fact(DisplayName = "Test le renforcement d'armur de l'ennemy")]
        public void TestCheckEndGameRoundLessThanTwenty()
        {
            //Arrange
            Merlin merlin = new Merlin();
            Hero hero = new Hero();
            //Act
            //Assert
            Assert.True(merlin.CheckEndGame(hero, 2));
        }

        [Fact(DisplayName = "Test le renforcement d'armur de l'ennemy")]
        public void TestCheckEndGameRoundGreaterThanTwenty()
        {
            //Arrange
            Merlin merlin = new Merlin();
            Hero hero = new Hero();
            //Act
            //Assert
            Assert.False(merlin.CheckEndGame(hero, 21));
        }
        [Fact(DisplayName = "Test le renforcement d'armur de l'ennemy")]
        public void TestCheckEndGameRound()
        {
            //Arrange
            Merlin merlin = new Merlin();
            Hero hero = new Hero();
            //Act
            for (int i = 0; i < 10; i++)
                hero.Attack(hero);
            //Assert
            Assert.False(merlin.CheckEndGame(hero, 2));
        }
    }
}
