import { ChangeDetectionStrategy, Component, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../services/auth.service';
import { ThemeService } from '../../services/theme.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="app-container" [class.dark]="themeService.isDarkMode()">
      <!-- Sidebar -->
      <aside class="sidebar" [class.collapsed]="!sidebarOpen()">
        <div class="sidebar-header">
          <div class="logo">
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor">
              <path
                d="M11.645 20.91l-.007-.003-.022-.012a15.247 15.247 0 01-.383-.218 25.18 25.18 0 01-4.244-3.17C4.688 15.36 2.25 12.174 2.25 8.25 2.25 5.322 4.714 3 7.688 3A5.5 5.5 0 0112 5.052 5.5 5.5 0 0116.313 3c2.973 0 5.437 2.322 5.437 5.25 0 3.925-2.438 7.111-4.739 9.256a25.175 25.175 0 01-4.244 3.17 15.247 15.247 0 01-.383.219l-.022.012-.007.004-.003.001a.752.752 0 01-.704 0l-.003-.001z"
              />
            </svg>
          </div>
          <span class="logo-text" *ngIf="sidebarOpen()">Anesthésie</span>
        </div>

        <nav class="sidebar-nav">
          <a class="nav-item active">
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
                d="M2.25 12l8.954-8.955c.44-.439 1.152-.439 1.591 0L21.75 12M4.5 9.75v10.125c0 .621.504 1.125 1.125 1.125H9.75v-4.875c0-.621.504-1.125 1.125-1.125h2.25c.621 0 1.125.504 1.125 1.125V21h4.125c.621 0 1.125-.504 1.125-1.125V9.75M8.25 21h8.25"
              />
            </svg>
            <span *ngIf="sidebarOpen()">Accueil</span>
          </a>
          <a class="nav-item">
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
            <span *ngIf="sidebarOpen()">Patients</span>
          </a>
          <a class="nav-item">
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
            <span *ngIf="sidebarOpen()">Interventions</span>
          </a>
          <a class="nav-item">
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
            <span *ngIf="sidebarOpen()">Dossiers</span>
          </a>
          <a class="nav-item">
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
                d="M3 13.125C3 12.504 3.504 12 4.125 12h2.25c.621 0 1.125.504 1.125 1.125v6.75C7.5 20.496 6.996 21 6.375 21h-2.25A1.125 1.125 0 013 19.875v-6.75zM9.75 8.625c0-.621.504-1.125 1.125-1.125h2.25c.621 0 1.125.504 1.125 1.125v11.25c0 .621-.504 1.125-1.125 1.125h-2.25a1.125 1.125 0 01-1.125-1.125V8.625zM16.5 4.125c0-.621.504-1.125 1.125-1.125h2.25C20.496 3 21 3.504 21 4.125v15.75c0 .621-.504 1.125-1.125 1.125h-2.25a1.125 1.125 0 01-1.125-1.125V4.125z"
              />
            </svg>
            <span *ngIf="sidebarOpen()">Statistiques</span>
          </a>
          <a class="nav-item">
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
                d="M9.594 3.94c.09-.542.56-.94 1.11-.94h2.593c.55 0 1.02.398 1.11.94l.213 1.281c.063.374.313.686.645.87.074.04.147.083.22.127.324.196.72.257 1.075.124l1.217-.456a1.125 1.125 0 011.37.49l1.296 2.247a1.125 1.125 0 01-.26 1.431l-1.003.827c-.293.24-.438.613-.431.992a6.759 6.759 0 010 .255c-.007.378.138.75.43.99l1.005.828c.424.35.534.954.26 1.43l-1.298 2.247a1.125 1.125 0 01-1.369.491l-1.217-.456c-.355-.133-.75-.072-1.076.124a6.57 6.57 0 01-.22.128c-.331.183-.581.495-.644.869l-.213 1.28c-.09.543-.56.941-1.11.941h-2.594c-.55 0-1.02-.398-1.11-.94l-.213-1.281c-.062-.374-.312-.686-.644-.87a6.52 6.52 0 01-.22-.127c-.325-.196-.72-.257-1.076-.124l-1.217.456a1.125 1.125 0 01-1.369-.49l-1.297-2.247a1.125 1.125 0 01.26-1.431l1.004-.827c.292-.24.437-.613.43-.992a6.932 6.932 0 010-.255c.007-.378-.138-.75-.43-.99l-1.004-.828a1.125 1.125 0 01-.26-1.43l1.297-2.247a1.125 1.125 0 011.37-.491l1.216.456c.356.133.751.072 1.076-.124.072-.044.146-.087.22-.128.332-.183.582-.495.644-.869l.214-1.281z"
              />
              <path
                stroke-linecap="round"
                stroke-linejoin="round"
                d="M15 12a3 3 0 11-6 0 3 3 0 016 0z"
              />
            </svg>
            <span *ngIf="sidebarOpen()">Paramètres</span>
          </a>
        </nav>

        <button class="collapse-btn" (click)="toggleSidebar()">
          <svg
            *ngIf="sidebarOpen()"
            xmlns="http://www.w3.org/2000/svg"
            fill="none"
            viewBox="0 0 24 24"
            stroke-width="1.5"
            stroke="currentColor"
          >
            <path stroke-linecap="round" stroke-linejoin="round" d="M15.75 19.5L8.25 12l7.5-7.5" />
          </svg>
          <svg
            *ngIf="!sidebarOpen()"
            xmlns="http://www.w3.org/2000/svg"
            fill="none"
            viewBox="0 0 24 24"
            stroke-width="1.5"
            stroke="currentColor"
          >
            <path stroke-linecap="round" stroke-linejoin="round" d="M8.25 4.5l7.5 7.5-7.5 7.5" />
          </svg>
        </button>
      </aside>

      <!-- Main Content -->
      <div class="main-wrapper">
        <!-- Header -->
        <header class="header">
          <div class="header-left">
            <button class="mobile-menu-btn" (click)="toggleSidebar()">
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
                  d="M3.75 6.75h16.5M3.75 12h16.5m-16.5 5.25h16.5"
                />
              </svg>
            </button>
            <h1 class="page-title">Tableau de bord</h1>
          </div>
          <div class="header-right">
            <button class="theme-btn" (click)="themeService.toggleTheme()">
              <svg
                *ngIf="themeService.isDarkMode()"
                xmlns="http://www.w3.org/2000/svg"
                fill="none"
                viewBox="0 0 24 24"
                stroke-width="1.5"
                stroke="currentColor"
              >
                <path
                  stroke-linecap="round"
                  stroke-linejoin="round"
                  d="M12 3v2.25m6.364.386l-1.591 1.591M21 12h-2.25m-.386 6.364l-1.591-1.591M12 18.75V21m-4.773-4.227l-1.591 1.591M5.25 12H3m4.227-4.773L5.636 5.636M15.75 12a3.75 3.75 0 11-7.5 0 3.75 3.75 0 017.5 0z"
                />
              </svg>
              <svg
                *ngIf="!themeService.isDarkMode()"
                xmlns="http://www.w3.org/2000/svg"
                fill="none"
                viewBox="0 0 24 24"
                stroke-width="1.5"
                stroke="currentColor"
              >
                <path
                  stroke-linecap="round"
                  stroke-linejoin="round"
                  d="M21.752 15.002A9.718 9.718 0 0118 15.75c-5.385 0-9.75-4.365-9.75-9.75 0-1.33.266-2.597.748-3.752A9.753 9.753 0 003 11.25C3 16.635 7.365 21 12.75 21a9.753 9.753 0 009.002-5.998z"
                />
              </svg>
            </button>
            <div class="user-info">
              <span class="user-email">{{
                authService.currentUser()?.email || 'Utilisateur'
              }}</span>
            </div>
            <button class="logout-btn" (click)="logout()">
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
                  d="M15.75 9V5.25A2.25 2.25 0 0013.5 3h-6a2.25 2.25 0 00-2.25 2.25v13.5A2.25 2.25 0 007.5 21h6a2.25 2.25 0 002.25-2.25V15m3 0l3-3m0 0l-3-3m3 3H9"
                />
              </svg>
              <span>Déconnexion</span>
            </button>
          </div>
        </header>

        <!-- Content -->
        <main class="content">
          <!-- Stats Row -->
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
                    d="M6.75 3v2.25M17.25 3v2.25M3 18.75V7.5a2.25 2.25 0 012.25-2.25h13.5A2.25 2.25 0 0121 7.5v11.25m-18 0A2.25 2.25 0 005.25 21h13.5A2.25 2.25 0 0021 18.75m-18 0v-7.5A2.25 2.25 0 015.25 9h13.5A2.25 2.25 0 0121 11.25v7.5m-9-6h.008v.008H12v-.008zM12 15h.008v.008H12V15zm0 2.25h.008v.008H12v-.008zM9.75 15h.008v.008H9.75V15zm0 2.25h.008v.008H9.75v-.008zM7.5 15h.008v.008H7.5V15zm0 2.25h.008v.008H7.5v-.008zm6.75-4.5h.008v.008h-.008v-.008zm0 2.25h.008v.008h-.008V15zm0 2.25h.008v.008h-.008v-.008zm2.25-4.5h.008v.008H16.5v-.008zm0 2.25h.008v.008H16.5V15z"
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

          <!-- Quick Actions & Recent -->
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
                    <path
                      stroke-linecap="round"
                      stroke-linejoin="round"
                      d="M12 4.5v15m7.5-7.5h-15"
                    />
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
                    <path
                      stroke-linecap="round"
                      stroke-linejoin="round"
                      d="M12 4.5v15m7.5-7.5h-15"
                    />
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
        </main>
      </div>
    </div>
  `,
  styles: [
    `
      :host {
        display: block;
        height: 100vh;
      }

      .app-container {
        display: flex;
        height: 100%;
        background: #f1f5f9;
        font-family: 'Inter', -apple-system, sans-serif;
      }

      .app-container.dark {
        background: #0f172a;
      }

      /* Sidebar */
      .sidebar {
        width: 200px;
        background: white;
        border-right: 1px solid #e2e8f0;
        display: flex;
        flex-direction: column;
        transition: width 0.2s ease;
      }

      .dark .sidebar {
        background: #1e293b;
        border-color: #334155;
      }

      .sidebar.collapsed {
        width: 56px;
      }

      .sidebar-header {
        display: flex;
        align-items: center;
        gap: 8px;
        padding: 10px;
        border-bottom: 1px solid #e2e8f0;
      }

      .dark .sidebar-header {
        border-color: #334155;
      }

      .logo {
        width: 36px;
        height: 36px;
        background: linear-gradient(135deg, #0d9488, #065f46);
        border-radius: 8px;
        display: flex;
        align-items: center;
        justify-content: center;
        flex-shrink: 0;
      }

      .logo svg {
        width: 20px;
        height: 20px;
        color: white;
      }

      .logo-text {
        font-size: 14px;
        font-weight: 600;
        color: #0d9488;
        white-space: nowrap;
      }

      .sidebar-nav {
        flex: 1;
        padding: 8px;
        display: flex;
        flex-direction: column;
        gap: 2px;
      }

      .nav-item {
        display: flex;
        align-items: center;
        gap: 10px;
        padding: 8px 10px;
        border-radius: 6px;
        color: #64748b;
        font-size: 13px;
        cursor: pointer;
        transition: all 0.15s ease;
        text-decoration: none;
      }

      .nav-item:hover {
        background: #f1f5f9;
        color: #0f172a;
      }

      .dark .nav-item:hover {
        background: #334155;
        color: #f1f5f9;
      }

      .nav-item.active {
        background: #0d9488;
        color: white;
      }

      .nav-item svg {
        width: 18px;
        height: 18px;
        flex-shrink: 0;
      }

      .collapse-btn {
        margin: 8px;
        padding: 6px;
        border: none;
        background: #f1f5f9;
        border-radius: 6px;
        cursor: pointer;
        display: flex;
        align-items: center;
        justify-content: center;
      }

      .dark .collapse-btn {
        background: #334155;
      }
      .collapse-btn svg {
        width: 16px;
        height: 16px;
        color: #64748b;
      }

      /* Main */
      .main-wrapper {
        flex: 1;
        display: flex;
        flex-direction: column;
        overflow: hidden;
      }

      .header {
        height: 48px;
        background: white;
        border-bottom: 1px solid #e2e8f0;
        display: flex;
        align-items: center;
        justify-content: space-between;
        padding: 0 12px;
      }

      .dark .header {
        background: #1e293b;
        border-color: #334155;
      }

      .header-left {
        display: flex;
        align-items: center;
        gap: 10px;
      }

      .mobile-menu-btn {
        display: none;
        padding: 6px;
        border: none;
        background: transparent;
        cursor: pointer;
      }

      .mobile-menu-btn svg {
        width: 20px;
        height: 20px;
        color: #64748b;
      }

      .page-title {
        font-size: 15px;
        font-weight: 600;
        color: #0f172a;
      }

      .dark .page-title {
        color: #f1f5f9;
      }

      .header-right {
        display: flex;
        align-items: center;
        gap: 8px;
      }

      .theme-btn {
        padding: 6px;
        border: none;
        background: #f1f5f9;
        border-radius: 6px;
        cursor: pointer;
      }

      .dark .theme-btn {
        background: #334155;
      }
      .theme-btn svg {
        width: 16px;
        height: 16px;
        color: #64748b;
      }

      .user-info {
        display: none;
      }

      @media (min-width: 640px) {
        .user-info {
          display: block;
        }
      }

      .user-email {
        font-size: 12px;
        color: #64748b;
      }

      .logout-btn {
        display: flex;
        align-items: center;
        gap: 4px;
        padding: 6px 10px;
        border: none;
        background: #ef4444;
        color: white;
        border-radius: 6px;
        font-size: 12px;
        font-weight: 500;
        cursor: pointer;
      }

      .logout-btn svg {
        width: 14px;
        height: 14px;
      }
      .logout-btn span {
        display: none;
      }

      @media (min-width: 640px) {
        .logout-btn span {
          display: inline;
        }
      }

      /* Content */
      .content {
        flex: 1;
        overflow-y: auto;
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
        background: white;
        border-radius: 8px;
        padding: 12px;
        display: flex;
        align-items: center;
        gap: 10px;
        box-shadow: 0 1px 2px rgba(0, 0, 0, 0.05);
      }

      .dark .stat-card {
        background: #1e293b;
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
        color: #0f172a;
      }

      .dark .stat-value {
        color: #f1f5f9;
      }

      .stat-label {
        font-size: 11px;
        color: #64748b;
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
        background: white;
        border-radius: 8px;
        padding: 12px;
        box-shadow: 0 1px 2px rgba(0, 0, 0, 0.05);
      }

      .dark .card {
        background: #1e293b;
      }

      .card-title {
        font-size: 13px;
        font-weight: 600;
        color: #0f172a;
        margin-bottom: 10px;
      }

      .dark .card-title {
        color: #f1f5f9;
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
        border: 1px solid #e2e8f0;
        background: white;
        border-radius: 6px;
        font-size: 12px;
        color: #374151;
        cursor: pointer;
        transition: all 0.15s ease;
      }

      .dark .action-btn {
        background: #334155;
        border-color: #475569;
        color: #e2e8f0;
      }

      .action-btn:hover {
        border-color: #0d9488;
        color: #0d9488;
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
        background: #f8fafc;
        border-radius: 6px;
      }

      .dark .list-item {
        background: #334155;
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
        color: #0f172a;
      }

      .dark .item-name {
        color: #f1f5f9;
      }

      .item-detail {
        font-size: 11px;
        color: #64748b;
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

      @media (max-width: 768px) {
        .sidebar {
          position: fixed;
          left: 0;
          top: 0;
          bottom: 0;
          z-index: 50;
          transform: translateX(-100%);
        }
        .sidebar:not(.collapsed) {
          transform: translateX(0);
        }
        .mobile-menu-btn {
          display: flex;
        }
      }
    `,
  ],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class HomeComponent {
  sidebarOpen = signal(true);
  authService = inject(AuthService);
  themeService = inject(ThemeService);

  toggleSidebar() {
    this.sidebarOpen.update((v) => !v);
  }

  logout() {
    this.authService.logout();
  }
}
