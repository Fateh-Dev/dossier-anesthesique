import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-medecins',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="page">
      <div class="page-header">
        <h1>Médecins</h1>
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
          Nouveau médecin
        </button>
      </div>

      <div class="filters">
        <input type="text" placeholder="Rechercher un médecin..." class="search-input" />
        <select class="filter-select">
          <option>Tous les médecins</option>
          <option>Anesthésistes</option>
          <option>Chirurgiens</option>
        </select>
      </div>

      <div class="table-container">
        <table>
          <thead>
            <tr>
              <th>Nom</th>
              <th>Prénom</th>
              <th>Spécialité</th>
              <th>Téléphone</th>
              <th>Email</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            <tr *ngFor="let medecin of medecins">
              <td>{{ medecin.nom }}</td>
              <td>{{ medecin.prenom }}</td>
              <td>{{ medecin.specialite }}</td>
              <td>{{ medecin.telephone }}</td>
              <td>{{ medecin.email }}</td>
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
        color: var(--text-color);
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
        border: 1px solid var(--input-border);
        border-radius: 6px;
        font-size: 12px;
        background: var(--input-bg);
        color: var(--text-color);
      }
      .filter-select {
        padding: 8px 12px;
        border: 1px solid var(--input-border);
        border-radius: 6px;
        font-size: 12px;
        background: var(--input-bg);
        color: var(--text-color);
      }
      .table-container {
        background: var(--card-bg);
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
        color: var(--text-muted);
        background: var(--header-bg);
        border-bottom: 1px solid var(--border-color);
      }
      td {
        padding: 10px 12px;
        font-size: 12px;
        color: var(--text-color);
        border-bottom: 1px solid var(--table-border);
      }
      .actions {
        display: flex;
        gap: 4px;
      }
      .btn-icon {
        padding: 4px;
        border: none;
        background: transparent;
        border-radius: 4px;
        cursor: pointer;
      }
      .btn-icon:hover {
        background: var(--hover-bg);
      }
      .btn-icon svg {
        width: 14px;
        height: 14px;
        color: var(--text-muted);
      }
    `,
  ],
})
export class MedecinsComponent {
  medecins = [
    {
      nom: 'Dupont',
      prenom: 'Jean',
      specialite: 'Anesthésiste',
      telephone: '0555 11 22 33',
      email: 'jean.dupont@hopital.com',
    },
    {
      nom: 'Slimani',
      prenom: 'Amine',
      specialite: 'Chirurgien',
      telephone: '0661 44 55 66',
      email: 'amine.slimani@hopital.com',
    },
    {
      nom: 'Martin',
      prenom: 'Sophie',
      specialite: 'Anesthésiste',
      telephone: '0770 88 99 00',
      email: 'sophie.martin@hopital.com',
    },
  ];
}
