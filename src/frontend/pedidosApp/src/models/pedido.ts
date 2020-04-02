export interface Pedido {
    Id?: number;
    idCliente: number;
    criadoEm: string;
    status: string;
    Cliente: string;
    quantidadeTotal: number;
    valorTotal: number;
    statusDescricao: string;
}