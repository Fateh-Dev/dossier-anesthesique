import { Component, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReferenceService, RefItem } from '../../services/reference.service';

@Component({
  selector: 'app-parametres',
  standalone: true,
  imports: [CommonModule, FormsModule],
  template: `
    <div class="page">
      <div class="page-header">
        <h1>Paramètres - Tables de référence</h1>
      </div>

      <div class="tabs">
        <button
          *ngFor="let tab of tabs"
          [class.active]="activeTab === tab.id"
          (click)="selectTab(tab.id)"
        >
          {{ tab.label }}
        </button>
      </div>

      <div class="content-area">
        <div class="table-header">
          <input
            type="text"
            placeholder="Rechercher..."
            class="search-input"
            [(ngModel)]="searchQuery"
          />
          <button class="btn-primary" (click)="openModal()">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 24 24"
              stroke-width="1.5"
              stroke="currentColor"
            >
              <path stroke-linecap="round" stroke-linejoin="round" d="M12 4.5v15m7.5-7.5h-15" />
            </svg>
            Ajouter
          </button>
        </div>

        <div class="loading" *ngIf="loading()">Chargement...</div>

        <div class="table-container" *ngIf="!loading()">
          <table>
            <thead>
              <tr>
                <th>#</th>
                <th>Libellé</th>
                <th>Actions</th>
              </tr>
            </thead>
            <tbody>
              <tr *ngFor="let item of filteredItems(); let i = index">
                <td>{{ i + 1 }}</td>
                <td>{{ item.label }}</td>
                <td>
                  <div class="actions">
                    <button class="btn-icon edit" title="Modifier" (click)="openModal(item)">
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
                          d="M16.862 4.487l1.687-1.688a1.875 1.875 0 112.652 2.652L10.582 16.07a4.5 4.5 0 01-1.897 1.13L6 18l.8-2.685a4.5 4.5 0 011.13-1.897l8.932-8.931zm0 0L19.5 7.125"
                        />
                      </svg>
                    </button>
                    <button class="btn-icon delete" title="Supprimer" (click)="confirmDelete(item)">
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
              <tr *ngIf="filteredItems().length === 0">
                <td colspan="3" class="empty">Aucun élément trouvé</td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>

      <!-- Modal -->
      <div class="modal-overlay" *ngIf="showModal()" (click)="closeModal()">
        <div class="modal" (click)="$event.stopPropagation()">
          <div class="modal-header">
            <h3>{{ editingItem() ? 'Modifier' : 'Ajouter' }} {{ getCurrentTabLabel() }}</h3>
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
            <div class="form-group">
              <label>Libellé *</label>
              <input type="text" [(ngModel)]="formLabel" placeholder="Entrez le libellé..." />
            </div>
          </div>
          <div class="modal-footer">
            <button class="btn-cancel" (click)="closeModal()">Annuler</button>
            <button
              class="btn-save"
              (click)="saveItem()"
              [disabled]="!formLabel.trim() || saving()"
            >
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
              Êtes-vous sûr de vouloir supprimer <strong>{{ itemToDelete()?.label }}</strong> ?
            </p>
            <p class="warning">Cette action est irréversible.</p>
          </div>
          <div class="modal-footer">
            <button class="btn-cancel" (click)="closeDeleteModal()">Annuler</button>
            <button class="btn-delete" (click)="deleteItem()" [disabled]="deleting()">
              {{ deleting() ? 'Suppression...' : 'Supprimer' }}
            </button>
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
        margin-bottom: 12px;
      }
      .page-header h1 {
        font-size: 18px;
        font-weight: 600;
        color: #0f172a;
      }
      .tabs {
        display: flex;
        gap: 4px;
        margin-bottom: 12px;
        flex-wrap: wrap;
      }
      .tabs button {
        padding: 8px 14px;
        border: 1px solid #e2e8f0;
        background: white;
        border-radius: 6px;
        font-size: 12px;
        cursor: pointer;
        white-space: nowrap;
        transition: all 0.15s;
      }
      .tabs button:hover {
        border-color: #0d9488;
      }
      .tabs button.active {
        background: #0d9488;
        color: white;
        border-color: #0d9488;
      }
      .content-area {
        background: white;
        border-radius: 8px;
        padding: 12px;
        box-shadow: 0 1px 2px rgba(0, 0, 0, 0.05);
      }
      .table-header {
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
      .loading {
        padding: 40px;
        text-align: center;
        color: #64748b;
      }
      .table-container {
        overflow-x: auto;
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
      td.empty {
        text-align: center;
        color: #94a3b8;
        padding: 30px;
      }
      .actions {
        display: flex;
        gap: 4px;
      }
      .btn-icon {
        padding: 6px;
        border: none;
        background: #f1f5f9;
        border-radius: 4px;
        cursor: pointer;
        transition: all 0.15s;
      }
      .btn-icon svg {
        width: 14px;
        height: 14px;
        color: #64748b;
      }
      .btn-icon.edit:hover {
        background: #dbeafe;
      }
      .btn-icon.edit:hover svg {
        color: #2563eb;
      }
      .btn-icon.delete:hover {
        background: #fee2e2;
      }
      .btn-icon.delete:hover svg {
        color: #dc2626;
      }

      /* Modal */
      .modal-overlay {
        position: fixed;
        inset: 0;
        background: rgba(0, 0, 0, 0.5);
        display: flex;
        align-items: center;
        justify-content: center;
        z-index: 100;
      }
      .modal {
        background: white;
        border-radius: 8px;
        width: 90%;
        max-width: 400px;
        box-shadow: 0 20px 50px rgba(0, 0, 0, 0.2);
      }
      .modal-header {
        display: flex;
        justify-content: space-between;
        align-items: center;
        padding: 12px 16px;
        border-bottom: 1px solid #e2e8f0;
      }
      .modal-header h3 {
        font-size: 14px;
        font-weight: 600;
        color: #0f172a;
      }
      .close-btn {
        padding: 4px;
        border: none;
        background: transparent;
        cursor: pointer;
      }
      .close-btn svg {
        width: 18px;
        height: 18px;
        color: #64748b;
      }
      .modal-body {
        padding: 16px;
      }
      .form-group {
        margin-bottom: 12px;
      }
      .form-group label {
        display: block;
        font-size: 12px;
        font-weight: 500;
        color: #374151;
        margin-bottom: 6px;
      }
      .form-group input {
        width: 100%;
        padding: 10px 12px;
        border: 1px solid #e2e8f0;
        border-radius: 6px;
        font-size: 13px;
      }
      .form-group input:focus {
        outline: none;
        border-color: #0d9488;
        box-shadow: 0 0 0 3px rgba(13, 148, 136, 0.1);
      }
      .modal-footer {
        display: flex;
        gap: 8px;
        justify-content: flex-end;
        padding: 12px 16px;
        border-top: 1px solid #e2e8f0;
      }
      .btn-cancel {
        padding: 8px 16px;
        border: 1px solid #e2e8f0;
        background: white;
        border-radius: 6px;
        font-size: 12px;
        cursor: pointer;
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
      .btn-delete:disabled {
        opacity: 0.6;
        cursor: not-allowed;
      }
      .delete-modal .warning {
        color: #dc2626;
        font-size: 11px;
        margin-top: 8px;
      }
    `,
  ],
})
export class ParametresComponent {
  private refService = inject(ReferenceService);

