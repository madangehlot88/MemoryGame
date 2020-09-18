using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using MemoryGame.Core.DataAccess;
using MemoryGame.Core.Services;
using MemoryGame.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MemoryGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {

        ShuffleService _shuffleService;
        GameService _gameService;
        public GameController(ShuffleService shuffleService, GameService gameService)
        {
            _shuffleService = shuffleService;
            _gameService = gameService;
        }


        [HttpGet]
        public IActionResult StartGame(int level)
        {


            if(level == 0)
            {
                return BadRequest("Required fields missing");
            }


            var cardsList = _shuffleService.ShuffleCards(level);

            if(cardsList != null)
            {

                //Save in session
                //Session will be stored in file
                //For security reason, we'll not save file in public wwwroot folder but in project root folder


                var boardId = Guid.NewGuid().ToString();

                System.IO.File.WriteAllText($@"game-boards\\{boardId}.json", JsonConvert.SerializeObject(cardsList));

                return Ok(new { boardId, cardsList  = cardsList.Select(c => new { c.Uuid }).ToList() } );


            }



            //System could not save game resource
            return NotFound();


        }


        [HttpPost]
        public IActionResult PlayGame(CardMoves cardMoves)
        {


            if(ModelState.IsValid)
            {


                var boardData = System.IO.File.ReadAllText($@"game-boards\\{cardMoves.boardId}.json");

                if(boardData != null)
                {

                    var cardsList = JsonConvert.DeserializeObject<List<ShuffledCards>>(boardData);

                    if(cardsList != null)
                    {
                        return Ok(new { result = _gameService.PlayGame(cardMoves, cardsList) });
                    }


                    return Ok(new { result = false });


                }



            }



            //System could not find game resource based on input
            return NotFound();


        }



    }
}
