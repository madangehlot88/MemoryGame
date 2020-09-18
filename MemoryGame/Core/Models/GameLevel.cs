using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryGame.Core.Models
{
    public class GameLevel
    {

        /// <summary>
        /// Game level
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Cards per set
        /// </summary>
        public int CardCountInSet { get; set; }


        /// <summary>
        /// How many times card can be moved, also duplicate cards set
        /// </summary>
        public int CardMoves { get; set; }
    }
}
