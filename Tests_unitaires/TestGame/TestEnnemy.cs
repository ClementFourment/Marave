using Marave.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestGame
{
    public class TestEnnemy
    {
        [Fact(DisplayName = "Test le renforcement d'armur de l'ennemy")]
        public void TestEnnemyRedefineArmor()
        {
            //Arrange
            Enemy enemy = new Enemy();
            //Act
            enemy.RedefineArmor(1);
            //Assert
            Assert.Equal(14, enemy.GetArmor());
        }
        [Fact(DisplayName = "Test le renforcement de force de l'ennemy")]
        public void TestEnnemyRedefineStrength()
        {
            //Arrange
            Enemy enemy = new Enemy();
            //Act
            enemy.RedefineStrength(1);
            //Assert
            Assert.Equal(14, enemy.GetStrength());
        }
        [Fact(DisplayName = "Test le renforcement de la santé pour l'ennemy")]
        public void TestEnnemyRedefineHealth()
        {
            //Arrange
            Enemy enemy = new Enemy();
            //Act
            enemy.RedefineHealth(1);
            //Assert
            Assert.Equal(27, enemy.GetCurrentHealth());
            Assert.Equal(27, enemy.GetMaxHealth());
        }
    }
}
