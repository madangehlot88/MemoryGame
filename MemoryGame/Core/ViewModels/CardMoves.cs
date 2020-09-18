using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryGame.Core.ViewModels
{
    public class CardMoves
    {
        [Required]
        public HashSet<string> cardMovements { get; set; }

        [Required]
        public string boardId { get; set; }


        [Required]
        public int level { get; set; }
    }
}
