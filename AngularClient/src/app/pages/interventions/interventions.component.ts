import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-interventions',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="page">
      <div class="page-header">
        <h1>Interventions</h1>
        <button class="btn-primary">
          <svg
            xmlns="http://www.w3.org/2000/svg"
            fill="none"
            viewBox="0 0 24 24"
            stroke-width="1.5"
            stroke="currentColor"
          >
            <path stroke-linecap="round" stroke-linejoin="round" d="M12 4.5v15m7.5-7.5h-15" />
          </svg>
          Nouvelle intervention
        </button>
      </div>

      <div class="filters">
        <input type="text" placeholder="Rechercher..." class="search-input" />
        <input type="date" class="date-input" />
        <select class="filter-select">
          <option>Tous les statuts</option>
          <option>Planifié</option>
          <option>En cours</option>
          <option>Terminé</option>
          <option>Annulé</option>
        </select>
      </div>

      <div class="table-container">
        <table>
          <thead>
            <tr>
              <th>Patient</th>
              <th>Type d'intervention</th>
              <th>Date</th>
              <th>Heure</th>
              <th>Chirurgien</th>
              <th>Statut</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            <tr *ngFor="let intervention of interventions">
              <td>{{ intervention.patient }}</td>
              <td>{{ intervention.type }}</td>
              <td>{{ intervention.date }}</td>
              <td>{{ intervention.heure }}</td>
              <td>{{ intervention.chirurgien }}</td>
              <td>
                <span class="status" [class]="intervention.statut.toLowerCase()">{{
                  intervention.statut
                }}</span>
              </td>
              <td>
                <div class="actions">
                  <button class="btn-icon" title="Dossier">
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      fill="none"
                      viewBox="0 0 24 24"
                      stroke-width="1.5"
                      stroke="currentColor"
                    >
                      <path
                        stroke-linecap="round"
                        stroke-linejoin="round"
                        d="M19.5 14.25v-2.625a3.375 3.375 0 00-3.375-3.375h-1.5A1.125 1.125 0 0113.5 7.125v-1.5a3.375 3.375 0 00-3.375-3.375H8.25m0 12.75h7.5m-7.5 3H12M10.5 2.25H5.625c-.621 0-1.125.504-1.125 1.125v17.25c0 .621.504 1.125 1.125 1.125h12.75c.621 0 1.125-.504 1.125-1.125V11.25a9 9 0 00-9-9z"
                      />
                    </svg>
                  </button>
                  <button class="btn-icon" title="Modifier">
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      fill="none"
                      viewBox="0 0 24 24"
                      stroke-width="1.5"
                      stroke="currentColor"
                    >
                      <path
                        stroke-linecap="round"
                        stroke-linejoin="round"
                        d="M16.862 4.487l1.687-1.688a1.875 1.875 0 112.652 2.652L10.582 16.07a4.5 4.5 0 01-1.897 1.13L6 18l.8-2.685a4.5 4.5 0 011.13-1.897l8.932-8.931zm0 0L19.5 7.125M18 14v4.75A2.25 2.25 0 0115.75 21H5.25A2.25 2.25 0 013 18.75V8.25A2.25 2.25 0 015.25 6H10"
                      />
                    </svg>
                  </button>
                </div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  `,
  styles: [
    `
      .page {
        padding: 12px;
      }
      .page-header {
        display: flex;
        justify-content: space-between;
        align-items: center;
        margin-bottom: 12px;
      }
      .page-header h1 {
        font-size: 18px;
        font-weight: 600;
        color: #0f172a;
      }
      .btn-primary {
        display: flex;
        align-items: center;
        gap: 6px;
        padding: 8px 12px;
        background: #0d9488;
        color: white;
        border: none;
        border-radius: 6px;
        font-size: 12px;
        font-weight: 500;
        cursor: pointer;
      }
      .btn-primary svg {
        width: 14px;
        height: 14px;
      }
      .filters {
        display: flex;
        gap: 8px;
        margin-bottom: 12px;
        flex-wrap: wrap;
      }
      .search-input,
      .date-input {
        padding: 8px 12px;
        border: 1px solid #e2e8f0;
        border-radius: 6px;
        font-size: 12px;
      }
      .search-input {
        flex: 1;
        min-width: 150px;
      }
      .filter-select {
        padding: 8px 12px;
        border: 1px solid #e2e8f0;
        border-radius: 6px;
        font-size: 12px;
      }
      .table-container {
        background: white;
        border-radius: 8px;
        overflow-x: auto;
        box-shadow: 0 1px 2px rgba(0, 0, 0, 0.05);
      }
      table {
        width: 100%;
        border-collapse: collapse;
        min-width: 700px;
      }
      th {
        padding: 10px 12px;
        text-align: left;
        font-size: 11px;
        font-weight: 600;
        color: #64748b;
        background: #f8fafc;
        border-bottom: 1px solid #e2e8f0;
        white-space: nowrap;
      }
      td {
        padding: 10px 12px;
        font-size: 12px;
        color: #374151;
        border-bottom: 1px solid #f1f5f9;
      }
      .status {
        padding: 3px 8px;
        border-radius: 4px;
        font-size: 10px;
        font-weight: 500;
      }
      .status.planifié {
        background: #fef3c7;
        color: #b45309;
      }
      .status.en.cours,
      .status.en {
        background: #dbeafe;
        color: #1e40af;
      }
      .status.terminé {
        background: #dcfce7;
        color: #166534;
      }
      .status.annulé {
        background: #fee2e2;
        color: #dc2626;
      }
      .actions {
        display: flex;
        gap: 4px;
      }
      .btn-icon {
        padding: 4px;
        border: none;
        background: #f1f5f9;
        border-radius: 4px;
        cursor: pointer;
      }
      .btn-icon svg {
        width: 14px;
        height: 14px;
        color: #64748b;
      }
    `,
  ],
})
export class InterventionsComponent {
  interventions = [
    {
      patient: 'Ahmed Benali',
      type: 'Appendicectomie',
      date: '05/12/2024',
      heure: '08:30',
      chirurgien: 'Dr. Mansouri',
      statut: 'Planifié',
    },
    {
      patient: 'Mohamed Khaled',
      type: 'Cholécystectomie',
      date: '05/12/2024',
      heure: '10:00',
      chirurgien: 'Dr. Boudiaf',
      statut: 'En cours',
    },
    {
      patient: 'Sara Lahlou',
      type: 'Hernioplastie',
      date: '05/12/2024',
      heure: '14:00',
      chirurgien: 'Dr. Mansouri',
      statut: 'Planifié',
    },
    {
      patient: 'Fatima Bouzid',
      type: 'Thyroïdectomie',
      date: '04/12/2024',
      heure: '09:00',
      chirurgien: 'Dr. Hadj',
      statut: 'Terminé',
    },
    {
      patient: 'Youcef Hadj',
      type: 'Prostatectomie',
      date: '03/12/2024',
      heure: '11:00',
      chirurgien: 'Dr. Boudiaf',
      statut: 'Terminé',
    },
  ];
}
