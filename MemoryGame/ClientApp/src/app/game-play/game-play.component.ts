import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-game-play',
  templateUrl: './game-play.component.html',
  styleUrls: ['./game-play.component.css']
})
export class GamePlayComponent implements OnInit {

  gameLevel = "";

  constructor(
    private route: ActivatedRoute,
  ) { }

  ngOnInit() {

    //Take selected game level from query string
    this.route.queryParams.subscribe(params => {
      const query = params['level'];

      if (query !== undefined && query !== "") {

        this.gameLevel = query;

      }
    });




  }

}
