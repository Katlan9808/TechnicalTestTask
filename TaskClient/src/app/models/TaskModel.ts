

export class TaskModel {
    id: number;
    description: string;
    developer: string;
    title: string;
    state: string;
    dateLimit?: Date;

    constructor() {
        this.id = 0;
        this.description = '';
        this.title = '';
        this.developer = '';
        this.state = 'Pendiente';
    }
}

export class Status {
    label: string;
    value: string;
    color: string;

    constructor() {
        this.label = 'P';
        this.value = 'Pendiente';
        this.color = 'danger';
    }
}

export class StateModel {
    key: string;
    action: string;
    value: TaskModel;

    constructor(){
        this.key = '';
        this.action = '';
        this.value = new TaskModel();

    }
}