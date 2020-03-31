import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/data.service';
import { Observable } from 'rxjs';
import { Cliente } from '../../../models/cliente';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.sass']
})

export class ClientesComponent implements OnInit {

  public clientes$: Observable<Cliente[]>;
  //private form: FormGroup;

  constructor(
    private service: DataService,
    //private fb: FormBuilder,
    //private router: Router,
  ) {

    //this.form = this.fb.group({
    //cpf: ['']
    //})
  }

  ngOnInit(): void {
    this.clientes$ = this.service.getClientes();
  }

  pesquisar(valor) {

    //var param = this.form.value;
    console.log(valor);
    this.clientes$ = this.service.getCliente(valor);
  }
}