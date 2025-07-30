import { Product } from "./product";

interface IInventory {
    id: string;
    productId: string;
    stockQuantity: number;
    enable: boolean;
    createDate: Date;
    Product: Product | null;
}

export class Inventory implements IInventory {
    id: string;
    productId: string;
    stockQuantity: number;
    enable: boolean;
    createDate: Date;
    Product: Product | null;

    constructor(id: string, productId: string, stockQuantity: number = 0, enable: boolean = true, createDate: Date = new Date(), product: Product | null = null) {
        this.id = id;
        this.productId = productId;
        this.stockQuantity = stockQuantity;
        this.enable = enable;
        this.createDate = createDate;
        this.Product = product;
    }
}