import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from "../_services/auth.service";
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {


  form : any = {};
  isSuccessfull = false;
  isSignUpFailed = false;
  errorMessage = '';
 
  constructor(private authService : AuthService,private router:Router) { }

  ngOnInit(): void {
  }
  onSubmit():void{
    this.authService.register(this.form).subscribe(
      data => {
        console.log(data);
        this.isSuccessfull = true;
        this.isSignUpFailed = false;
        this.router.navigate(['login']);
         
      },
      err => {
        this.errorMessage = err.error.message;
        this.isSignUpFailed =true;
      }
    );
  
  
  }

}
