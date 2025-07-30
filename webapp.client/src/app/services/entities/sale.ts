import { Client } from "./client";
import { SaleItem } from "./saleItem";

interface ISale {
    id: string;
    clientId: string;
    saleDate: Date;
    enable: boolean;
    createDate: Date;
    items: SaleItem[];
    Client: Client | null;
}

export class Sale implements ISale {
    id: string;
    clientId: string;
    saleDate: Date;
    enable: boolean;
    createDate: Date;
    items: SaleItem[];
    Client: Client | null;
    
    constructor(id: string, clientId: string, saleDate: Date = new Date(), enable: boolean = true, createDate: Date = new Date(), items: SaleItem[] = [], client: Client | null = null) {
        this.id = id;
        this.clientId = clientId;
        this.saleDate = saleDate;
        this.enable = enable;
        this.createDate = createDate;
        this.items = items;
        this.Client = client;
    }
}