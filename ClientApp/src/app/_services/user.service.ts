import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";



const API_URL = 'http://localhost:44308/';

@Injectable({
  providedIn: 'root'
})

export class UserService {



  constructor(private http:HttpClient) { }

  getCharacters(): Observable<any> {
    return this.http.get(API_URL + 'all', { responseType: 'text' });
  }
}
