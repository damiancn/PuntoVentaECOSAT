import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Subscription } from 'rxjs';
import { Respuesta } from 'src/app/data/modelos/respuesta';
import { Venta } from 'src/app/data/modelos/Venta/venta';
import { DetalleVentaComponent } from '../detalle-venta/detalle-venta.component';

@Component({
  selector: 'app-ver-venta',
  templateUrl: './ver-venta.component.html',
  styleUrls: ['./ver-venta.component.css']
})
export class VerVentaComponent implements OnInit {

  columnas: string[] = ['ImporteTotal', 'CantidadProductos','Fecha','UsuarioVenta','detalles'];
  dataSource = new MatTableDataSource<Venta>([]);
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string,private ventana:MatDialog) { }
  private subscription= new Subscription;

  ngOnInit(): void {
    this.crearTabla();
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
  
  crearTabla(){
 
      this.http.get<Respuesta>(this.baseUrl+'api/venta/').subscribe(e=>{
        if(e.estatus){
          this.dataSource= new MatTableDataSource<Venta>(e.objeto);
          console.log(e.objeto);
          this.dataSource.paginator=this.paginator;
          this.dataSource.sort=this.sort;

        }else{
          alert('Error al obtener los datos')
        }
      })
   // Assign the data to the data source for the table to render
  }

  abrirForma(id:number):void{
    this.ventana.open(DetalleVentaComponent,{data:id,panelClass:"tituloModal"});
  }
}
