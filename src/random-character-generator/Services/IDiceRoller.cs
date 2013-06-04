using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace random_character_generator.Services
{
    public interface IDiceRoller
    {
        int d100();
        int d2();
        int d20();
        int d12();
        int d10();
        int d8();
        int d6();
        int d4();
        int d3();
    }
    public class DiceRoller : IDiceRoller
    {
        private readonly Random Random;
        public object d2()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Initializes a new instance of the DiceRoller class.
        /// </summary>
        /// <param name="random"></param>
        public DiceRoller(Random random)
        {
            Random = random;
        }
        #region IDiceRoller Members

        public int d100()
        {
            return Random.Next(1, 101);
        }

        public int d20()
        {
            return Random.Next(1, 21);
        }

        public int d12()
        {
            return Random.Next(1, 13);
        }

        public int d10()
        {
            return Random.Next(1, 11);
        }

        public int d8()
        {
            return Random.Next(1, 9);
        }

        public int d6()
        {
            return Random.Next(1, 7);
        }

        public int d4()
        {
            return Random.Next(1, 5);
        }

        public int d3()
        {
            return Random.Next(1, 4);
        }


        int IDiceRoller.d2()
        {
            return Random.Next(1, 3);
        }

        #endregion
    }
}