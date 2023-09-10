import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MessageService } from 'primeng/api';
import { ActionsEnum } from 'src/app/models/EnumActions';
import { RequestResultModel } from 'src/app/models/RequestResultModel';
import { ResponseModelTask } from 'src/app/models/ResponseModel';
import { StateModel, Status } from 'src/app/models/TaskModel';
import { TaskModel } from 'src/app/models/TaskModel';
import { stateService } from 'src/app/services/stateService';
import { taskService } from 'src/app/services/taskService';

@Component({
  selector: 'ta-app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css'],
})
export class TaskComponent {

  @Output() closeDialog = new EventEmitter<ResponseModelTask>();
  @Input() taskModel = new TaskModel();
  @Input() openDialog: boolean = false;
  @Input() isEdit: boolean = false;
  @Input() isAdd: boolean = false;
  statuses: Status[] = [];
  statuses2: any[] = [];
  validForm = true;

  constructor(private taskService: taskService, 
              private messageService: MessageService,
              private stateService: stateService) {
    this.statuses = [{
      value: 'P',
      label: "Pendiente",
      color: 'danger'
    },
    {
      value: 'E',
      label: "En progreso",
      color: 'warning'
    },
    {
      value: 'C',
      label: "Completado",
      color: 'success'
    }];
  }

  validateForm = () => {
    this.validForm = (this.taskModel.developer || '').length > 0 &&
      (this.taskModel.title || '').length > 0 &&
      (this.taskModel.developer || '').length > 0 ? true : false;
  }
  saveTask = (event: any) => {
    if (event == null) return;

    this.validateForm();

    if (!this.validForm) return;

    if (this.isEdit)
      this.postEditTask(this.taskModel);
    else
      this.postSaveTask(this.taskModel);

  }

  hideDialog = () => {
    let model = new ResponseModelTask();
    model.openDialog = false;

    this.closeDialog.emit(model);
  }

  postSaveTask = (task: TaskModel) => {
    this.taskService.saveTask(task).subscribe((response: RequestResultModel<TaskModel>) => {
      if (!response) return;

      const state = new StateModel ();
      state.action = ActionsEnum.INSERT;
      state.value = task;

      this.stateService.setData(state);

      this.messageService.add({
        severity: response.isSuccessful ? 'success' : 'error',
        summary: response.isSuccessful ? 'Completado' : 'error',
        detail: response.isSuccessful ? `Se ha agregado la tarea ${this.taskModel.title}` : response.errorMessage
      });
      this.hideDialog();
    });
  }

  postEditTask = (task: TaskModel) => {
    this.taskService.editTask(task).subscribe((response: RequestResultModel<TaskModel>) => {
      if (!response) return;

      const state = new StateModel ();
      state.key = task.id.toString();
      state.action = ActionsEnum.UPDATE;
      state.value = task;

      this.stateService.setData(state);

      this.messageService.add({
        severity: response.isSuccessful ? 'success' : 'error',
        summary: response.isSuccessful ? 'Completado' : 'error',
        detail: response.isSuccessful ? `Se ha actualizado la tarea ${this.taskModel.title}` : response.errorMessage
      });
      this.hideDialog();
    });
  }

}
