using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicePoker.Model
{
    public class Player
    {
        
        public int Money { get; set; }
        public string Name { get; set; }
        public Combinations Combination { get; set; }
        public ObservableCollection<Dice> Hand = new ObservableCollection<Dice>();  
        private int[] repeatsOfDicesValues = new int[6] { 0, 0, 0, 0, 0, 0 };
        public int CombinationValue { get; set; }

        public Player()
        {
            for(int i = 0; i < 5; i++)
            {
                Hand.Add(new Dice());
            }
            Money = 999;
            Name = "Computer";
        }
        
        public void MakeCombination()
        {
            Combinations currentCombination = Combinations.HIGH_HAND;
            CountRepeatsOfDicesValues();
            CombinationValue = 0;
            foreach (int repeat in repeatsOfDicesValues)
            {
                CombinationValue++;
                switch (repeat)
                {
                    case 5:
                        Combination = Combinations.POKER;
                        return;
                    case 4:
                        Combination = Combinations.CARE;
                        return;
                    case 3:
                        Combination = Combinations.SET;
                        return;
                    case 2:
                        if (currentCombination == Combinations.SET)
                        {
                            Combination = Combinations.FULL_HOUSE;
                            return;
                        }
                        if (currentCombination == Combinations.PAIR)
                        {
                            Combination = Combinations.TWO_PAIRS;
                            return;
                        }
                        currentCombination = Combinations.PAIR;
                        break;
                    default:
                        break;
                }
                Combination = currentCombination;
            }
        }

        public void CountRepeatsOfDicesValues()
        {
            foreach (Dice dice in Hand)
            {
                repeatsOfDicesValues[dice.Value - 1]++;
            }
        }
    }
}
