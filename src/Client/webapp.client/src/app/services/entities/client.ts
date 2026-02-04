interface IClient {
    id: string;
    name: string | null;
    email: string | null;
    phone: string | null;
    enable: boolean;
    createDate: Date;
}

export class Client implements IClient {
    id: string;
    name: string | null;
    email: string | null;
    phone: string | null;
    enable: boolean;
    createDate: Date;

    constructor(id: string, name: string | null = null, email: string | null = null, phone: string | null = null, enable: boolean = true, createDate: Date = new Date()) {
        this.id = id;
        this.name = name;
        this.email = email;
        this.phone = phone;
        this.enable = enable;
        this.createDate = createDate;
    }
}