namespace MinotaurLabyrinthTest
{
    [TestFixture]
    public class NightmareTests
    {
        [Test]
        public void Activate_HeroWithSword_MonsterDefeatedAndHeroWins()
        {
            // Arrange
            var nightmare = new Nightmare();
            var hero = new Hero();
            hero.HasSword = true;

            // Act
            nightmare.Activate(hero, null);

            // Assert
            Assert.AreEqual(0, nightmare.Health); // Nightmare should be defeated
            Assert.AreEqual(100, hero.Health); // Hero's health should be restored to 100
            Assert.IsTrue(hero.HasSword); // Hero should still have the sword
            // Additional assertions specific to your game logic
        }

        [Test]
        public void Activate_HeroWithoutSword_HeroDefeatedAndMonsterWins()
        {
            // Arrange
            var nightmare = new Nightmare();
            var hero = new Hero();
            hero.HasSword = false;

            // Act
            nightmare.Activate(hero, null);

            // Assert
            Assert.AreEqual(0, hero.Health); // Hero should be defeated
            Assert.IsTrue(nightmare.Health > 0); // Nightmare should have remaining health
            Assert.IsTrue(hero.HasSword); // Hero should still not have the sword
            // Additional assertions specific to your game logic
        }

        [Test]
        public void DisplaySense_HeroDistanceOne_ReturnsExpectedMessage()
        {
            // Arrange
            var nightmare = new Nightmare();
            var hero = new Hero();
            int heroDistance = 1;

            // Act
            bool result = nightmare.DisplaySense(hero, heroDistance);

            // Assert
            Assert.IsTrue(result); // DisplaySense should return true
            // Additional assertions specific to the expected message
        }

        [Test]
        public void DisplaySense_HeroDistanceGreaterThanOne_ReturnsFalse()
        {
            // Arrange
            var nightmare = new Nightmare();
            var hero = new Hero();
            int heroDistance = 2;

            // Act
            bool result = nightmare.DisplaySense(hero, heroDistance);

            // Assert
            Assert.IsFalse(result); // DisplaySense should return false
        }
    }
}
