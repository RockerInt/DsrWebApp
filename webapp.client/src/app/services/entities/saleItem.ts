import { Product } from "./product";

interface ISaleItem {
    id: string;
    productId: string;
    quantity: number;
    unitPrice: number;
    enable: boolean;
    createDate: Date;
    Product: Product | null;
}

export class SaleItem implements ISaleItem {
    id: string;
    productId: string;
    quantity: number;
    unitPrice: number;
    enable: boolean;
    createDate: Date;
    Product: Product | null;

    constructor(id: string, productId: string, quantity: number = 1, unitPrice: number = 0, enable: boolean = true, createDate: Date = new Date(), product: Product | null = null) {
        this.id = id;
        this.productId = productId;
        this.quantity = quantity;
        this.unitPrice = unitPrice;
        this.enable = enable;
        this.createDate = createDate;
        this.Product = product;
    }
}