import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from "@angular/common/http";
import { Observable, throwError } from 'rxjs';
import { ServiceResponse } from '../models/ServiceResponse';
import { FightResultDto } from '../models/FightResultDto';
import { FightRequestDto } from '../models/FightRequestDto';
import { retry, catchError, tap, map } from 'rxjs/operators';

const API_URL = 'https://localhost:44308/';

@Injectable({
  providedIn: 'root'
})

export class FightService {

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':'application/json;charset=utf-8',
    })
  };

  constructor(private http:HttpClient) { }

  fight(request : FightRequestDto): Observable<ServiceResponse<FightResultDto>>{
    return this.http.post<ServiceResponse<FightResultDto>>(API_URL+'fight',JSON.stringify(request),this.httpOptions).pipe(
      retry(1),
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