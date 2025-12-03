import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-splash-screen',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div
      class="fixed inset-0 bg-gray-50 dark:bg-gray-900 flex flex-col items-center justify-center z-50 transition-colors duration-500"
    >
      <div
        class="absolute inset-0 opacity-10 bg-[radial-gradient(ellipse_at_top,_var(--tw-color-indigo-400),_var(--tw-color-purple-600))]"
      ></div>

      <div class="relative flex flex-col items-center justify-center">
        <div class="mb-6 p-4 rounded-xl shadow-2xl bg-white/20 backdrop-blur-sm">
          <svg
            class="h-12 w-12 text-indigo-600 dark:text-indigo-400"
            fill="none"
            viewBox="0 0 24 24"
            stroke="currentColor"
          >
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              stroke-width="2"
              d="M4 6a2 2 0 012-2h2a2 2 0 012 2v2a2 2 0 01-2 2H6a2 2 0 01-2-2V6zM14 6a2 2 0 012-2h2a2 2 0 012 2v2a2 2 0 01-2 2h-2a2 2 0 01-2-2V6zM4 16a2 2 0 012-2h2a2 2 0 012 2v2a2 2 0 01-2 2H6a2 2 0 01-2-2v-2zM14 16a2 2 0 012-2h2a2 2 0 012 2v2a2 2 0 01-2 2h-2a2 2 0 01-2-2v-2z"
            />
          </svg>
        </div>

        <div class="relative w-16 h-16 mb-6">
          <div
            class="absolute inset-0 rounded-full border-4 border-gray-300 dark:border-gray-700 opacity-50"
          ></div>
          <div
            class="absolute inset-0 rounded-full border-4 border-t-indigo-600 dark:border-t-indigo-400 border-b-purple-500 dark:border-b-purple-500 animate-spin"
          ></div>
        </div>

        <h1
          class="text-3xl font-extrabold text-gray-800 dark:text-gray-100 tracking-wider transition-colors duration-500"
        >
          Template
        </h1>
        <p
          class="text-sm text-gray-600 dark:text-gray-400 mt-2 animate-pulse transition-colors duration-500"
        >
          Preparing your experience...
        </p>
      </div>
    </div>
  `,
  styles: [
    // Optional custom styles for smoother spinner if needed, but Tailwind classes handle most of it.
  ],
})
export class SplashScreenComponent {}
