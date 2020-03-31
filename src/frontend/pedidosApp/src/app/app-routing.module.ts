import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { ClientesComponent } from './pages/clientes/clientes.component';
import { PedidosComponent } from './pages/pedidos/pedidos.component';
import { DetalhepedidoComponent } from './pages/detalhepedido/detalhepedido.component';

const routes: Routes = [
  {
    path: "", component: HomeComponent, children:
      [{ path: "clientes", component: ClientesComponent, },
      { path: "pedidos", component: PedidosComponent, },
      { path: "detalhepedido", component: DetalhepedidoComponent, }]
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
