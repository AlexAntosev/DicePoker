using DicePoker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicePoker.Model
{
    public class Computer : Player
    {
        public void AutoChooseDicesToThrowAgain()
        {
            int[] DiceNumbersCounter = new int[6] { 0, 0, 0, 0, 0, 0 };
            foreach (Dice dice in Hand)
            {
                DiceNumbersCounter[dice.Value - 1]++;
            }
            MakeCombination();
            foreach (Dice dice in Hand)
            {
                if (dice.Value != CombinationValue) dice.IsThrown = false;
            }
        }
    }
}
