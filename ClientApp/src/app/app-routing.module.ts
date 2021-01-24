import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CharacterAddComponent } from './character-add/character-add.component';
import { CharacterComponent } from './character/character.component';
import { CharactersComponent } from './characters/characters.component';
import { FightComponent } from './fight/fight.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  {path : 'register',component:RegisterComponent},
  {path : 'login',component:LoginComponent},
  {path : 'characters',component:CharactersComponent},
  {path: 'character/:id',component:CharacterComponent},
  {path: 'characters/add',component:CharacterAddComponent},
  {path: 'fight',component:FightComponent}

  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
