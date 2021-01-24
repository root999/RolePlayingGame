import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { Character } from '../models/character';
import { CharacterService } from '../_services/character.service';

@Component({
  selector: 'app-character',
  templateUrl: './character.component.html',
  styleUrls: ['./character.component.css']
})
export class CharacterComponent implements OnInit {
  id :number
  character$ : Observable<Character>;
  constructor(private characterService:CharacterService,private avRouter : ActivatedRoute) { 
    const idParam = 'id';
    if(this.avRouter.snapshot.params[idParam]){
      this.id = this.avRouter.snapshot.params[idParam]
    }
    
  }

  ngOnInit(): void {
    this.loadCharacter();
  }
  loadCharacter(){
    this.character$ =this.characterService.getCharacter(this.id)
  }
}
