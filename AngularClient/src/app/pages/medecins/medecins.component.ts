import { Component, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MedecinService, Medecin, MedecinQuery } from '../../services/medecin.service';

@Component({
  selector: 'app-medecins',
  standalone: true,
  imports: [CommonModule, FormsModule],
  template: `
    <div class="page">
      <div class="page-header">
        <h1>Médecins</h1>
        <button class="btn-primary" (click)="openNewModal($event)">
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
        <input
          type="text"
          placeholder="Rechercher par nom..."
          class="search-input"
          [(ngModel)]="searchName"
          (keyup.enter)="loadMedecins()"
        />
        <select class="filter-select" [(ngModel)]="filterSpecialite" (change)="loadMedecins()">
          <option value="">Toutes les spécialités</option>
          <option value="Anesthésiste">Anesthésiste</option>
          <option value="Chirurgien">Chirurgien</option>
        </select>
        <button class="btn-icon refresh" title="Actualiser" (click)="loadMedecins()">
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
              d="M16.023 9.348h4.992v-.001M2.985 19.644v-4.992m0 0h4.992m-4.993 0l3.181 3.183a8.25 8.25 0 0013.803-3.7M4.031 9.865a8.25 8.25 0 0113.803-3.7l3.181 3.182m0-4.991v4.99"
            />
          </svg>
        </button>
      </div>

      <div class="loading" *ngIf="loading()">Chargement...</div>
      <div class="error-msg" *ngIf="error()">{{ error() }}</div>

      <div class="table-container" *ngIf="!loading()">
        <table>
          <thead>
            <tr>
              <th>Matricule</th>
              <th>Nom</th>
              <th>Prénom</th>
              <th>Spécialité</th>
              <th>Grade</th>
              <th>Téléphone</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            <tr *ngFor="let medecin of medecins">
              <td>{{ medecin.matricule }}</td>
              <td>{{ medecin.nom }}</td>
              <td>{{ medecin.prenom }}</td>
              <td>{{ medecin.specialite }}</td>
              <td>{{ medecin.gradeScientifique }}</td>
              <td>{{ medecin.numeroTel }}</td>
              <td>
                <div class="actions">
                  <button
                    class="btn-icon"
                    title="Modifier"
                    (click)="openEditModal(medecin, $event)"
                  >
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
                  <button
                    class="btn-icon delete"
                    title="Supprimer"
                    (click)="confirmDelete(medecin)"
                  >
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
                        d="M14.74 9l-.346 9m-4.788 0L9.26 9m9.968-3.21c.342.052.682.107 1.022.166m-1.022-.165L18.16 19.673a2.25 2.25 0 01-2.244 2.077H8.084a2.25 2.25 0 01-2.244-2.077L4.772 5.79m14.456 0a48.108 48.108 0 00-3.478-.397m-12 .562c.34-.059.68-.114 1.022-.165m0 0a48.11 48.11 0 013.478-.397m7.5 0v-.916c0-1.18-.91-2.164-2.09-2.201a51.964 51.964 0 00-3.32 0c-1.18.037-2.09 1.022-2.09 2.201v.916m7.5 0a48.667 48.667 0 00-7.5 0"
                      />
                    </svg>
                  </button>
                </div>
              </td>
            </tr>
            <tr *ngIf="medecins.length === 0">
              <td colspan="7" style="text-align: center; padding: 20px; color: var(--text-muted);">
                Aucun médecin trouvé.
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>

    <!-- Modal Form -->
    <div class="modal-overlay" *ngIf="showModal()" (click)="closeModal()">
      <div class="modal" (click)="$event.stopPropagation()">
        <div class="modal-header">
          <h3>{{ editingMedecin() ? 'Modifier' : 'Ajouter' }} un médecin</h3>
          <button class="close-btn" (click)="closeModal()">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 24 24"
              stroke-width="1.5"
              stroke="currentColor"
            >
              <path stroke-linecap="round" stroke-linejoin="round" d="M6 18L18 6M6 6l12 12" />
            </svg>
          </button>
        </div>
        <div class="modal-body">
          <div class="form-row">
            <div class="form-group half">
              <label>Matricule *</label>
              <input type="text" [(ngModel)]="currentMedecin.matricule" placeholder="Ex: 2024001" />
            </div>
          </div>
          <div class="form-row">
            <div class="form-group half">
              <label>Nom *</label>
              <input type="text" [(ngModel)]="currentMedecin.nom" placeholder="Nom" />
            </div>
            <div class="form-group half">
              <label>Prénom *</label>
              <input type="text" [(ngModel)]="currentMedecin.prenom" placeholder="Prénom" />
            </div>
          </div>
          <div class="form-row">
            <div class="form-group half">
              <label>Spécialité</label>
              <input
                type="text"
                [(ngModel)]="currentMedecin.specialite"
                placeholder="Ex: Anesthésiste"
              />
            </div>
            <div class="form-group half">
              <label>Grade Scientifique</label>
              <input
                type="text"
                [(ngModel)]="currentMedecin.gradeScientifique"
                placeholder="Ex: Professeur"
              />
            </div>
          </div>
          <div class="form-row">
            <div class="form-group half">
              <label>Téléphone</label>
              <input type="text" [(ngModel)]="currentMedecin.numeroTel" placeholder="055..." />
            </div>
            <div class="form-group half">
              <label>Sexe</label>
              <select [(ngModel)]="currentMedecin.sexe">
                <option value="">Sélectionner</option>
                <option value="H">Homme</option>
                <option value="F">Femme</option>
              </select>
            </div>
          </div>
        </div>
        <div class="modal-footer">
          <button class="btn-cancel" (click)="closeModal()">Annuler</button>
          <button class="btn-save" (click)="saveMedecin()" [disabled]="saving() || !isValid()">
            {{ saving() ? 'Enregistrement...' : 'Enregistrer' }}
          </button>
        </div>
      </div>
    </div>

    <!-- Delete Confirmation Modal -->
    <div class="modal-overlay" *ngIf="showDeleteModal()" (click)="closeDeleteModal()">
      <div class="modal delete-modal" (click)="$event.stopPropagation()">
        <div class="modal-header">
          <h3>Confirmer la suppression</h3>
        </div>
        <div class="modal-body">
          <p>
            Êtes-vous sûr de vouloir supprimer
            <strong>{{ medecinToDelete()?.nom }} {{ medecinToDelete()?.prenom }}</strong> ?
          </p>
          <p class="warning">Cette action est irréversible.</p>
        </div>
        <div class="modal-footer">
          <button class="btn-cancel" (click)="closeDeleteModal()">Annuler</button>
          <button class="btn-delete" (click)="deleteMedecin()" [disabled]="deleting()">
            {{ deleting() ? 'Suppression...' : 'Supprimer' }}
          </button>
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
      .btn-primary:hover {
        background: #0f766e;
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
        align-items: center;
      }
      .search-input,
      .filter-select {
        padding: 8px 12px;
        border: 1px solid var(--input-border);
        border-radius: 6px;
        font-size: 12px;
        background: var(--input-bg);
        color: var(--text-color);
      }
      .search-input {
        flex: 1;
        min-width: 200px;
      }

      .table-container {
        background: var(--card-bg);
        border-radius: 8px;
        overflow-x: auto;
        box-shadow: 0 1px 2px rgba(0, 0, 0, 0.05);
      }
      table {
        width: 100%;
        border-collapse: collapse;
        min-width: 800px;
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
        width: 16px;
        height: 16px;
        color: var(--text-muted);
      }
      .btn-icon.delete:hover svg {
        color: #dc2626;
      }
      .btn-icon.refresh svg {
        width: 18px;
        height: 18px;
      }

      .loading {
        padding: 40px;
        text-align: center;
        color: var(--text-muted);
      }
      .error-msg {
        color: #dc2626;
        background: #fee2e2;
        padding: 10px;
        border-radius: 6px;
        margin-bottom: 12px;
        font-size: 12px;
      }

      /* Modal Styles */
      .modal-overlay {
        position: fixed;
        inset: 0;
        background: rgba(0, 0, 0, 0.5);
        display: flex;
        align-items: center;
        justify-content: center;
        z-index: 1000;
      }
      .modal {
        background: var(--card-bg);
        border-radius: 8px;
        width: 90%;
        max-width: 500px;
        box-shadow: 0 20px 50px rgba(0, 0, 0, 0.2);
        color: var(--text-color);
      }
      .modal-header {
        display: flex;
        justify-content: space-between;
        align-items: center;
        padding: 12px 16px;
        border-bottom: 1px solid var(--border-color);
      }
      .modal-header h3 {
        font-size: 14px;
        font-weight: 600;
        margin: 0;
      }
      .close-btn {
        background: transparent;
        border: none;
        cursor: pointer;
        color: var(--text-muted);
      }
      .modal-body {
        padding: 16px;
      }
      .form-row {
        display: flex;
        gap: 12px;
        margin-bottom: 12px;
      }
      .form-group {
        flex: 1;
      }
      .form-group.half {
        flex: 0 0 calc(50% - 6px);
      }
      .form-group label {
        display: block;
        font-size: 11px;
        font-weight: 500;
        color: var(--text-muted);
        margin-bottom: 4px;
      }
      .form-group input,
      .form-group select {
        width: 100%;
        padding: 8px 10px;
        border: 1px solid var(--input-border);
        border-radius: 6px;
        font-size: 12px;
        background: var(--input-bg);
        color: var(--text-color);
        box-sizing: border-box;
      }
      .form-group input:focus,
      .form-group select:focus {
        outline: none;
        border-color: #0d9488;
      }

      .modal-footer {
        display: flex;
        gap: 8px;
        justify-content: flex-end;
        padding: 12px 16px;
        border-top: 1px solid var(--border-color);
      }
      .btn-cancel {
        padding: 8px 16px;
        border: 1px solid var(--border-color);
        background: var(--card-bg);
        border-radius: 6px;
        font-size: 12px;
        cursor: pointer;
        color: var(--text-color);
      }
      .btn-save {
        padding: 8px 16px;
        border: none;
        background: #0d9488;
        color: white;
        border-radius: 6px;
        font-size: 12px;
        font-weight: 500;
        cursor: pointer;
      }
      .btn-save:disabled {
        opacity: 0.6;
        cursor: not-allowed;
      }
      .btn-delete {
        padding: 8px 16px;
        border: none;
        background: #dc2626;
        color: white;
        border-radius: 6px;
        font-size: 12px;
        font-weight: 500;
        cursor: pointer;
      }
      .warning {
        color: #dc2626;
        font-size: 11px;
        margin-top: 8px;
      }
    `,
  ],
})
export class MedecinsComponent {
  private medecinService = inject(MedecinService);

