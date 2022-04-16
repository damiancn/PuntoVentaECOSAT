import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { Respuesta } from 'src/app/data/modelos/respuesta';
import { Departamento } from 'src/app/data/modelos/Tienda/departamento';
import { Producto } from 'src/app/data/modelos/Tienda/producto';
import { map, startWith } from 'rxjs/operators';
import { coerceBooleanProperty } from '@angular/cdk/coercion';

@Component({
  selector: 'app-forma-p',
  templateUrl: './forma-p.component.html',
  styleUrls: ['./forma-p.component.css']
})
export class FormaPComponent implements OnInit {

  forma!: FormGroup;
  model!: Producto;
  departamento!: Departamento;
  get f(){return this.forma.controls;}
  controlDpto = new FormControl();
  listadoDpto: Departamento[] = [];
  filtroDpto!: Observable<Departamento[]>;
  idSeleccion!:number;
  descripcionDptoSeleccion!:string;

  depa = '';
  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string, private ventana: MatDialogRef<FormaPComponent>, private formbuilder: FormBuilder,
  @Inject(MAT_DIALOG_DATA) public id: number) {

    if(id!=null){
      this.http.get<Respuesta>(this.baseUrl + 'api/producto/'+id).subscribe(e => {
        if (e.estatus) {
          this.model = e.objeto;
          this.idSeleccion=id;
          const dpto:Departamento={
            descripcion:this.model.departamentoDescripcion,
            id:this.model.departamentoId
          };
          console.log(dpto);
          this.dptoSeleccionada(dpto);
          Object.assign(this.forma.value, this.model);
          this.forma.reset(this.forma.value);
        } else {
          alert('Error al obtener los datos')
        }
      });
    }
  }

  ngOnInit(): void {
    this.forma = this.formbuilder.group({
      id: [0],
      descripcion: ['', [Validators.required]],
      precio: [0, [Validators.required]],
      departamentoId: [0, [Validators.required]],
      departamentoDescripcion: ['', [Validators.required]],
    });
    this.obtenerDepartamentos();
  }
  public dptoSeleccionada(dpto: Departamento) {
    this.departamento = dpto;
    this.f['departamentoDescripcion'].setValue(dpto.descripcion);
    this.f['departamentoId'].setValue(dpto.id);
    console.log(this.forma.value);
  }

  iniciarValores(modelo: Departamento){
    this.depa = modelo.descripcion;
    

  }
  obtenerDepartamentos() {
    this.http.get<Respuesta>(this.baseUrl + 'api/producto/departamento').subscribe(e => {
      if (e.estatus) {
        this.listadoDpto = e.objeto;
        this.filtroDpto = this.controlDpto.valueChanges.pipe(
          startWith(''),
          map(value => this.filtrarDpto(value))
        );
        this.departamento = e.objeto;
      } else {
        alert('Error al obtener los datos')
      }
    });
  }
  private filtrarDpto(value: string): Departamento[] {
    const valorFiltro = value.toLowerCase();
    return this.listadoDpto.filter(options => options.descripcion.toLowerCase().includes(valorFiltro));
  }

  guardar() {

    const model=this.forma.value as Producto;
    if(this.forma.valid){
      if(this.idSeleccion==null){
        this.http.post<Respuesta>(this.baseUrl + 'api/producto',model).subscribe(e => {
          if (e.estatus) {
            alert(e.mensaje)
            this.ventana.close(true);
          } else {
            alert(e.mensaje)
          }
        });
      }else{
        this.http.put<Respuesta>(this.baseUrl + 'api/producto/'+this.idSeleccion,model).subscribe(e => {
          if (e.estatus) {
            alert(e.mensaje);
            this.ventana.close(true);
          } else {
            alert(e.mensaje)
          }
        });
      }
    }
    
  }

}
