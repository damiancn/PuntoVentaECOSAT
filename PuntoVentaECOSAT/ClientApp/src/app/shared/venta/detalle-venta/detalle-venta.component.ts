import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Respuesta } from 'src/app/data/modelos/respuesta';
import { SubVenta } from 'src/app/data/modelos/Venta/subventa';

@Component({
  selector: 'app-detalle-venta',
  templateUrl: './detalle-venta.component.html',
  styleUrls: ['./detalle-venta.component.css']
})
export class DetalleVentaComponent implements OnInit {

  model!: SubVenta;
  list: SubVenta[] = [];
  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string, private ventana: MatDialogRef<DetalleVentaComponent>,
    @Inject(MAT_DIALOG_DATA) public id: number) {
    this.http.get<Respuesta>(this.baseUrl + 'api/venta/' + id).subscribe(e => {
      if (e.estatus) {
        console.log(e.objeto)
       this.list=e.objeto;
      } else {
        alert('Error al obtener los datos')
      }
    });


  }

  ngOnInit(): void {
  }

}
