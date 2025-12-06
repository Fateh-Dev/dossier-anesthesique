import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-profil',
  standalone: true,
  imports: [CommonModule, FormsModule],
  template: `
    <div class="page">
      <div class="page-header">
        <h1>Mon Profil</h1>
      </div>

      <div class="profile-grid">
        <div class="profile-card">
          <div class="avatar-section">
            <div class="avatar">
              <span>{{ getInitials() }}</span>
            </div>
            <button class="btn-change-avatar">Changer la photo</button>
          </div>

          <div class="info-section">
            <h3>Informations personnelles</h3>
            <div class="form-group">
              <label>Email</label>
              <input type="email" [value]="authService.currentUser()?.email || ''" disabled />
            </div>
            <div class="form-row">
              <div class="form-group">
                <label>Nom</label>
                <input type="text" [(ngModel)]="profile.nom" />
              </div>
              <div class="form-group">
                <label>Prénom</label>
                <input type="text" [(ngModel)]="profile.prenom" />
              </div>
            </div>
            <div class="form-group">
              <label>Spécialité</label>
              <select [(ngModel)]="profile.specialite">
                <option value="anesthesiste">Médecin anesthésiste</option>
                <option value="infirmier">Infirmier anesthésiste</option>
                <option value="chirurgien">Chirurgien</option>
              </select>
            </div>
            <div class="form-group">
              <label>Téléphone</label>
              <input type="tel" [(ngModel)]="profile.telephone" />
            </div>
            <button class="btn-save">Enregistrer les modifications</button>
          </div>
        </div>

        <div class="settings-card">
          <h3>Sécurité</h3>
          <div class="setting-item">
            <div class="setting-info">
              <span class="setting-title">Mot de passe</span>
              <span class="setting-desc">Dernière modification il y a 30 jours</span>
            </div>
            <button class="btn-secondary">Modifier</button>
          </div>
          <div class="setting-item">
            <div class="setting-info">
              <span class="setting-title">Authentification à deux facteurs</span>
              <span class="setting-desc">Non activée</span>
            </div>
            <button class="btn-secondary">Activer</button>
          </div>
        </div>

        <div class="settings-card">
          <h3>Préférences</h3>
          <div class="setting-item">
            <div class="setting-info">
              <span class="setting-title">Notifications par email</span>
              <span class="setting-desc">Recevoir les alertes par email</span>
            </div>
            <label class="toggle">
              <input type="checkbox" [(ngModel)]="preferences.emailNotif" />
              <span class="slider"></span>
            </label>
          </div>
          <div class="setting-item">
            <div class="setting-info">
              <span class="setting-title">Rappels d'intervention</span>
              <span class="setting-desc">Notification avant chaque intervention</span>
            </div>
            <label class="toggle">
              <input type="checkbox" [(ngModel)]="preferences.rappels" />
              <span class="slider"></span>
            </label>
          </div>
          <div class="setting-item">
            <div class="setting-info">
              <span class="setting-title">Langue</span>
              <span class="setting-desc">Langue de l'interface</span>
            </div>
            <select [(ngModel)]="preferences.langue" class="compact-select">
              <option value="fr">Français</option>
              <option value="ar">العربية</option>
              <option value="en">English</option>
            </select>
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
      .profile-grid {
        display: grid;
        gap: 12px;
      }
      @media (min-width: 768px) {
        .profile-grid {
          grid-template-columns: 1fr 300px;
        }
      }
      .profile-card,
      .settings-card {
        background: white;
        border-radius: 8px;
        padding: 16px;
        box-shadow: 0 1px 2px rgba(0, 0, 0, 0.05);
      }
      .avatar-section {
        display: flex;
        flex-direction: column;
        align-items: center;
        padding-bottom: 16px;
        border-bottom: 1px solid #f1f5f9;
        margin-bottom: 16px;
      }
      .avatar {
        width: 80px;
        height: 80px;
        background: linear-gradient(135deg, #0d9488, #065f46);
        border-radius: 50%;
        display: flex;
        align-items: center;
        justify-content: center;
        font-size: 24px;
        font-weight: 600;
        color: white;
        margin-bottom: 10px;
      }
      .btn-change-avatar {
        padding: 6px 12px;
        border: 1px solid #e2e8f0;
        background: white;
        border-radius: 6px;
        font-size: 11px;
        cursor: pointer;
      }
      .info-section h3,
      .settings-card h3 {
        font-size: 13px;
        font-weight: 600;
        color: #0f172a;
        margin-bottom: 12px;
      }
      .form-group {
        margin-bottom: 12px;
      }
      .form-group label {
        display: block;
        font-size: 11px;
        font-weight: 500;
        color: #64748b;
        margin-bottom: 4px;
      }
      .form-group input,
      .form-group select {
        width: 100%;
        padding: 8px 10px;
        border: 1px solid #e2e8f0;
        border-radius: 6px;
        font-size: 12px;
      }
      .form-group input:disabled {
        background: #f8fafc;
        color: #94a3b8;
      }
      .form-row {
        display: grid;
        grid-template-columns: 1fr 1fr;
        gap: 10px;
      }
      .btn-save {
        width: 100%;
        padding: 10px;
        background: #0d9488;
        color: white;
        border: none;
        border-radius: 6px;
        font-size: 12px;
        font-weight: 500;
        cursor: pointer;
      }
      .setting-item {
        display: flex;
        align-items: center;
        justify-content: space-between;
        padding: 10px 0;
        border-bottom: 1px solid #f1f5f9;
      }
      .setting-item:last-child {
        border-bottom: none;
      }
      .setting-info {
        flex: 1;
      }
      .setting-title {
        display: block;
        font-size: 12px;
        font-weight: 500;
        color: #374151;
      }
      .setting-desc {
        font-size: 10px;
        color: #94a3b8;
      }
      .btn-secondary {
        padding: 6px 12px;
        border: 1px solid #e2e8f0;
        background: white;
        border-radius: 6px;
        font-size: 11px;
        cursor: pointer;
      }
      .compact-select {
        padding: 6px 10px;
        border: 1px solid #e2e8f0;
        border-radius: 6px;
        font-size: 11px;
      }
      .toggle {
        position: relative;
        display: inline-block;
        width: 40px;
        height: 22px;
      }
      .toggle input {
        opacity: 0;
        width: 0;
        height: 0;
      }
      .slider {
        position: absolute;
        cursor: pointer;
        inset: 0;
        background: #e2e8f0;
        border-radius: 22px;
        transition: 0.3s;
      }
      .slider:before {
        content: '';
        position: absolute;
        height: 16px;
        width: 16px;
        left: 3px;
        bottom: 3px;
        background: white;
        border-radius: 50%;
        transition: 0.3s;
      }
      input:checked + .slider {
        background: #0d9488;
      }
      input:checked + .slider:before {
        transform: translateX(18px);
      }
    `,
  ],
})
export class ProfilComponent {
  authService = inject(AuthService);

  profile = {
    nom: '',
    prenom: '',
    specialite: 'anesthesiste',
    telephone: '',
  };

  preferences = {
    emailNotif: true,
    rappels: true,
    langue: 'fr',
  };

  getInitials(): string {
    const email = this.authService.currentUser()?.email || 'U';
    return email.charAt(0).toUpperCase();
  }
}
