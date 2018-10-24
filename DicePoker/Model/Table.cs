using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicePoker.Model
{
    public class Table
    {
        public List<Player> Players;
        public Player p1;
        public Computer p2;
        public Player ActivePlayer;

        public Table()
        {
            Players = new List<Player>();
            p1 = new Player();
            p2 = new Computer();
            Players.Add(p1);
            Players.Add(p2);
            ActivePlayer = Players[0];
        }

        public void SwitchPlayer()
        {
            if (ActivePlayer == Players[0])
                ActivePlayer = Players[1];
            else ActivePlayer = Players[0];

        }
    }
}
