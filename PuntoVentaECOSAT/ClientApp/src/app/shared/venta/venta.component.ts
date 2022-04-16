import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { startWith, map } from 'rxjs/operators';
import { Usuario } from 'src/app/data/modelos/Catalogo/usuario';
import { Respuesta } from 'src/app/data/modelos/respuesta';
import { Producto } from 'src/app/data/modelos/Tienda/producto';
import { SubVenta } from 'src/app/data/modelos/Venta/subventa';
import { Venta } from 'src/app/data/modelos/Venta/venta';
import { LoginService } from 'src/app/data/servicios/login/login.service';
import { ProductoService } from 'src/app/data/servicios/producto/producto.service';

@Component({
  selector: 'app-venta',
  templateUrl: './venta.component.html',
  styleUrls: ['./venta.component.css']
})
export class VentaComponent implements OnInit {

  totalVenta = 0;
  forma!: FormGroup;
  listaSubVenta: SubVenta[] = [];
  precioPrdto = 0;
  get f() { return this.forma.controls; }
  controlPrdto = new FormControl();
  listadoPrdto: Producto[] = [];
  filtroPrdto!: Observable<Producto[]>;

  prdto!:Producto;
  modelo!: Venta;
  usuario!:Usuario;
  constructor(private formBuilder: FormBuilder, private nav: Router,public http: HttpClient, @Inject('BASE_URL') public baseUrl: string, private loginServices: LoginService) { }

  ngOnInit(): void {
    this.forma = this.formBuilder.group({
      id: [0],
      productoDescripcion: ['', [Validators.required]],
      productoId: [0],
      cantidad: [0,[Validators.required]],
      importe: [0],
    });
    this.cargarProductos();
    this.usuario = this.loginServices.obtenerLogin();
    console.log(this.usuario.id)
  }

  guardar() {
    if(this.listaSubVenta.length > 0) {
      this.http.post<Respuesta>(this.baseUrl + 'api/venta/'+this.usuario.id,this.listaSubVenta).subscribe(e => {
        if (e.estatus) {
          alert(e.mensaje);
        } else{ 
         alert(e.mensaje); 
        }
      });
    } else {
     alert('Agrega Productos al Carrito');
    }

  }
  agregarLista() {
    if (this.forma.valid && this.forma) {
      const modelo = this.forma.value as SubVenta;
      const lista = this.listaSubVenta.find(e => e.productoDescripcion === modelo.productoDescripcion);
      console.log(lista);
      if (modelo.cantidad > 0) {
        if (lista === undefined) {
          modelo.importe = this.precioPrdto * modelo.cantidad;
          this.totalVenta += modelo.importe;
         this.listaSubVenta.push(modelo)
        // modelo.productoDescripcion=" ";
         console.log(this.listaSubVenta)
        } else {
          this.totalVenta -=  lista.cantidad * this.precioPrdto;
          lista.cantidad = (+modelo.cantidad + +lista.cantidad);
          lista.importe = lista.cantidad * this.precioPrdto;
          this.totalVenta += lista.importe;

        }
        this.controlPrdto.setValue('');
        this.f['cantidad'].setValue(0);
  
      } else {
        alert('Ingrese una cantidad valida');
      }
      
    }
  }

  cargarProductos() {
    this.http.get<Respuesta>(this.baseUrl+'api/producto').toPromise().then(e => {
      this.listadoPrdto = e.objeto;
      this.filtroPrdto = this.controlPrdto.valueChanges.pipe(
        startWith(''),
        map(value => this.filtrarPrd(value))
      );
    }).catch(e => {
    });
  }
  private filtrarPrd(value: string): Producto[] {
    const valorFiltro = value.toLowerCase();
    return this.listadoPrdto.filter(options => options.descripcion.toLowerCase().includes(valorFiltro));
  }

  // limpiarFiltroProductos(): void {
  //   this.f['productoDescripcion'].setValue('');
  //   this.f['productoId'].setValue(null);
  //   this.cargarProductos();
  // }

  productosSeleccionado(modelo: Producto,event:any) {
    if(event.isUserInput){
      this.f['productoDescripcion'].setValue(modelo.descripcion);
    this.f['productoId'].setValue(modelo.id);
    this.precioPrdto = modelo.precio;
    }
    
  }

  cerrar() {

  }

  removerProducto(prdto:SubVenta){
    var dato=this.listaSubVenta.filter(e=>e.productoDescripcion==prdto.productoDescripcion);
    dato[0].cantidad=dato[0].cantidad-1;

    if(dato[0].cantidad==0){
      var index=this.listaSubVenta.indexOf(dato[0])
      this.listaSubVenta.splice(index);
      this.totalVenta=this.totalVenta-dato[0].importe;
    }else{
      var producto=this.listadoPrdto.filter(e=>e.descripcion==prdto.productoDescripcion);
      prdto.importe-=producto[0].precio;
      this.totalVenta=this.totalVenta-producto[0].precio;
    }
    
  }

}
