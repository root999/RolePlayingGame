import { Injectable } from '@angular/core';

const TOKEN_KEY = 'auth-token';
const USER_KEY = 'auth-user';
const ROLE_KEY = 'auth-user-role';


@Injectable({
  providedIn: 'root'
})
export class TokenStorageService {

  constructor() { }

  signOut():void{
    window.sessionStorage.clear();
  }
  public saveToken(token:string):void{
    window.sessionStorage.removeItem(TOKEN_KEY);
    window.sessionStorage.setItem(TOKEN_KEY,token);
  }
  public getToken():string {
    return sessionStorage.getItem(TOKEN_KEY);
  }
  public saveUser(user):void{
    window.sessionStorage.removeItem(USER_KEY);
    window.sessionStorage.setItem(USER_KEY,user);
  }
  public saveRole(role:string):void{
    window.sessionStorage.removeItem(ROLE_KEY);
    window.sessionStorage.setItem(ROLE_KEY,role);
  }
  public getUser():any{
    return window.sessionStorage.getItem(USER_KEY);
  }
  public getRole():any{
    return window.sessionStorage.getItem(ROLE_KEY);
  }
  

}
