using MemoryGame.Core.DataAccess;
using MemoryGame.Core.Interfaces;
using MemoryGame.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryGame.Core.Services
{


    public class ShuffleService : IShuffle
    {

        /// <summary>
        /// card moved per set
        /// </summary>
        private int CardMoves = 0;

        /// <summary>
        /// Current level 0 means no level
        /// </summary>
        private int CurrentLevel = 0;


        /// <summary>
        /// Assuming we've 0 cards in default state
        /// </summary>
        private int TotalCards = 0;


        /// <summary>
        /// Current card set
        /// </summary>
        private int CardCountInSet = 0;


        /// <summary>
        /// Method to get list of shuffled cards by level
        /// </summary>
        /// <param name="level"></param>
        public List<ShuffledCards> ShuffleCards(int level)
        {


            return ShuffleCardsByLevel(level);


        }




        /// <summary>
        /// Method to make business logic around cards shuffling
        /// </summary>
        /// <param name="level"></param>
        private List<ShuffledCards> ShuffleCardsByLevel(int level)
        {


            //Get info from db
            var levelConfig = new GameLevelsContext().GetGameLevels().FirstOrDefault(gl => gl.Level == level);


            //We've found a valid match in db if not null
            if(levelConfig != null)
            {

                //Iniitate variables
                this.CurrentLevel = level;
                this.CardMoves = levelConfig.CardCountInSet;
                this.TotalCards = this.CardMoves * this.CardCountInSet;
             

                //We know CurrentLevel, CardCountInSet, IdenticalCardsSets and TotalCards
                var cardsList = new List<ShuffledCards>();

                for(int i = 0; i < CardCountInSet; i++)
                {
                    for(int j = 0; j < CardMoves; j++)
                    {

                        cardsList.Add(new ShuffledCards()
                        {
                            Uuid = Guid.NewGuid().ToString(),
                            CardContent = $"{i + 1}"

                        });


                    }

                }

                //Randomize the list

                return cardsList.OrderBy(x => Guid.NewGuid()).ToList();


            }


            return new List<ShuffledCards>();



        }




    }
}
