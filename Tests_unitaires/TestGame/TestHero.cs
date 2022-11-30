using Marave.classes;
using Xunit;

namespace TestGame
{
    public class TestHero
    {
        [Fact(DisplayName ="Test le  niveau du héro")]
        public void TestHeroSetLevel()
        {
            //Arrange
            Hero hero = new Hero();
            //Act
            hero.SetLevel(5);
            //Assert
            Assert.Equal(5, hero.GetLevel());
        }
        [Fact(DisplayName = "Test l'ajout de point d'armur")]
        public void TestHeroSetArmor()
        {
            //Arrange
            Hero hero = new Hero();
            //Act
            hero.AddArmor();
            //Assert
            Assert.Equal(16, hero.GetArmor());
            Assert.Equal(11, hero.GetAvailableCharacteristic());
        }
        [Fact(DisplayName = "Test l'ajout de point d'armur")]
        public void TestAvailableCharacteristic()
        {
            //Arrange
            Hero hero = new Hero();
            //Act
            hero.AddAvailableCharacteristic(1);
            //Assert
            Assert.Equal(13, hero.GetAvailableCharacteristic());
        }
        [Fact(DisplayName = "Test l'ajout de point d'armur")]
        public void TestHeroSetHealth()
        {
            //Arrange
            Hero hero = new Hero();
            //Act
            hero.SetCurrentHealth(10);
            //Assert
            Assert.Equal(10, hero.GetCurrentHealth());
        }/*
        [Fact(DisplayName = "Test l'ajout de point d'armur")]
        public void TestHeroMaxHealth()
        {
            //Arrange
            Hero hero = new Hero();
            //Act
            hero.SetMaxHealth();
            //Assert
            Assert.Equal(10, hero.GetCurrentHealth());
        }*/
        [Fact(DisplayName = "Test si le héro est mort")]
        public void TestHeroIsDead()
        {
            //Arrange
            Hero hero = new Hero();
            Hero hero1 = new Hero();
            //Act
            for(int i = 0; i < 10; i++)
            hero1.Attack(hero);
            //Assert
            Assert.True(hero.IsDead());
        }
    }
}