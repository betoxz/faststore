import { Component, OnInit, Input } from '@angular/core';
import { PedidoDataService } from 'src/app/pedidodata.service';
import { Observable } from 'rxjs';
import { Pedido } from '../../../models/pedido';
import { Status } from '../../../models/status';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-pedido',
  templateUrl: './pedido.component.html',
  styleUrls: ['./pedido.component.sass']
})
export class PedidoComponent implements OnInit {

  public form: FormGroup;
  public pedido$: Observable<Pedido[]>;
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

  ngOnInit(): void {
    this.pedido$ = this.service.getPedido(this.activatedRoute.snapshot.params.id);
    this.service.getStatus().subscribe(res => {
      if (res) {
        this.listaStatus = res.map(obj => {
          return new Status(obj.id, obj.descricao);
        });
      }
    });

    this.setDefaultValues();
  }

  setDefaultValues() {
    var p = this.pedido$.subscribe(res => {
      if (res) {
        this.form.patchValue({ status: res[0].status });
      }
    });
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