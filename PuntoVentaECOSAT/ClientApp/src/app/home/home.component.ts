import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Usuario } from '../data/modelos/Catalogo/usuario';
import { Respuesta } from '../data/modelos/respuesta';
import { LoginService } from '../data/servicios/login/login.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls:['./home.component.css']
})
export class HomeComponent implements OnInit {
  hide = true;
  form!: FormGroup;
  modelo!: Usuario;
  mostrarMenu=false;
  esSupervisor=false;
  get f(){return this.form.controls} 
  constructor(
     private formBuilder:FormBuilder, 
    private loginServices: LoginService,public http: HttpClient, @Inject('BASE_URL') public baseUrl: string,private router:Router,private emit:LoginService ){
      if (window.localStorage.getItem('credencial') !== null) { router.navigate(['/Venta'])}
  }
  
  
  ngOnInit(): void {
    this.form = this.formBuilder.group({
      id: [0],
    nombreUsuario: ['',Validators.required],
    password: ['',Validators.required],
    rolUsuarioId: [0],
    rolUsuarioDescripcion: [''],
    })
  }

//  ingresar (){
//   const model = this.form.value as Usuario;
//   this.loginServices.login().fierro().toPromise().then( e => {
//     this.loginServices.servicioLogin(model);
//     localStorage.setItem('usuario', JSON.stringify(model));
//     //this.nav.navigateRoot('calendario');

//   })
//  }
  
inciarSesion():void{
    const model=this.form.value as Usuario

    if(this.form.valid){
      this.http.post<Respuesta>(this.baseUrl + 'api/Usuario',model).toPromise().then(e=>{
        if(e.estatus){
          window.localStorage.setItem('credencial', JSON.stringify(e.objeto));
          this.emit.guardarLogin(model);
          this.emit.servicioLogin();
          this.router.navigate(['/Venta'])
        }
      });
    }else{
      alert('Formulario no valido');
     

    }
  }


}
