import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-statistiques',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="page">
      <div class="page-header">
        <h1>Statistiques</h1>
        <div class="period-selector">
          <button [class.active]="period === 'week'" (click)="period = 'week'">Semaine</button>
          <button [class.active]="period === 'month'" (click)="period = 'month'">Mois</button>
          <button [class.active]="period === 'year'" (click)="period = 'year'">Année</button>
        </div>
      </div>

      <div class="stats-grid">
        <div class="stat-card large">
          <div class="stat-header">
            <span class="stat-title">Interventions par type</span>
          </div>
          <div class="chart-placeholder">
            <div class="bar-chart">
              <div class="bar" *ngFor="let item of interventionTypes">
                <div class="bar-fill" [style.height.%]="item.percent"></div>
                <span class="bar-label">{{ item.label }}</span>
                <span class="bar-value">{{ item.value }}</span>
              </div>
            </div>
          </div>
        </div>

        <div class="stat-card">
          <div class="stat-header">
            <span class="stat-title">Total interventions</span>
          </div>
          <div class="big-number">156</div>
          <div class="trend positive">+12% vs période précédente</div>
        </div>

        <div class="stat-card">
          <div class="stat-header">
            <span class="stat-title">Durée moyenne</span>
          </div>
          <div class="big-number">2h 15m</div>
          <div class="trend negative">+8% vs période précédente</div>
        </div>
      </div>

      <div class="stats-row">
        <div class="stat-card">
          <div class="stat-header">
            <span class="stat-title">Répartition ASA</span>
          </div>
          <div class="asa-list">
            <div class="asa-item" *ngFor="let asa of asaDistribution">
              <span class="asa-label">{{ asa.label }}</span>
              <div class="asa-bar">
                <div
                  class="asa-fill"
                  [style.width.%]="asa.percent"
                  [style.background]="asa.color"
                ></div>
              </div>
              <span class="asa-value">{{ asa.value }}%</span>
            </div>
          </div>
        </div>

        <div class="stat-card">
          <div class="stat-header">
            <span class="stat-title">Activité récente</span>
          </div>
          <div class="activity-list">
            <div class="activity-item" *ngFor="let activity of recentActivity">
              <div class="activity-dot" [style.background]="activity.color"></div>
              <div class="activity-info">
                <span class="activity-title">{{ activity.title }}</span>
                <span class="activity-time">{{ activity.time }}</span>
              </div>
            </div>
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
        flex-wrap: wrap;
        gap: 8px;
      }
      .page-header h1 {
        font-size: 18px;
        font-weight: 600;
        color: #0f172a;
      }
      .period-selector {
        display: flex;
        gap: 4px;
      }
      .period-selector button {
        padding: 6px 12px;
        border: 1px solid #e2e8f0;
        background: white;
        border-radius: 4px;
        font-size: 11px;
        cursor: pointer;
      }
      .period-selector button.active {
        background: #0d9488;
        color: white;
        border-color: #0d9488;
      }
      .stats-grid {
        display: grid;
        grid-template-columns: 2fr 1fr 1fr;
        gap: 12px;
        margin-bottom: 12px;
      }
      @media (max-width: 768px) {
        .stats-grid {
          grid-template-columns: 1fr;
        }
      }
      .stats-row {
        display: grid;
        grid-template-columns: 1fr 1fr;
        gap: 12px;
      }
      @media (max-width: 768px) {
        .stats-row {
          grid-template-columns: 1fr;
        }
      }
      .stat-card {
        background: white;
        border-radius: 8px;
        padding: 12px;
        box-shadow: 0 1px 2px rgba(0, 0, 0, 0.05);
      }
      .stat-header {
        margin-bottom: 10px;
      }
      .stat-title {
        font-size: 12px;
        font-weight: 600;
        color: #64748b;
      }
      .big-number {
        font-size: 28px;
        font-weight: 700;
        color: #0f172a;
      }
      .trend {
        font-size: 11px;
        margin-top: 4px;
      }
      .trend.positive {
        color: #16a34a;
      }
      .trend.negative {
        color: #dc2626;
      }
      .bar-chart {
        display: flex;
        align-items: flex-end;
        gap: 12px;
        height: 120px;
        padding-top: 20px;
      }
      .bar {
        flex: 1;
        display: flex;
        flex-direction: column;
        align-items: center;
      }
      .bar-fill {
        width: 100%;
        background: #0d9488;
        border-radius: 4px 4px 0 0;
        min-height: 10px;
      }
      .bar-label {
        font-size: 10px;
        color: #64748b;
        margin-top: 6px;
        text-align: center;
      }
      .bar-value {
        font-size: 11px;
        font-weight: 600;
        color: #0f172a;
      }
      .asa-list {
        display: flex;
        flex-direction: column;
        gap: 8px;
      }
      .asa-item {
        display: flex;
        align-items: center;
        gap: 8px;
      }
      .asa-label {
        width: 50px;
        font-size: 11px;
        color: #374151;
      }
      .asa-bar {
        flex: 1;
        height: 8px;
        background: #f1f5f9;
        border-radius: 4px;
        overflow: hidden;
      }
      .asa-fill {
        height: 100%;
        border-radius: 4px;
      }
      .asa-value {
        width: 35px;
        font-size: 11px;
        color: #64748b;
        text-align: right;
      }
      .activity-list {
        display: flex;
        flex-direction: column;
        gap: 10px;
      }
      .activity-item {
        display: flex;
        align-items: center;
        gap: 10px;
      }
      .activity-dot {
        width: 8px;
        height: 8px;
        border-radius: 50%;
      }
      .activity-info {
        flex: 1;
      }
      .activity-title {
        display: block;
        font-size: 12px;
        color: #374151;
      }
      .activity-time {
        font-size: 10px;
        color: #94a3b8;
      }
    `,
  ],
})
export class StatistiquesComponent {
  period = 'month';

  interventionTypes = [
    { label: 'Digestif', value: 42, percent: 70 },
    { label: 'Ortho', value: 28, percent: 47 },
    { label: 'Uro', value: 22, percent: 37 },
    { label: 'Gynéco', value: 18, percent: 30 },
    { label: 'Cardio', value: 12, percent: 20 },
  ];

  asaDistribution = [
    { label: 'ASA I', value: 45, percent: 45, color: '#22c55e' },
    { label: 'ASA II', value: 35, percent: 35, color: '#0d9488' },
    { label: 'ASA III', value: 15, percent: 15, color: '#f59e0b' },
    { label: 'ASA IV', value: 5, percent: 5, color: '#ef4444' },
  ];

  recentActivity = [
    { title: 'Intervention terminée - Ahmed B.', time: 'Il y a 15 min', color: '#22c55e' },
    { title: 'Nouveau dossier créé - Sara L.', time: 'Il y a 45 min', color: '#0d9488' },
    { title: 'Consultation pré-op - Mohamed K.', time: 'Il y a 2h', color: '#6366f1' },
    { title: 'Dossier validé - Fatima B.', time: 'Il y a 3h', color: '#22c55e' },
  ];
}