  // State using plain array to avoid template signal issues
  medecins: Medecin[] = [];
  loading = signal(false);
  saving = signal(false);
  deleting = signal(false);
  error = signal<string | null>(null);

  searchName = '';
  filterSpecialite = '';

  showModal = signal(false);
  editingMedecin = signal<Medecin | null>(null);
  currentMedecin: Medecin = this.getEmptyMedecin();

  showDeleteModal = signal(false);
  medecinToDelete = signal<Medecin | null>(null);

  constructor() {
    this.loadMedecins();
  }

  loadMedecins() {
    this.loading.set(true);
    this.error.set(null);

    // Ensure all fields match backend DTO Expected types
    const query: MedecinQuery = {
      nom: this.searchName || undefined,
      specialite: this.filterSpecialite || undefined,
      skipCount: 0,
      maxResultCount: 100,
      sorting: '', // Ensure sorting is present
      nationnalite: undefined,
      matricule: undefined,
      sexe: undefined,
      gradeScientifique: undefined,
    };

    this.medecinService.getAllMedecinsFilter(query).subscribe({
      next: (res) => {
        this.medecins = res.items; // Direct assignment
        this.loading.set(false);
      },
      error: (err) => {
        console.error('Error loading medecins', err);
        this.error.set('Impossible de charger les médecins. Vérifiez la connexion.');
        this.loading.set(false);
      },
    });
  }

