using MemoryGame.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryGame.Core.DataAccess
{
    public class GameLevelsContext
    {
        public List<GameLevel> GetGameLevels()
        {

            return new List<GameLevel>()
            {
                new GameLevel()
                {
                    Level = 1,
                    CardCountInSet = 5,
                    CardMoves = 2
                },
                 new GameLevel()
                {
                    Level = 2,
                    CardCountInSet = 10,
                    CardMoves = 2
                },
                  new GameLevel()
                {
                    Level = 3,
                    CardCountInSet = 25,
                    CardMoves = 2
                }

            };




        }
        
    }
}
