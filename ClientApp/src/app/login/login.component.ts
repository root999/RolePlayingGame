import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from "../_services/auth.service";
import { TokenStorageService } from "../_services/token-storage.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  form: any = {};
  isLoggedIn = false;
  isLoginFailed = false;
  errorMessage = '';
  role : string;


  constructor(private authService:AuthService, private tokenStorageService : TokenStorageService,private router:Router) { }

  ngOnInit(): void {
    if(this.tokenStorageService.getToken()){
      this.isLoggedIn = true;
      this.role = this.tokenStorageService.getRole()
      console.log("inside if")
      this.router.navigate(['characters']);
    }
    

  }

  onSubmit():void{
    this.authService.login(this.form).subscribe(
      data => {
       
       this.tokenStorageService.saveToken(data.data.token);
       this.tokenStorageService.saveUser(data.data.username);
       this.isLoginFailed = false;
       this.isLoggedIn = true;
       this.tokenStorageService.saveRole(data.data.role);
       this.role=data.data.role;
       this.reloadPage()
       
      },
      err =>{
        this.errorMessage = err.error.message;
        console.log(this.errorMessage);
        this.isLoginFailed = true;
      }
      


    );
  }
  reloadPage():void{
    window.location.reload();
  }
}
