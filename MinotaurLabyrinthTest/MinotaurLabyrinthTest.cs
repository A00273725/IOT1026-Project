using MinotaurLabyrinth;

namespace MinotaurLabyrinthTest
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Activate_HeroWithSword_MonsterDefeatedAndHeroWins()
        {
            // Arrange
            var nightmare = new Nightmare();
            var hero = new Hero(new Location(0, 0));
            hero.HasSword = true;
            // Act
            nightmare.Activate(hero, null);
            // Assert
            Assert.AreEqual(0, nightmare.Health); // Nightmare should be defeated
            Assert.AreEqual(100, hero.Health); // Hero's health should be restored to 100
            Assert.IsTrue(hero.HasSword); // Hero should still have the sword
        }
        [TestMethod]
        public void DisplaySense_HeroDistanceGreaterThanOne_ReturnsFalse()
        {
            // Arrange
            var nightmare = new Nightmare();
            var hero = new Hero(new Location(0,0));
            int heroDistance = 2;
            // Act
            bool result = nightmare.DisplaySense(hero, heroDistance);
            // Assert
            Assert.IsFalse(result); // DisplaySense should return false
        }
        [TestMethod]
         public void Activate_HeroWithoutSword_HeroDefeatedAndMonsterWins()
        {
            // Arrange
            var nightmare = new Nightmare();
            var hero = new Hero(new Location(0,0));
            hero.HasSword = false;
            // Act
            nightmare.Activate(hero, null);
            // Assert
            Assert.AreEqual(0, hero.Health); // Hero should be defeated
            Assert.IsTrue(nightmare.Health > 0); // Nightmare should have remaining health
            Assert.IsFalse(hero.HasSword); // Hero should still not have the sword
        }
    }
}
