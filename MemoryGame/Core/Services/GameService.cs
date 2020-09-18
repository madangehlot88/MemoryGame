using MemoryGame.Core.DataAccess;
using MemoryGame.Core.Interfaces;
using MemoryGame.Core.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryGame.Core.Services
{
    public class GameService : IGame
    {
        public bool PlayGame(CardMoves cardMoves, List<ShuffledCards> cardsList)
        {

          
            //For opted level, find it's config

            var levelConfig = new GameLevelsContext().GetGameLevels().FirstOrDefault(l => l.Level == cardMoves.level);

            //If required card moves equals card moves in api else deny

            if (cardMoves.cardMovements.Count > 0 && cardMoves.cardMovements.Count == levelConfig.CardCountInSet)
            {

                HashSet<string> matchedMovements = new HashSet<string>();

                foreach (var item in cardMoves.cardMovements)
                {

                    var cardData = cardsList.FirstOrDefault(cd => cd.Uuid == item);
                    if (cardData != null)
                    {
                        matchedMovements.Add(cardData.CardContent);

                    }


                }


                //If hashset has only one item, because uniuqe card value will be just one, it means it's a match

                return matchedMovements.Count == 1;


            }


            return false;

        }
    }
}
