import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from "@angular/common/http";
import { Observable, throwError } from 'rxjs';
import { Character } from '../models/character';
import { retry, catchError, tap, map } from 'rxjs/operators';
import { AuthService } from './auth.service';
import {ServiceResponse} from '../models/ServiceResponse'
import { TokenStorageService } from './token-storage.service';
import { addCharacterDto } from '../models/addCharacterDto';
import { coerceBooleanProperty } from '@angular/cdk/coercion';
const API_URL = 'https://localhost:44308/';


@Injectable({
  providedIn: 'root'
})
export class CharacterService {
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':'application/json;charset=utf-8',
    })
  };



  

  constructor(private http:HttpClient,private tokenService :TokenStorageService) {
   }
   getUsersCharacters(): Observable<Character[]> {
    return this.http.get<ServiceResponse<Character[]>>(API_URL + 'character')
    .pipe(map(res => <Character[]>res.data),
      retry(3),
      catchError(this.errorHandler)
    );
  }
  getAllCharacters(): Observable<Character[]> {
    return this.http.get<ServiceResponse<Character[]>>(API_URL + 'character/'+'add')
    .pipe(map(res => <Character[]> res.data),
      retry(3),
      catchError(this.errorHandler)
    );
  }
  getCharacter(id:number): Observable<Character> {
    return this.http.get<ServiceResponse<Character>>(API_URL + 'character/'+id)
    .pipe(map(res => <Character>res.data),
      retry(3),
      catchError(this.errorHandler)
    );
  }

  addCharacter(charId: number): Observable<ServiceResponse<Character[]>> {
    return this.http.post<ServiceResponse<Character[]>>(API_URL +'character', JSON.stringify(charId), this.httpOptions)
    .pipe(retry(1),
      catchError(this.errorHandler)
    );
}
   errorHandler(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
