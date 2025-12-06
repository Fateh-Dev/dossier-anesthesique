import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-splash-screen',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div
      class="fixed inset-0 bg-[#0f172a] flex flex-col items-center justify-center z-[9999] transition-colors duration-500 overflow-hidden"
    >
      <!-- Background Abstract Shapes (Subtle Glows) -->
      <div class="absolute inset-0 overflow-hidden pointer-events-none">
        <div
          class="absolute top-0 left-1/4 w-[500px] h-[500px] bg-teal-500/5 rounded-full blur-[100px] animate-pulse-slow"
        ></div>
        <div
          class="absolute bottom-0 right-1/4 w-[400px] h-[400px] bg-cyan-600/5 rounded-full blur-[100px] animate-pulse-slow"
          style="animation-delay: 2s"
        ></div>
      </div>

      <div class="relative flex flex-col items-center z-10">
        <!-- Logo Container -->
        <div class="relative mb-10 group">
          <!-- Outer Glow Ring -->
          <div
            class="absolute -inset-1 bg-gradient-to-r from-teal-500 to-cyan-500 rounded-full blur opacity-20 group-hover:opacity-40 transition duration-1000"
          ></div>

          <div
            class="relative bg-slate-900 p-6 rounded-full ring-1 ring-white/10 shadow-2xl flex items-center justify-center w-24 h-24"
          >
            <!-- EKG / Heartbeat Icon with Heartbeat Animation -->
            <svg
              xmlns="http://www.w3.org/2000/svg"
              class="w-12 h-12 text-teal-400 animate-heartbeat"
              viewBox="0 0 24 24"
              fill="none"
              stroke="currentColor"
              stroke-width="1.5"
              stroke-linecap="round"
              stroke-linejoin="round"
            >
              <path d="M22 12h-4l-3 9L9 3l-3 9H2" />
            </svg>

            <!-- Pulse animation overlay (Ping) -->
            <div class="absolute inset-0 flex items-center justify-center">
              <svg
                class="w-12 h-12 text-teal-200 opacity-0 animate-heartbeat-ping"
                viewBox="0 0 24 24"
                fill="none"
                stroke="currentColor"
                stroke-width="1.5"
              >
                <path d="M22 12h-4l-3 9L9 3l-3 9H2" />
              </svg>
            </div>
          </div>
        </div>

        <!-- App Name -->
        <div class="text-center space-y-2">
          <h1 class="text-4xl md:text-5xl font-bold text-white tracking-tight drop-shadow-lg">
            Anestia
          </h1>
          <div
            class="flex items-center justify-center gap-2 text-slate-400 text-xs font-mono tracking-[0.2em] uppercase"
          >
            <span class="w-2 h-2 bg-teal-500 rounded-full animate-pulse"></span>
            Chargement Système
            <span class="w-2 h-2 bg-teal-500 rounded-full animate-pulse"></span>
          </div>
        </div>

        <!-- Loading Bar -->
        <div class="mt-12 w-48 h-1 bg-slate-800 rounded-full overflow-hidden">
          <div
            class="h-full bg-gradient-to-r from-teal-500 to-cyan-400 animate-loading-bar rounded-full"
          ></div>
        </div>
      </div>

      <!-- Footer/Version Info -->
      <div class="absolute bottom-8 text-[10px] text-slate-500 font-mono tracking-wider">
        SECURE CONNECTION &bull; V1.0.0
      </div>
    </div>
  `,
  styles: [
    `
      @keyframes heartbeat {
        0%,
        100% {
          transform: scale(1);
        }
        50% {
          transform: scale(1.1);
        }
      }
      .animate-heartbeat {
        animation: heartbeat 2s ease-in-out infinite;
      }

      @keyframes heartbeat-ping {
        0% {
          transform: scale(1);
          opacity: 0;
        }
        20% {
          opacity: 0.5;
        }
        40% {
          transform: scale(1.4);
          opacity: 0;
        }
        100% {
          opacity: 0;
        }
      }
      .animate-heartbeat-ping {
        animation: heartbeat-ping 2s cubic-bezier(0, 0, 0.2, 1) infinite;
      }

      @keyframes loading-bar {
        0% {
          width: 0%;
          margin-left: 0;
        }
        50% {
          width: 100%;
          margin-left: 0;
        }
        100% {
          width: 0%;
          margin-left: 100%;
        }
      }
      .animate-loading-bar {
        animation: loading-bar 2s ease-in-out infinite;
      }

      @keyframes pulse-slow {
        0%,
        100% {
          opacity: 0.05;
          transform: scale(1);
        }
        50% {
          opacity: 0.1;
          transform: scale(1.1);
        }
      }
      .animate-pulse-slow {
        animation: pulse-slow 4s ease-in-out infinite;
      }
    `,
  ],
})
export class SplashScreenComponent {}
