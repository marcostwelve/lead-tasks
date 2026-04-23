import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TaskItem, TaskStatus } from 'src/app/models/taskStatus.model';
import { TaskItemService } from 'src/app/services/task-item.service';

@Component({
  selector: 'app-task-manager',
  templateUrl: './task-manager.component.html',
  styleUrls: ['./task-manager.component.css']
})
export class TaskManagerComponent implements OnInit{
  tasks: TaskItem[] = [];
  leadId!: number;
  newTaskTitle: string = '';

  constructor(private route: ActivatedRoute, private taskItemService: TaskItemService) {}

  ngOnInit(): void {
    this.leadId = +this.route.snapshot.paramMap.get('leadId')!;
    this.loadTasks();
  }

  loadTasks(): void {
    this.taskItemService.getTasks(this.leadId).subscribe(tasks => {
      this.tasks = tasks;
    });
  }

  addTask(): void {
    if (!this.newTaskTitle.trim()) {
       return;
    }

    this.taskItemService.createTask(this.leadId, { title: this.newTaskTitle, status: 'Todo'}).subscribe(() => {
      this.newTaskTitle = '';
      this.loadTasks();
    });
  }

  updateTaskStatus(task: TaskItem, newStatus: string): void {
    const taskToUpdate = {
      title: task.title,
      status: newStatus as TaskStatus
    }
     this.taskItemService.updateTask(this.leadId, task.id, taskToUpdate).subscribe({
      next: () => {
        task.status = newStatus as TaskStatus;

      },
      error: () => {
        alert('Ocorreu um erro ao atualizar o status da tarefa. Por favor, tente novamente.');
        this.loadTasks();
      }
     });
  }

  onStatusChange(task: TaskItem, event: any): void {
    const newStatus = event.target.value;
    this.updateTaskStatus(task, newStatus);
  }

  deleteTask(taskId: number): void {
    if (confirm('Tem certeza que deseja excluir esta tarefa?')) {
        this.taskItemService.deleteTask(this.leadId, taskId).subscribe(() => {
        this.loadTasks();
      });
    }
  }
}
