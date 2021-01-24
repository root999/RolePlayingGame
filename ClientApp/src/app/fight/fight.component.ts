import { Component, OnInit } from '@angular/core';
import { FightService } from '../_services/fight.service';

@Component({
  selector: 'app-fight',
  templateUrl: './fight.component.html',
  styleUrls: ['./fight.component.css']
})
export class FightComponent implements OnInit {

  constructor(private fightService : FightService) { }

  ngOnInit(): void {
  }

}
