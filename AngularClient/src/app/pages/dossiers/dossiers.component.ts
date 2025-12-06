import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-dossiers',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="page">
      <div class="page-header">
        <h1>Dossiers Anesthésiques</h1>
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
          Nouveau dossier
        </button>
      </div>

      <div class="filters">
        <input type="text" placeholder="Rechercher un dossier..." class="search-input" />
        <select class="filter-select">
          <option>Tous les dossiers</option>
          <option>Complets</option>
          <option>En cours</option>
          <option>À valider</option>
        </select>
      </div>

      <div class="dossiers-grid">
        <div class="dossier-card" *ngFor="let dossier of dossiers">
          <div class="dossier-header">
            <div class="patient-avatar">{{ dossier.initiales }}</div>
            <div class="patient-info">
              <span class="patient-name">{{ dossier.patient }}</span>
              <span class="dossier-id">N° {{ dossier.numero }}</span>
            </div>
            <span class="dossier-status" [class]="dossier.statut.toLowerCase()">{{
              dossier.statut
            }}</span>
          </div>
          <div class="dossier-details">
            <div class="detail-row">
              <span class="label">Intervention:</span>
              <span class="value">{{ dossier.intervention }}</span>
            </div>
            <div class="detail-row">
              <span class="label">Date:</span>
              <span class="value">{{ dossier.date }}</span>
            </div>
            <div class="detail-row">
              <span class="label">ASA:</span>
              <span class="value asa">{{ dossier.asa }}</span>
            </div>
          </div>
          <div class="dossier-actions">
            <button class="btn-action">Consulter</button>
            <button class="btn-action secondary">Modifier</button>
          </div>
        </div>
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
      .dossiers-grid {
        display: grid;
        grid-template-columns: repeat(auto-fill, minmax(280px, 1fr));
        gap: 12px;
      }
      .dossier-card {
        background: white;
        border-radius: 8px;
        padding: 12px;
        box-shadow: 0 1px 2px rgba(0, 0, 0, 0.05);
      }
      .dossier-header {
        display: flex;
        align-items: center;
        gap: 10px;
        margin-bottom: 12px;
      }
      .patient-avatar {
        width: 36px;
        height: 36px;
        background: #0d9488;
        border-radius: 50%;
        display: flex;
        align-items: center;
        justify-content: center;
        font-size: 12px;
        font-weight: 600;
        color: white;
      }
      .patient-info {
        flex: 1;
      }
      .patient-name {
        display: block;
        font-size: 13px;
        font-weight: 600;
        color: #0f172a;
      }
      .dossier-id {
        font-size: 11px;
        color: #64748b;
      }
      .dossier-status {
        padding: 3px 8px;
        border-radius: 4px;
        font-size: 10px;
        font-weight: 500;
      }
      .dossier-status.complet {
        background: #dcfce7;
        color: #166534;
      }
      .dossier-status.en.cours,
      .dossier-status.en {
        background: #dbeafe;
        color: #1e40af;
      }
      .dossier-status.à.valider,
      .dossier-status.à {
        background: #fef3c7;
        color: #b45309;
      }
      .dossier-details {
        border-top: 1px solid #f1f5f9;
        padding-top: 10px;
        margin-bottom: 10px;
      }
      .detail-row {
        display: flex;
        justify-content: space-between;
        margin-bottom: 6px;
      }
      .label {
        font-size: 11px;
        color: #64748b;
      }
      .value {
        font-size: 11px;
        color: #374151;
        font-weight: 500;
      }
      .value.asa {
        background: #f1f5f9;
        padding: 2px 6px;
        border-radius: 4px;
      }
      .dossier-actions {
        display: flex;
        gap: 6px;
      }
      .btn-action {
        flex: 1;
        padding: 6px;
        border: none;
        border-radius: 4px;
        font-size: 11px;
        font-weight: 500;
        cursor: pointer;
        background: #0d9488;
        color: white;
      }
      .btn-action.secondary {
        background: #f1f5f9;
        color: #374151;
      }
    `,
  ],
})
export class DossiersComponent {
  dossiers = [
    {
      initiales: 'AB',
      patient: 'Ahmed Benali',
      numero: 'DA-2024-001',
      intervention: 'Appendicectomie',
      date: '05/12/2024',
      asa: 'ASA I',
      statut: 'Complet',
    },
    {
      initiales: 'MK',
      patient: 'Mohamed Khaled',
      numero: 'DA-2024-002',
      intervention: 'Cholécystectomie',
      date: '05/12/2024',
      asa: 'ASA II',
      statut: 'En cours',
    },
    {
      initiales: 'SL',
      patient: 'Sara Lahlou',
      numero: 'DA-2024-003',
      intervention: 'Hernioplastie',
      date: '05/12/2024',
      asa: 'ASA I',
      statut: 'À valider',
    },
    {
      initiales: 'FB',
      patient: 'Fatima Bouzid',
      numero: 'DA-2024-004',
      intervention: 'Thyroïdectomie',
      date: '04/12/2024',
      asa: 'ASA II',
      statut: 'Complet',
    },
  ];
}
