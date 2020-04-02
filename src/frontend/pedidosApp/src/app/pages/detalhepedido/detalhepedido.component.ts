import { Component, OnInit } from '@angular/core';
import { PedidoDataService } from 'src/app/pedidodata.service';
import { Observable } from 'rxjs';
import { Pedido } from '../../../models/pedido';
import { Item } from '../../../models/itens';
import { Status } from '../../../models/status';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';


@Component({
  selector: 'app-detalhepedido',
  templateUrl: './detalhepedido.component.html',
  styleUrls: ['./detalhepedido.component.sass']
})
export class DetalhepedidoComponent implements OnInit {
  public pedido$: Observable<Pedido[]>;
  public itens$: Observable<Item[]>;
  public form: FormGroup;
  public listaStatus: Status[] = null;

  constructor(
    private activatedRoute: ActivatedRoute,
    private service: PedidoDataService,
    private router: Router,
    private fb: FormBuilder,
  ) {
    this.form = this.fb.group({
      status: Number
    });
  }

  setDefaultValues() {
    var p = this.pedido$.subscribe(res => {
      if (res) {
        this.form.patchValue({ status: res[0].status });
      }
    });
  }

  ngOnInit(): void {

    this.pedido$ = this.service.getPedido(this.activatedRoute.snapshot.params.id);
    this.itens$ = this.service.getPedidoItens(this.activatedRoute.snapshot.params.id);
    this.listaStatus = this.getStatus();
    this.setDefaultValues();
  }

  getStatus() {
    return [
      new Status(1, 'Aguardando'),
      new Status(2, 'Enviado'),
      new Status(3, 'Entregue'),
      new Status(4, 'Cancelado'),
    ];
  }

  salvar(): void {
    const data = {
      IdPedido: this.activatedRoute.snapshot.params.id,
      Status: this.form.value.status
    };

    this.service.update(data)
      .subscribe(res => {
        this.router.navigateByUrl("pedidos");
      });
  }

}