  // ... (rest of methods)

  getEmptyMedecin(): Medecin {
    return {
      nom: '',
      prenom: '',
      matricule: '',
      specialite: '',
      sexe: '',
      gradeScientifique: '',
      numeroTel: '',
    };
  }

  openNewModal(event?: Event) {
    if (event) {
      event.preventDefault();
      event.stopPropagation();
    }
    console.log('Opening new modal');
    this.editingMedecin.set(null);
    this.currentMedecin = this.getEmptyMedecin();
    this.showModal.set(true);
  }

  openEditModal(medecin: Medecin, event?: Event) {
    if (event) {
      event.preventDefault();
      event.stopPropagation();
    }
    console.log('Opening edit modal', medecin);
    this.editingMedecin.set(medecin);
    this.currentMedecin = { ...medecin };
    this.showModal.set(true);
  }

  closeModal() {
    this.showModal.set(false);
    this.editingMedecin.set(null);
    this.currentMedecin = this.getEmptyMedecin();
  }

  saveMedecin() {
    if (!this.isValid()) return;

    this.saving.set(true);
    this.error.set(null);

    // Create a clean object to send, removing any UI-only properties if any
    const apiModel: Medecin = { ...this.currentMedecin };

    if (this.editingMedecin()) {
      // Update
      this.medecinService.updateMedecin(apiModel).subscribe({
        next: () => {
          this.saving.set(false);
          this.closeModal();
          this.loadMedecins();
        },
        error: (err) => {
          console.error('Error updating', err);
          this.error.set('Erreur lors de la modification.');
          this.saving.set(false);
        },
      });
    } else {
      // Create
      this.medecinService.createMedecin(apiModel).subscribe({
        next: () => {
          this.saving.set(false);
          this.closeModal();
          this.loadMedecins();
        },
        error: (err) => {
          console.error('Error creating', err);
          this.error.set('Erreur lors de la création.');
          this.saving.set(false);
        },
      });
    }
  }

  isValid(): boolean {
    return (
      !!this.currentMedecin.nom && !!this.currentMedecin.prenom && !!this.currentMedecin.matricule
    );
  }

  confirmDelete(medecin: Medecin) {
    this.medecinToDelete.set(medecin);
    this.showDeleteModal.set(true);
  }

  closeDeleteModal() {
    this.showDeleteModal.set(false);
    this.medecinToDelete.set(null);
  }

  deleteMedecin() {
    const medecin = this.medecinToDelete();
    if (!medecin || !medecin.id) return;

    this.deleting.set(true);
    this.medecinService.deleteMedecin(medecin.id).subscribe({
      next: () => {
        this.deleting.set(false);
        this.closeDeleteModal();
        this.loadMedecins();
      },
      error: (err) => {
        console.error('Error deleting', err);
        this.error.set('Erreur lors de la suppression.');
        this.deleting.set(false);
      },
    });
  }
}
