import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-patients',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="page">
      <div class="page-header">
        <h1>Patients</h1>
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
          Nouveau patient
        </button>
      </div>

      <div class="filters">
        <input type="text" placeholder="Rechercher un patient..." class="search-input" />
        <select class="filter-select">
          <option>Tous les patients</option>
          <option>Actifs</option>
          <option>Archivés</option>
        </select>
      </div>

      <div class="table-container">
        <table>
          <thead>
            <tr>
              <th>Nom</th>
              <th>Prénom</th>
              <th>Date de naissance</th>
              <th>Téléphone</th>
              <th>Dernière visite</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            <tr *ngFor="let patient of patients">
              <td>{{ patient.nom }}</td>
              <td>{{ patient.prenom }}</td>
              <td>{{ patient.dateNaissance }}</td>
              <td>{{ patient.telephone }}</td>
              <td>{{ patient.derniereVisite }}</td>
              <td>
                <div class="actions">
                  <button class="btn-icon" title="Voir">
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
                        d="M2.036 12.322a1.012 1.012 0 010-.639C3.423 7.51 7.36 4.5 12 4.5c4.64 0 8.573 3.007 9.963 7.178.07.207.07.431 0 .639C20.577 16.49 16.64 19.5 12 19.5c-4.64 0-8.573-3.007-9.963-7.178z"
                      />
                      <path
                        stroke-linecap="round"
                        stroke-linejoin="round"
                        d="M15 12a3 3 0 11-6 0 3 3 0 016 0z"
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
      }
      .search-input {
        flex: 1;
        padding: 8px 12px;
        border: 1px solid #e2e8f0;
        border-radius: 6px;
        font-size: 12px;
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
        overflow: hidden;
        box-shadow: 0 1px 2px rgba(0, 0, 0, 0.05);
      }
      table {
        width: 100%;
        border-collapse: collapse;
      }
      th {
        padding: 10px 12px;
        text-align: left;
        font-size: 11px;
        font-weight: 600;
        color: #64748b;
        background: #f8fafc;
        border-bottom: 1px solid #e2e8f0;
      }
      td {
        padding: 10px 12px;
        font-size: 12px;
        color: #374151;
        border-bottom: 1px solid #f1f5f9;
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
      .btn-icon:hover {
        background: #e2e8f0;
      }
    `,
  ],
})
export class PatientsComponent {
  patients = [
    {
      nom: 'Benali',
      prenom: 'Ahmed',
      dateNaissance: '15/03/1985',
      telephone: '0555 12 34 56',
      derniereVisite: '01/12/2024',
    },
    {
      nom: 'Khaled',
      prenom: 'Mohamed',
      dateNaissance: '22/07/1990',
      telephone: '0661 78 90 12',
      derniereVisite: '28/11/2024',
    },
    {
      nom: 'Lahlou',
      prenom: 'Sara',
      dateNaissance: '10/11/1978',
      telephone: '0770 34 56 78',
      derniereVisite: '25/11/2024',
    },
    {
      nom: 'Bouzid',
      prenom: 'Fatima',
      dateNaissance: '05/01/1995',
      telephone: '0550 90 12 34',
      derniereVisite: '20/11/2024',
    },
    {
      nom: 'Hadj',
      prenom: 'Youcef',
      dateNaissance: '18/09/1982',
      telephone: '0662 45 67 89',
      derniereVisite: '15/11/2024',
    },
  ];
}
