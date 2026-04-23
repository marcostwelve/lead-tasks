import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { TaskItem } from '../models/taskStatus.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TaskItemService {

  private apiUrl = (leadId: number) => `${environment.apiUrl}/leads/${leadId}/tasks`;
  constructor(private http: HttpClient) { }

  getTasks(leadId: number):Observable<TaskItem[]> {
    return this.http.get<TaskItem[]>(this.apiUrl(leadId));
  }

  createTask(leadId: number, task: Partial<TaskItem>):Observable<TaskItem> {
    return this.http.post<TaskItem>(this.apiUrl(leadId), task);
  }

  updateTask(leadId: number, taskId: number, task: Partial<TaskItem>):Observable<TaskItem> {
    return this.http.put<TaskItem>(`${this.apiUrl(leadId)}/${taskId}`, task);
  }

  deleteTask(leadId: number, taskId: number):Observable<void> {
    return this.http.delete<void>(`${this.apiUrl(leadId)}/${taskId}`);
  }
}
