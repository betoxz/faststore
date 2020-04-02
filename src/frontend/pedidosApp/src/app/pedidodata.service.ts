import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Pedido } from '../models/pedido';
import { Status } from '../models/status';
import { Item } from '../models/itens';

@Injectable({
  providedIn: 'root'
})
export class PedidoDataService {
  public baseUrl = "https://localhost:5001/api"

  public httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(
    private http: HttpClient
  ) { }

  getPedidos(): Observable<Pedido[]> {
    return this.http.get<Pedido[]>(`${this.baseUrl}/Pedido/v1/pedidos`)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  getPedido(id): Observable<Pedido[]> {
    return this.http.get<Pedido[]>(`${this.baseUrl}/Pedido/v1/pedidos/${id}`)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  getPedidoItens(id): Observable<Item[]> {
    return this.http.get<Item[]>(`${this.baseUrl}/v1/pedidos/${id}/itens`)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  public getStatus() {
    return this.http.get(`${this.baseUrl}/Pedido/v1/status`);
  }


  update(data): Observable<Pedido> {
    return this.http.put<Pedido>(`${this.baseUrl}/Pedido/v1/pedido`, JSON.stringify(data), this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      )
  }

  errorHandler(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}