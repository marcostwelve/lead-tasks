import { Component, OnInit } from '@angular/core';
import { Lead } from 'src/app/models/lead.model';
import { LeadService } from 'src/app/services/lead.service';

@Component({
  selector: 'app-lead-list',
  templateUrl: './lead-list.component.html',
  styleUrls: ['./lead-list.component.css']
})
export class LeadListComponent implements OnInit {

  leads: Lead[] = [];
  search: string = '';
  selectedStatus: string = '';

  constructor(private leadService: LeadService) { }

  ngOnInit(): void {
    this.loadLeads();
  }

  loadLeads(): void {
    this.leadService.getLeads(this.search, this.selectedStatus).subscribe({
      next: (data) => {
        this.leads = data;
      },
      error: (err) => {
        console.error('Error fetching leads:', err);
        alert('Erro ao carregar a lista. Verifique se o backend está rodando!');
      }
    });
  }

  onSearch(): void {
    this.loadLeads();
  }

  deleteLead(id: number): void {
    if (confirm('Tem certeza que deseja excluir este lead?')) {
      this.leadService.deleteLead(id).subscribe({
        next: () => {
          alert('Lead excluído com sucesso!');
          this.loadLeads();
        },
        error: (err) => {
          console.error('Error deleting lead:', err);
          alert('Erro ao excluir o lead. Tente novamente.');
        }
      });
    }
  }
}
