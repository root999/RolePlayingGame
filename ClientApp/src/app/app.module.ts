import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import{ HttpClientModule} from "@angular/common/http"
import {FormsModule} from "@angular/forms"
import { ReactiveFormsModule } from "@angular/forms";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';
import { authInterceptorProviders } from './_helpers/auth.interceptor';
import { CharactersComponent } from './characters/characters.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule} from '@angular/material/toolbar';
import {MatFormFieldModule,MatLabel} from "@angular/material/form-field";
import {MatButtonModule} from '@angular/material/button';
import { CharacterComponent } from './character/character.component';
import { CharacterAddComponent } from './character-add/character-add.component';
import { MatSelectModule } from "@angular/material/select";
import { FightComponent } from './fight/fight.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    CharactersComponent,
    CharacterComponent,
    CharacterAddComponent,
    FightComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatSelectModule,
    MatFormFieldModule,
    MatButtonModule,
    ReactiveFormsModule,
   
  ],
  providers: [authInterceptorProviders],
  bootstrap: [AppComponent]
})
export class AppModule { }