  activeTab = 'specialites';
  searchQuery = '';
  formLabel = '';

  loading = signal(false);
  saving = signal(false);
  deleting = signal(false);
  showModal = signal(false);
  showDeleteModal = signal(false);
  editingItem = signal<RefItem | null>(null);
  itemToDelete = signal<RefItem | null>(null);
  items = signal<RefItem[]>([]);

  tabs = [
    { id: 'specialites', label: 'Spécialités', description: 'Spécialités' },
    { id: 'typesAnesthesies', label: 'Types Anesthésie', description: "Type d'anesthesie" },
    {
      id: 'gradesScientifiques',
      label: 'Grades Scientifiques',
      description: 'Grades Scientifiques',
    },
    { id: 'respirateurs', label: 'Respirateurs', description: 'Respirateurs' },
    { id: 'armes', label: 'Armes', description: 'Armes' },
    { id: 'agents', label: 'Agents Anesthésiques', description: 'Agents Anesthésiques' },
    { id: 'grades', label: 'Grades', description: 'Grades' },
  ];

  constructor() {
    this.loadData();
  }

  selectTab(tabId: string) {
    this.activeTab = tabId;
    this.searchQuery = '';
    this.loadData();
  }

  getCurrentTabLabel(): string {
    return this.tabs.find((t) => t.id === this.activeTab)?.label || '';
  }

  getCurrentTabDescription(): string {
    return this.activeTab;
  }

  filteredItems() {
    if (!this.searchQuery.trim()) return this.items();
    const query = this.searchQuery.toLowerCase();
    return this.items().filter((item) => item.label.toLowerCase().includes(query));
  }

