interface IProduct {
    id: string;
    name: string | null;
    description: string | null;
    price: number;
    enable: boolean;
    createDate: Date;
}

export class Product implements IProduct {
    id: string;
    name: string | null;
    description: string | null;
    price: number;
    enable: boolean;
    createDate: Date;

    constructor(id: string, name: string | null = null, description: string | null = null, price: number = 0, enable: boolean = true, createDate: Date = new Date()) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.price = price;
        this.enable = enable;
        this.createDate = createDate;
    }
}