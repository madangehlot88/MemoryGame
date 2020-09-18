using MemoryGame.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryGame.Core.Interfaces
{
    interface IShuffle
    {
        List<ShuffledCards> ShuffleCards(int level);

    }
}