  loadData() {
    this.loading.set(true);
    let request$;

    switch (this.activeTab) {
      case 'specialites':
        request$ = this.refService.getSpecialites();
        break;
      case 'typesAnesthesies':
        request$ = this.refService.getTypesAnesthesies();
        break;
      case 'gradesScientifiques':
        request$ = this.refService.getGradesScientifiques();
        break;
      case 'respirateurs':
        request$ = this.refService.getRespirateurs();
        break;
      case 'armes':
        request$ = this.refService.getArmes();
        break;
      case 'agents':
        request$ = this.refService.getAgents();
        break;
      case 'grades':
        request$ = this.refService.getGrades();
        break;
      default:
        this.loading.set(false);
        return;
    }

    request$.subscribe({
      next: (data) => {
        this.items.set(data);
        this.loading.set(false);
      },
      error: (err) => {
        console.error('Error loading data:', err);
        this.loading.set(false);
      },
    });
  }

  openModal(item?: RefItem) {
    this.editingItem.set(item || null);
    this.formLabel = item?.label || '';
    this.showModal.set(true);
  }

  closeModal() {
    this.showModal.set(false);
    this.editingItem.set(null);
    this.formLabel = '';
  }

  saveItem() {
    if (!this.formLabel.trim()) return;

    this.saving.set(true);
    const editing = this.editingItem();

    if (editing) {
      // Update
      let update$;
      const payload = {
        label: this.formLabel.trim(),
        description: this.getCurrentTabDescription(),
      };

      switch (this.activeTab) {
        case 'specialites':
          update$ = this.refService.updateSpecialite(editing.id, payload);
          break;
        case 'typesAnesthesies':
          update$ = this.refService.updateTypeAnesthesie(editing.id, payload);
          break;
        case 'gradesScientifiques':
          update$ = this.refService.updateGradeScientifique(editing.id, payload);
          break;
        case 'respirateurs':
          update$ = this.refService.updateRespirateur(editing.id, payload);
          break;
        case 'armes':
          update$ = this.refService.updateArme(editing.id, payload);
          break;
        case 'agents':
          update$ = this.refService.updateAgent(editing.id, payload);
          break;
        case 'grades':
          update$ = this.refService.updateGrade(editing.id, payload);
          break;
        default:
          this.saving.set(false);
          return;
      }

      update$.subscribe({
        next: () => {
          this.saving.set(false);
          this.closeModal();
          this.loadData();
        },
        error: (err) => {
          console.error('Error updating:', err);
          this.saving.set(false);
        },
      });
    } else {
      // Create - use specific endpoint based on activeTab
      const label = this.formLabel.trim();
      let create$;

      switch (this.activeTab) {
        case 'specialites':
          create$ = this.refService.createSpecialite(label);
          break;
        case 'typesAnesthesies':
          create$ = this.refService.createTypeAnesthesie(label);
          break;
        case 'gradesScientifiques':
          create$ = this.refService.createGradeScientifique(label);
          break;
        case 'respirateurs':
          create$ = this.refService.createRespirateur(label);
          break;
        case 'armes':
          create$ = this.refService.createArme(label);
          break;
        case 'agents':
          create$ = this.refService.createAgent(label);
          break;
        case 'grades':
          create$ = this.refService.createGrade(label);
          break;
        default:
          this.saving.set(false);
          return;
      }

      create$.subscribe({
        next: () => {
          this.saving.set(false);
          this.closeModal();
          this.loadData();
        },
        error: (err) => {
          console.error('Error creating:', err);
          this.saving.set(false);
        },
      });
    }
  }

  confirmDelete(item: RefItem) {
    this.itemToDelete.set(item);
    this.showDeleteModal.set(true);
  }

  closeDeleteModal() {
    this.showDeleteModal.set(false);
    this.itemToDelete.set(null);
  }

  deleteItem() {
    const item = this.itemToDelete();
    if (!item) return;

    this.deleting.set(true);
    let delete$;

    switch (this.activeTab) {
      case 'specialites':
        delete$ = this.refService.deleteSpecialite(item.id);
        break;
      case 'typesAnesthesies':
        delete$ = this.refService.deleteTypeAnesthesie(item.id);
        break;
      case 'gradesScientifiques':
        delete$ = this.refService.deleteGradeScientifique(item.id);
        break;
      case 'respirateurs':
        delete$ = this.refService.deleteRespirateur(item.id);
        break;
      case 'armes':
        delete$ = this.refService.deleteArme(item.id);
        break;
      case 'agents':
        delete$ = this.refService.deleteAgent(item.id);
        break;
      case 'grades':
        delete$ = this.refService.deleteGrade(item.id);
        break;
      default:
        this.deleting.set(false);
        return;
    }

    delete$.subscribe({
      next: () => {
        this.deleting.set(false);
        this.closeDeleteModal();
        this.loadData();
      },
      error: (err) => {
        console.error('Error deleting:', err);
        this.deleting.set(false);
      },
    });
  }
}
