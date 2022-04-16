import { HttpClient } from '@angular/common/http';
import { EventEmitter, Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from '../../modelos/Catalogo/usuario';
import { Respuesta } from '../../modelos/respuesta';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
 
  modelo!: Usuario;
  cambioMenu= new EventEmitter<boolean>();
  constructor(  ) {
  }


   servicioLogin(){
      this.cambioMenu.emit(true);
   }

   guardarLogin(modelLogin: Usuario){
     this.modelo = modelLogin;
   }

   obtenerLogin(): Usuario {
    const json = window.localStorage.getItem('credencial');
    if (!json) {
      return {
        id: 0,
        nombreUsuario: '',
        password: '',
        rolUsuarioId: 0,
        rolUsuarioDescripcion: '',
      };
    }
    return JSON.parse(json);
  }
}
