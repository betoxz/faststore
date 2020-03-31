import { Component, OnInit } from '@angular/core';
import { PedidoDataService } from 'src/app/pedidodata.service';
import { Observable } from 'rxjs';
import { Pedido } from '../../../models/pedido';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pedidos',
  templateUrl: './pedidos.component.html',
  styleUrls: ['./pedidos.component.sass']
})
export class PedidosComponent implements OnInit {

  public pedidos$: Observable<Pedido[]>;
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
  }

  pesquisar(id) {
    this.pedidos$ = this.service.getPedido(id);
  }

  alterarStatus(id, status) {

  }

}
