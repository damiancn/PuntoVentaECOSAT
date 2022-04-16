import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Subscription } from 'rxjs';
import { Usuario } from 'src/app/data/modelos/Catalogo/usuario';
import { Respuesta } from 'src/app/data/modelos/respuesta';
import { Producto } from 'src/app/data/modelos/Tienda/producto';
import { FormaPComponent } from '../forma/forma-p.component';

@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrls: ['./productos.component.css']
})
export class ProductosComponent implements OnInit {
  columnas: string[] = ['Descripcion', 'Precio','DepartamentoDescripcion','opciones'];
  dataSource = new MatTableDataSource<Producto>([]);
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string,private ventana:MatDialog) { }
  private subscription= new Subscription;

  ngOnInit(): void {
      this.crearTabla();
  }
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  crearTabla(){
    this.subscription.add(
      this.http.get<Respuesta>(this.baseUrl+'api/producto/').subscribe(e=>{
        if(e.estatus){
          this.dataSource= new MatTableDataSource<Producto>(e.objeto);
          console.log(e.objeto);
          this.dataSource.paginator=this.paginator;
          this.dataSource.sort=this.sort;

        }else{
          alert('Error al obtener los datos')
        }
      }),
    )
   // Assign the data to the data source for the table to render
  }
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  abrirFormulario(id?:number){
    const data=id??null;
    this.subscription.add(
      this.ventana.open(FormaPComponent,{data:data,disableClose:true,panelClass:"dialog"}).afterClosed().subscribe(e=>{
        if(e){
          this.crearTabla();
        }
      })
    );

  }

  // cambiarEstatus(id:number,checked:boolean){
  //   console.log(checked)
  //   this.subscription.add(
  //     this.ctx.usuario.cambiarEstatus(id,checked).subscribe(e=>{
  //       if(e.ok){
  //         this.alerta.mostrarExito(e.mensaje);
  //       } else{
  //         this.alerta.mostrarError(e.mensaje);
  //       }
  //     })
  //   )
  //}

}
