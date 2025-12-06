import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="dashboard">
      <div class="stats-row">
        <div class="stat-card">
          <div class="stat-icon patients">
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
                d="M15 19.128a9.38 9.38 0 002.625.372 9.337 9.337 0 004.121-.952 4.125 4.125 0 00-7.533-2.493M15 19.128v-.003c0-1.113-.285-2.16-.786-3.07M15 19.128v.106A12.318 12.318 0 018.624 21c-2.331 0-4.512-.645-6.374-1.766l-.001-.109a6.375 6.375 0 0111.964-3.07M12 6.375a3.375 3.375 0 11-6.75 0 3.375 3.375 0 016.75 0zm8.25 2.25a2.625 2.625 0 11-5.25 0 2.625 2.625 0 015.25 0z"
              />
            </svg>
          </div>
          <div class="stat-info">
            <span class="stat-value">248</span>
            <span class="stat-label">Patients</span>
          </div>
        </div>
        <div class="stat-card">
          <div class="stat-icon interventions">
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
                d="M11.42 15.17L17.25 21A2.652 2.652 0 0021 17.25l-5.877-5.877M11.42 15.17l2.496-3.03c.317-.384.74-.626 1.208-.766M11.42 15.17l-4.655 5.653a2.548 2.548 0 11-3.586-3.586l6.837-5.63m5.108-.233c.55-.164 1.163-.188 1.743-.14a4.5 4.5 0 004.486-6.336l-3.276 3.277a3.004 3.004 0 01-2.25-2.25l3.276-3.276a4.5 4.5 0 00-6.336 4.486c.091 1.076-.071 2.264-.904 2.95l-.102.085m-1.745 1.437L5.909 7.5H4.5L2.25 3.75l1.5-1.5L7.5 4.5v1.409l4.26 4.26m-1.745 1.437l1.745-1.437m6.615 8.206L15.75 15.75M4.867 19.125h.008v.008h-.008v-.008z"
              />
            </svg>
          </div>
          <div class="stat-info">
            <span class="stat-value">42</span>
            <span class="stat-label">Interventions</span>
          </div>
        </div>
        <div class="stat-card">
          <div class="stat-icon today">
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
                d="M6.75 3v2.25M17.25 3v2.25M3 18.75V7.5a2.25 2.25 0 012.25-2.25h13.5A2.25 2.25 0 0121 7.5v11.25m-18 0A2.25 2.25 0 005.25 21h13.5A2.25 2.25 0 0021 18.75m-18 0v-7.5A2.25 2.25 0 015.25 9h13.5A2.25 2.25 0 0121 11.25v7.5"
              />
            </svg>
          </div>
          <div class="stat-info">
            <span class="stat-value">8</span>
            <span class="stat-label">Aujourd'hui</span>
          </div>
        </div>
        <div class="stat-card">
          <div class="stat-icon pending">
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
                d="M12 6v6h4.5m4.5 0a9 9 0 11-18 0 9 9 0 0118 0z"
              />
            </svg>
          </div>
          <div class="stat-info">
            <span class="stat-value">5</span>
            <span class="stat-label">En attente</span>
          </div>
        </div>
      </div>

      <div class="content-grid">
        <div class="card quick-actions">
          <h3 class="card-title">Actions rapides</h3>
          <div class="actions-list">
            <button class="action-btn">
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
            <button class="action-btn">
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
            <button class="action-btn">
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
                  d="M21 21l-5.197-5.197m0 0A7.5 7.5 0 105.196 5.196a7.5 7.5 0 0010.607 10.607z"
                />
              </svg>
              Rechercher
            </button>
          </div>
        </div>

        <div class="card recent-list">
          <h3 class="card-title">Interventions récentes</h3>
          <div class="list-items">
            <div class="list-item">
              <div class="item-avatar">AB</div>
              <div class="item-info">
                <span class="item-name">Ahmed Benali</span>
                <span class="item-detail">Appendicectomie • 10:30</span>
              </div>
              <span class="item-status completed">Terminé</span>
            </div>
            <div class="list-item">
              <div class="item-avatar">MK</div>
              <div class="item-info">
                <span class="item-name">Mohamed Khaled</span>
                <span class="item-detail">Cholécystectomie • 14:00</span>
              </div>
              <span class="item-status inprogress">En cours</span>
            </div>
            <div class="list-item">
              <div class="item-avatar">SL</div>
              <div class="item-info">
                <span class="item-name">Sara Lahlou</span>
                <span class="item-detail">Hernioplastie • 16:30</span>
              </div>
              <span class="item-status pending">Planifié</span>
            </div>
          </div>
        </div>
      </div>
    </div>
  `,
  styles: [
    `
      .dashboard {
        padding: 12px;
      }
      .stats-row {
        display: grid;
        grid-template-columns: repeat(2, 1fr);
        gap: 10px;
        margin-bottom: 12px;
      }
      @media (min-width: 768px) {
        .stats-row {
          grid-template-columns: repeat(4, 1fr);
        }
      }
      .stat-card {
        background: var(--card-bg);
        border-radius: 8px;
        padding: 12px;
        display: flex;
        align-items: center;
        gap: 10px;
        box-shadow: 0 1px 2px rgba(0, 0, 0, 0.05);
      }
      .stat-icon {
        width: 36px;
        height: 36px;
        border-radius: 8px;
        display: flex;
        align-items: center;
        justify-content: center;
      }
      .stat-icon svg {
        width: 18px;
        height: 18px;
        color: white;
      }
      .stat-icon.patients {
        background: #0d9488;
      }
      .stat-icon.interventions {
        background: #6366f1;
      }
      .stat-icon.today {
        background: #f59e0b;
      }
      .stat-icon.pending {
        background: #ec4899;
      }
      .stat-info {
        display: flex;
        flex-direction: column;
      }
      .stat-value {
        font-size: 20px;
        font-weight: 700;
        color: var(--text-color);
      }
      .stat-label {
        font-size: 11px;
        color: var(--text-muted);
      }
      .content-grid {
        display: grid;
        gap: 10px;
      }
      @media (min-width: 768px) {
        .content-grid {
          grid-template-columns: 280px 1fr;
        }
      }
      .card {
        background: var(--card-bg);
        border-radius: 8px;
        padding: 12px;
        box-shadow: 0 1px 2px rgba(0, 0, 0, 0.05);
      }
      .card-title {
        font-size: 13px;
        font-weight: 600;
        color: var(--text-color);
        margin-bottom: 10px;
      }
      .actions-list {
        display: flex;
        flex-direction: column;
        gap: 6px;
      }
      .action-btn {
        display: flex;
        align-items: center;
        gap: 8px;
        padding: 8px 10px;
        border: 1px solid var(--border-color);
        background: var(--card-bg);
        border-radius: 6px;
        font-size: 12px;
        color: var(--text-color);
        cursor: pointer;
        transition: all 0.15s ease;
      }
      .action-btn:hover {
        border-color: #0d9488;
        color: #0d9488;
        background: var(--hover-bg);
      }
      .action-btn svg {
        width: 14px;
        height: 14px;
      }
      .list-items {
        display: flex;
        flex-direction: column;
        gap: 8px;
      }
      .list-item {
        display: flex;
        align-items: center;
        gap: 10px;
        padding: 8px;
        background: var(--hover-bg);
        border-radius: 6px;
      }
      .item-avatar {
        width: 32px;
        height: 32px;
        background: #0d9488;
        border-radius: 50%;
        display: flex;
        align-items: center;
        justify-content: center;
        font-size: 11px;
        font-weight: 600;
        color: white;
      }
      .item-info {
        flex: 1;
        display: flex;
        flex-direction: column;
      }
      .item-name {
        font-size: 12px;
        font-weight: 500;
        color: var(--text-color);
      }
      .item-detail {
        font-size: 11px;
        color: var(--text-muted);
      }
      .item-status {
        font-size: 10px;
        font-weight: 500;
        padding: 3px 6px;
        border-radius: 4px;
      }
      .item-status.completed {
        background: #dcfce7;
        color: #166534;
      }
      .item-status.inprogress {
        background: #dbeafe;
        color: #1e40af;
      }
      .item-status.pending {
        background: #fef3c7;
        color: #b45309;
      }
    `,
  ],
})
export class DashboardComponent {}
