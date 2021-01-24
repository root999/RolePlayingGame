import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Character } from '../models/character';
import { ServiceResponse } from '../models/ServiceResponse';
import { CharacterService } from '../_services/character.service';
import { TokenStorageService } from '../_services/token-storage.service';

@Component({
  selector: 'app-characters',
  templateUrl: './characters.component.html',
  styleUrls: ['./characters.component.css']
})
export class CharactersComponent implements OnInit {
  characters$ : Observable<Character[]>
  constructor(private characterService: CharacterService,private tokenService:TokenStorageService,private router : Router) { 

  }

  ngOnInit(): void {
    if(this.tokenService.getToken()){
      this.loadCharacters();
    }
    else{
      this.router.navigate(['/login'])
    }

   
  }


  loadCharacters(){
  this.characters$ = this.characterService.getUsersCharacters()
  
   
  }
}
