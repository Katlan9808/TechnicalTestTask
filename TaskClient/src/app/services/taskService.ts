import { HttpClient, HttpParams } from "@angular/common/http";
import { EventEmitter, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { catchError, finalize, map, retry } from "rxjs/operators";
import { RequestResultModel } from "../models/RequestResultModel";
import { TaskModel } from "../models/TaskModel";

@Injectable({
    providedIn: "root",
})
export class taskService {
    constructor(private http: HttpClient) { }

    URL_Str = 'https://localhost:7109/api/';

    getTaskList() {
        return this.http.get<RequestResultModel<TaskModel[]>>(this.URL_Str + "Task/Get");
    }

    saveTask(objDto: TaskModel) {
        return this.http.post<RequestResultModel<TaskModel>>(this.URL_Str + "Task/Create", objDto);
    }

    editTask(objDto: TaskModel) {
        objDto.state = objDto.state == "C" ? "Completado" : objDto.state == "E"? "En progreso" : objDto.state == "P" ? 'Pendiente' : 'Pendiente';
        return this.http.post<RequestResultModel<TaskModel>>(this.URL_Str + "Task/Edit", objDto);
    }

    deleteTask(objDto: TaskModel) {
        return this.http.post<RequestResultModel<TaskModel>>(this.URL_Str + "Task/Delete", objDto);
    }
}
