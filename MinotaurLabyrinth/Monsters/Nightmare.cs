namespace MinotaurLabyrinth
{
    /// <summary>
    /// Represents a custom monster in the game.
    /// </summary>
    public class Nightmare : Monster
    {
        public int Health { get; set; } = 100;


        public override void Activate(Hero hero, Map map)
        {
            const int HeroAttackDamageWithSword = 20;
            const int HeroAttackDamageWithoutSword = 10;
            const int MonsterRegularAttackDamage = 10;
            const int MonsterSpecialAttackDamage = 30;

            bool heroHasSword = hero.HasSword;
            int turnCount = 1;

            while (hero.Health > 0 && Health > 0)
            {
                // Monster attacks the hero
                if (hero.Health <= 0)
                {
                    break; // Hero defeated
                }

                if (turnCount % 3 == 0)
                {
                    hero.Health -= MonsterSpecialAttackDamage;
                    Console.WriteLine($"Nightmare unleashes a powerful attack on the hero! The hero loses {MonsterSpecialAttackDamage} health.");
                }
                else
                {
                    hero.Health -= MonsterRegularAttackDamage;
                    Console.WriteLine($"Nightmare attacks the hero! The hero loses {MonsterRegularAttackDamage} health.");
                }

                if (hero.Health <= 0)
                {
                    break; // Hero defeated
                }

                // Hero attacks the monster
                if (heroHasSword)
                {
                    Health -= HeroAttackDamageWithSword;
                    Console.WriteLine($"The hero strikes Nightmare with a mighty blow! Nightmare loses {HeroAttackDamageWithSword} health.");
                }
                else
                {
                    Health -= HeroAttackDamageWithoutSword;
                    Console.WriteLine($"The hero attacks Nightmare! Nightmare loses {HeroAttackDamageWithoutSword} health.");
                }

                if (Health <= 0)
                {
                    break; // Monster defeated
                }

                // Increment the turn count
                turnCount++;
            }

            if (hero.Health <= 0)
            {
                hero.Kill("Hero defeated"); // Hero defeated
            }
            else
            {
                // Monster defeated
                // Restore hero's health to 100
                hero.Health = 100;

                // Give the hero a sword if they don't have one
                if (!heroHasSword)
                {
                    hero.HasSword = true;
                }


            }
        }



        public override bool DisplaySense(Hero hero, int heroDistance)
        {
            if (heroDistance == 1)
            {
                ConsoleHelper.WriteLine("It is getting darker, seems like a Nightmare ahead! Be Careful!", ConsoleColor.Red);
                return true;
            }
            return false;
        }

        public override DisplayDetails Display()
        {
            return new DisplayDetails("[N]", ConsoleColor.Red);
        }
    }
}
