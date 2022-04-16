import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Usuario } from '../data/modelos/Catalogo/usuario';
import { LoginService } from '../data/servicios/login/login.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  /**
   *
   */
  modelo!: Usuario;
  mostrarMenu = false;
  esSupervisor = false;
  constructor(private emit: LoginService, private router: Router) {
    this.mostrarBar();
  }
  ngOnInit(): void {
    this.emit.cambioMenu.subscribe(e => {
      if (e) {
        this.mostrarBar();
      }
    })
  }
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  public obtenerCredencial(): Usuario {
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

  mostrarBar() {
    console.log(window.localStorage.getItem('credencial'))
    if (window.localStorage.getItem('credencial') !== null) {
      this.modelo = this.obtenerCredencial();
      if (this.modelo.rolUsuarioId == 2) {
        this.esSupervisor = true;
      }
      this.mostrarMenu = true;

    } else {
      this.mostrarMenu = false;
    }

  }
  salir() {
    window.localStorage.removeItem('credencial');
    this.mostrarMenu = false;
    this.router.navigate(['/']);
  }
}
