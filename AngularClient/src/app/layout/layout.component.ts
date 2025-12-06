import { ChangeDetectionStrategy, Component, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { ThemeService } from '../services/theme.service';

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [CommonModule, RouterOutlet, RouterLink, RouterLinkActive],
  template: `
    <div class="app-container" [class.dark]="themeService.isDarkMode()">
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
          <a
            class="nav-item"
            routerLink="/"
            routerLinkActive="active"
            [routerLinkActiveOptions]="{ exact: true }"
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
                d="M2.25 12l8.954-8.955c.44-.439 1.152-.439 1.591 0L21.75 12M4.5 9.75v10.125c0 .621.504 1.125 1.125 1.125H9.75v-4.875c0-.621.504-1.125 1.125-1.125h2.25c.621 0 1.125.504 1.125 1.125V21h4.125c.621 0 1.125-.504 1.125-1.125V9.75M8.25 21h8.25"
              />
            </svg>
            <span *ngIf="sidebarOpen()">Accueil</span>
          </a>
          <a class="nav-item" routerLink="/patients" routerLinkActive="active">
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
          <a class="nav-item" routerLink="/interventions" routerLinkActive="active">
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
          <a class="nav-item" routerLink="/dossiers" routerLinkActive="active">
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
          <a class="nav-item" routerLink="/statistiques" routerLinkActive="active">
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
          <a class="nav-item" routerLink="/parametres" routerLinkActive="active">
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

      <div class="main-wrapper">
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
            <h1 class="page-title">Dossier Anesthésique</h1>
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
            <a routerLink="/profil" class="user-btn">
              <div class="user-avatar">{{ getInitials() }}</div>
              <span class="user-email">{{
                authService.currentUser()?.email || 'Utilisateur'
              }}</span>
            </a>
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
            </button>
          </div>
        </header>

        <main class="content">
          <router-outlet></router-outlet>
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
      .user-btn {
        display: flex;
        align-items: center;
        gap: 6px;
        padding: 4px 8px;
        border-radius: 6px;
        text-decoration: none;
        transition: background 0.15s;
      }
      .user-btn:hover {
        background: #f1f5f9;
      }
      .dark .user-btn:hover {
        background: #334155;
      }
      .user-avatar {
        width: 28px;
        height: 28px;
        background: #0d9488;
        border-radius: 50%;
        display: flex;
        align-items: center;
        justify-content: center;
        font-size: 11px;
        font-weight: 600;
        color: white;
      }
      .user-email {
        font-size: 12px;
        color: #64748b;
        display: none;
      }
      @media (min-width: 640px) {
        .user-email {
          display: block;
        }
      }
      .logout-btn {
        padding: 6px;
        border: none;
        background: #fee2e2;
        border-radius: 6px;
        cursor: pointer;
      }
      .logout-btn svg {
        width: 16px;
        height: 16px;
        color: #dc2626;
      }
      .content {
        flex: 1;
        overflow-y: auto;
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
          width: 200px;
        }
        .mobile-menu-btn {
          display: flex;
        }
      }
    `,
  ],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class LayoutComponent {
  sidebarOpen = signal(true);
  authService = inject(AuthService);
  themeService = inject(ThemeService);

  toggleSidebar() {
    this.sidebarOpen.update((v) => !v);
  }

  logout() {
    this.authService.logout();
  }

  getInitials(): string {
    const email = this.authService.currentUser()?.email || 'U';
    return email.charAt(0).toUpperCase();
  }
}
