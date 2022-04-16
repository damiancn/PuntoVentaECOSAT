export interface SubVenta {
    id: number;
    ventaId: number;
    productoId: number;
    productoDescripcion: string;
    cantidad: number;
    importe: number;
}