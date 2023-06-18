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
            var hero = new Hero();
            hero.HasSword = true;

            // Act
            nightmare.Activate(hero, null);

            // Assert
            Assert.AreEqual(0, nightmare.Health); // Nightmare should be defeated
            Assert.AreEqual(100, hero.Health); // Hero's health should be restored to 100
            Assert.IsTrue(hero.HasSword); // Hero should still have the sword
        }
    }
}
