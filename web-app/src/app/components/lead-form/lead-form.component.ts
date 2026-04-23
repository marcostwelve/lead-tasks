import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { LeadService } from 'src/app/services/lead.service';

@Component({
  selector: 'app-lead-form',
  templateUrl: './lead-form.component.html',
  styleUrls: ['./lead-form.component.css']
})
export class LeadFormComponent implements OnInit{
  leadForm!: FormGroup;
  leadId?: number;
  isEditMode = false;

  constructor(private fb: FormBuilder, private leadService: LeadService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.leadForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(3)]],
      email: ['', [Validators.required, Validators.email] ],
      status: ['New', Validators.required]
    });

    this.route.paramMap.subscribe(params => {
      const idParam = params.get('id');
      if (idParam) {
        this.leadId = +idParam;
        this.isEditMode = true;
        this.loadLeadData(this.leadId);
      }
    });
  }

  loadLeadData(id: number): void {
    this.leadService.getLeadById(id).subscribe({
      next: (lead) => {
        this.leadForm.patchValue({
          name: lead.name,
          email: lead.email,
          status: lead.status
        });
      },
      error: (err) => {
        console.error('Error loading lead:', err);
        alert('Erro ao carregar lead. Verifique se o backend está rodando!');
        this.router.navigate(['/leads']);
      }
    });
  }

  onSubmit(): void {
    if (this.leadForm.invalid) {
      this.leadForm.markAllAsTouched();
      return;
    }

    const formData = this.leadForm.value;

    if (this.isEditMode && this.leadId) {
      this.leadService.updateLead(this.leadId, formData).subscribe({
        next: () => {
          alert('Lead atualizado com sucesso!');
          this.router.navigate(['/leads']);
        },
        error: (err) => {
          console.error('Error updating lead:', err);
          alert('Erro ao atualizar lead. Verifique se o backend está rodando!');
        }
      });

    } else {

      this.leadService.createLead(formData).subscribe({
        next: () => {
          alert('Lead criado com sucesso!');
          this.router.navigate(['/leads']);
        },
        error: (err) => {
          console.error('Error creating lead:', err);
          alert('Erro ao criar lead. Verifique se o backend está rodando!');
        }
      });
    }
  }
}
