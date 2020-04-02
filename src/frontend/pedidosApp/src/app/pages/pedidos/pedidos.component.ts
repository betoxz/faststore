import { Component, OnInit } from '@angular/core';
import { PedidoDataService } from 'src/app/pedidodata.service';
import { Observable } from 'rxjs';
import { Pedido } from '../../../models/pedido';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
//import { Status } from '../../../models/status';

@Component({
  selector: 'app-pedidos',
  templateUrl: './pedidos.component.html',
  styleUrls: ['./pedidos.component.sass']
})
export class PedidosComponent implements OnInit {

  public pedidos$: Observable<Pedido[]>;
  //public listaStatus: Status[] = null;
  //private form: FormGroup;

  constructor(
    private service: PedidoDataService,
    //private fb: FormBuilder,
    //private router: Router,
  ) {
    //this.form = this.fb.group({
    //id: ['']
    //})
  }


  ngOnInit(): void {
    this.pedidos$ = this.service.getPedidos();
    //this.listaStatus = this.getStatus();
    //console.log(this.listaStatus);
  }

  /*
  getStatus() {
    return [
      new Status(1, 'Aguardando'),
      new Status(2, 'Enviado'),
      new Status(3, 'Entregue'),
      new Status(4, 'Cancelado'),
    ];
  }
  */

  pesquisar(id) {
    this.pedidos$ = this.service.getPedido(id);
  }
}
