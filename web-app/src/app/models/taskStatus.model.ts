export type TaskStatus = 'Todo' | 'Doing' | 'Done';

export interface TaskItem {
  id: number;
  leadId: number;
  title: string;
  dueDate?: string;
  status: TaskStatus;
  createdAt: string;
  updatedAt: string;
}