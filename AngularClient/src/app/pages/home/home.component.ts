import { ChangeDetectionStrategy, Component, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../services/auth.service';
import { ThemeService } from '../../services/theme.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div
      class="min-h-screen bg-gray-50 dark:bg-gray-900 flex transition-colors duration-300 antialiased"
    >
      <!-- Sidebar -->
      <aside
        [class.w-60]="sidebarOpen()"
        [class.w-20]="!sidebarOpen()"
        class="flex-shrink-0 bg-white dark:bg-gray-800 text-gray-700 dark:text-gray-200 shadow-xl z-20
               transition-all duration-300 ease-in-out hidden md:flex flex-col border-r border-gray-100 dark:border-gray-700"
      >
        <div class="h-14 flex items-center px-3 border-b border-gray-200 dark:border-gray-700">
          <h1 *ngIf="sidebarOpen()" class="text-xl font-bold text-indigo-600 tracking-tight">
            App Name
          </h1>

          <svg
            *ngIf="!sidebarOpen()"
            class="h-7 w-7 text-indigo-600 mx-auto"
            viewBox="0 0 24 24"
            fill="none"
            stroke="currentColor"
            stroke-width="2"
            stroke-linecap="round"
            stroke-linejoin="round"
          >
            <path d="M12 2l8 4.5v9L12 22l-8-4.5v-9L12 2z" />
          </svg>
        </div>

        <!-- NAVIGATION -->
        <nav class="flex-1 p-3 space-y-1.5">
          <!-- HOME -->
          <a
            class="flex items-center p-2.5 rounded-lg cursor-pointer transition-all duration-200
                    bg-indigo-600 text-white shadow-sm hover:bg-indigo-700"
          >
            <svg
              class="w-5 h-5 flex-shrink-0"
              viewBox="0 0 24 24"
              fill="none"
              stroke="currentColor"
              stroke-width="2"
              stroke-linecap="round"
              stroke-linejoin="round"
            >
              <path d="M3 9l9-7 9 7v11a2 2 0 01-2 2H5a2 2 0 01-2-2V9z" />
              <polyline points="9 22 9 12 15 12 15 22" />
            </svg>

            <span *ngIf="sidebarOpen()" class="ml-3 text-sm font-medium">Home</span>
          </a>

          <!-- REPORTS -->
          <a
            class="flex items-center p-2.5 rounded-lg cursor-pointer hover:bg-gray-100 dark:hover:bg-gray-700 transition-colors duration-200"
          >
            <svg
              class="w-5 h-5 flex-shrink-0"
              viewBox="0 0 24 24"
              fill="none"
              stroke="currentColor"
              stroke-width="2"
            >
              <line x1="12" y1="20" x2="12" y2="10"></line>
              <line x1="18" y1="20" x2="18" y2="4"></line>
              <line x1="6" y1="20" x2="6" y2="16"></line>
            </svg>

            <span *ngIf="sidebarOpen()" class="ml-3 text-sm font-medium">Reports</span>
          </a>

          <!-- SETTINGS -->
          <a
            class="flex items-center p-2.5 rounded-lg cursor-pointer hover:bg-gray-100 dark:hover:bg-gray-700 transition-colors duration-200"
          >
            <svg
              class="w-5 h-5 flex-shrink-0"
              viewBox="0 0 24 24"
              fill="none"
              stroke="currentColor"
              stroke-width="2"
            >
              <path
                d="M12.22 2h-.44a2 2 0 00-2 2v.44a2 2 0 01-2 2h-.44a2 2 0 00-2 2v.44a2 2 0 01-2 2H2v.44a2 2 0 002 2h.44a2 2 0 012 2v.44a2 2 0 002 2h.44a2 2 0 012 2v.44a2 2 0 002 2h.44a2 2 0 012-2h.44a2 2 0 002-2v-.44a2 2 0 012-2h.44a2 2 0 002-2v-.44a2 2 0 01-2-2h-.44a2 2 0 00-2-2v-.44a2 2 0 01-2-2v-.44a2 2 0 00-2-2z"
              />
              <circle cx="12" cy="12" r="2" />
            </svg>

            <span *ngIf="sidebarOpen()" class="ml-3 text-sm font-medium">Settings</span>
          </a>
        </nav>

        <div class="p-3 border-t border-gray-200 dark:border-gray-700 flex justify-end">
          <button
            (click)="toggleSidebar()"
            class="p-2 rounded-full hover:bg-gray-100 dark:hover:bg-gray-700 text-gray-500"
          >
            <svg
              *ngIf="sidebarOpen()"
              class="h-5 w-5"
              viewBox="0 0 24 24"
              fill="none"
              stroke="currentColor"
            >
              <polyline points="15 18 9 12 15 6" />
            </svg>
            <svg
              *ngIf="!sidebarOpen()"
              class="h-5 w-5"
              viewBox="0 0 24 24"
              fill="none"
              stroke="currentColor"
            >
              <polyline points="9 18 15 12 9 6" />
            </svg>
          </button>
        </div>
      </aside>

      <!-- MAIN CONTENT -->
      <div class="flex-1 flex flex-col overflow-hidden">
        <!-- HEADER -->
        <nav
          class="bg-white dark:bg-gray-800 shadow h-12 flex items-center justify-between px-4 border-b border-gray-100 dark:border-gray-700"
        >
          <button
            (click)="toggleMobileSidebar()"
            class="text-gray-500 hover:text-indigo-600 md:hidden"
          >
            <svg class="h-5 w-5" stroke="currentColor" fill="none" viewBox="0 0 24 24">
              <line x1="3" y1="12" x2="21" y2="12" />
              <line x1="3" y1="6" x2="21" y2="6" />
              <line x1="3" y1="18" x2="21" y2="18" />
            </svg>
          </button>

          <div class="flex items-center space-x-3">
            <!-- Dark Mode Toggle -->
            <button
              (click)="themeService.toggleTheme()"
              class="p-2 rounded-lg hover:bg-gray-100 dark:hover:bg-gray-700 text-gray-500 dark:text-gray-400 transition-colors"
              title="Toggle dark mode"
            >
              <!-- Sun Icon (shown in dark mode) -->
              <svg
                *ngIf="themeService.isDarkMode()"
                class="h-5 w-5"
                fill="none"
                viewBox="0 0 24 24"
                stroke="currentColor"
              >
                <path
                  stroke-linecap="round"
                  stroke-linejoin="round"
                  stroke-width="2"
                  d="M12 3v1m0 16v1m9-9h-1M4 12H3m15.364 6.364l-.707-.707M6.343 6.343l-.707-.707m12.728 0l-.707.707M6.343 17.657l-.707.707M16 12a4 4 0 11-8 0 4 4 0 018 0z"
                />
              </svg>
              <!-- Moon Icon (shown in light mode) -->
              <svg
                *ngIf="!themeService.isDarkMode()"
                class="h-5 w-5"
                fill="none"
                viewBox="0 0 24 24"
                stroke="currentColor"
              >
                <path
                  stroke-linecap="round"
                  stroke-linejoin="round"
                  stroke-width="2"
                  d="M20.354 15.354A9 9 0 018.646 3.646 9.003 9.003 0 0012 21a9.003 9.003 0 008.354-5.646z"
                />
              </svg>
            </button>

            <span class="text-gray-700 dark:text-gray-300 text-xs font-medium hidden sm:block">
              Welcome,
              <span class="text-indigo-600">{{ authService.currentUser()?.email || 'Guest' }}</span>
            </span>

            <button
              (click)="logout()"
              class="flex items-center px-3 py-1.5 text-xs font-medium rounded-full bg-red-500 text-white hover:bg-red-600 shadow"
            >
              <svg class="h-4 w-4 mr-1" viewBox="0 0 24 24" fill="none" stroke="currentColor">
                <path d="M9 21H5a2 2 0 01-2-2V5a2 2 0 012-2h4" />
                <polyline points="16 17 21 12 16 7" />
                <line x1="21" y1="12" x2="9" y2="12" />
              </svg>
              Sign out
            </button>
          </div>
        </nav>

        <!-- CONTENT -->
        <main class="flex-1 overflow-y-auto p-6 bg-gray-50 dark:bg-gray-900">
          <h1 class="text-4xl font-bold text-gray-900 dark:text-gray-50 mb-6">Dashboard</h1>
        </main>
      </div>
    </div>
  `,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class HomeComponent {
  sidebarOpen = signal(true);
  authService = inject(AuthService);
  themeService = inject(ThemeService);

  toggleSidebar() {
    this.sidebarOpen.update((v) => !v);
  }

  toggleMobileSidebar() {
    this.sidebarOpen.update((v) => !v);
  }

  logout() {
    this.authService.logout();
  }
}
