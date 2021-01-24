import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, pipe } from 'rxjs';
import  {map} from 'rxjs/operators';
import { Character } from '../models/character';
import { CharacterService } from '../_services/character.service';
import { TokenStorageService } from '../_services/token-storage.service';
import { FormGroup, FormControl, Validators} from '@angular/forms';
import { addCharacterDto } from '../models/addCharacterDto';
import { ServiceResponse } from '../models/ServiceResponse';
@Component({
  selector: 'app-character-add',
  templateUrl: './character-add.component.html',
  styleUrls: ['./character-add.component.css']
})
export class CharacterAddComponent implements OnInit {
  charAdded : boolean;
  characters$ :Observable<Character[]>;
  deneme : Character[];
  message : string;
  selectedCharacter : Character =null;
  form = new FormGroup({

    addChar: new FormControl('', Validators.required)

  });
  constructor(private characterService:CharacterService,private tokenService:TokenStorageService,private router:Router) {

   }
  

  ngOnInit(): void {
    if(this.tokenService.getToken()){
      this.loadFormCharacters();
    }
  }
  loadFormCharacters(){
    this.characters$ = this.characterService.getAllCharacters()
  
  }

  get fo(){
    return this.form.controls;
  }
  
  submit(){
    this.selectedCharacter = this.form.value.addChar;
    
  this.characterService.addCharacter(this.selectedCharacter.id).subscribe(
    data =>{
      this.charAdded = data.success,
      this.message = data.message,
      console.log("in data");  
    },
    err =>{
      this.message = err.error.message;
      console.log("in err");  
      this.charAdded = false;
    }
    
   
  );

   
  }
  changeWebsite(e) {
    this.selectedCharacter = this.form.value.addChar
  }
}
