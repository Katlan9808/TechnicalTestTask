import { HttpClient, HttpParams } from "@angular/common/http";
import { EventEmitter, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { catchError, finalize, map, retry } from "rxjs/operators";
import { RequestResultModel } from "../models/RequestResultModel";
import { StateModel, TaskModel } from "../models/TaskModel";
import { ActionsEnum } from "../models/EnumActions";

@Injectable({
    providedIn: "root",
})
export class stateService {

    private data: StateModel[];

    constructor() {
        this.data = [];
    }

    setData(obj: StateModel): void {

        if (obj.action == ActionsEnum.INSERT) {
            obj.key = this.generateUuid();
            this.data = [...this.data, obj];
            return;
        }

        const element = this.data.find(f => f.key == obj.key);
        this.data = [...this.data, obj];

        localStorage.setItem('data', JSON.stringify(this.data));
    }

    getData({ key }: StateModel): StateModel {
        const element = this.data.find(f => f.key == key);

        if (element)
            return element;

        return new StateModel();
    }


    deleteData({ key }: StateModel): void {
        this.data = this.data.filter(f => f.key !== key);

        localStorage.setItem('data', JSON.stringify(this.data));
    }


    private generateUuid(): string {
        return "xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx".replace(
            /[xy]/g,
            function (c) {
                var r = (Math.random() * 16) | 0,
                    v = c == "x" ? r : (r & 0x3) | 0x8;
                return v.toString(16);
            }
        );
    }
}
