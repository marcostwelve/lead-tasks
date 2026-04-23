export type LeadStatus = 'New' | 'Qualified' | 'Won' | 'Lost';

export interface Lead {
  id: number;
  name: string;
  email: string;
  status: LeadStatus;
  createdAt: string;
  updatedAt: string;
  tasksCount?: number;
}