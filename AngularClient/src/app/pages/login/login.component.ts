import { Component, inject, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  template: `
    <div class="login-container">
      <div class="branding-panel">
        <div class="branding-content">
          <div class="logo-icon">
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor">
              <path
                d="M11.645 20.91l-.007-.003-.022-.012a15.247 15.247 0 01-.383-.218 25.18 25.18 0 01-4.244-3.17C4.688 15.36 2.25 12.174 2.25 8.25 2.25 5.322 4.714 3 7.688 3A5.5 5.5 0 0112 5.052 5.5 5.5 0 0116.313 3c2.973 0 5.437 2.322 5.437 5.25 0 3.925-2.438 7.111-4.739 9.256a25.175 25.175 0 01-4.244 3.17 15.247 15.247 0 01-.383.219l-.022.012-.007.004-.003.001a.752.752 0 01-.704 0l-.003-.001z"
              />
            </svg>
          </div>
          <h1 class="app-title">Anestia</h1>
          <p class="app-subtitle">Système de Gestion des Dossiers Médicaux</p>

          <div class="features-list">
            <div class="feature-item">
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
                  d="M9 12.75L11.25 15 15 9.75m-3-7.036A11.959 11.959 0 013.598 6 11.99 11.99 0 003 9.749c0 5.592 3.824 10.29 9 11.623 5.176-1.332 9-6.03 9-11.622 0-1.31-.21-2.571-.598-3.751h-.152c-3.196 0-6.1-1.248-8.25-3.285z"
                />
              </svg>
              <span>Sécurité des données patients</span>
            </div>
            <div class="feature-item">
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
              <span>Suivi des interventions</span>
            </div>
            <div class="feature-item">
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
              <span>Statistiques en temps réel</span>
            </div>
          </div>
        </div>

        <div class="branding-footer">
          <p>&copy; 2024 Hôpital Militaire - Service d'Anesthésie</p>
        </div>
      </div>

      <!-- Right Panel - Login Form -->
      <div class="form-panel">
        <div class="form-container">
          <div class="form-header">
            <div class="medical-icon">
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
                  d="M15.75 6a3.75 3.75 0 11-7.5 0 3.75 3.75 0 017.5 0zM4.501 20.118a7.5 7.5 0 0114.998 0A17.933 17.933 0 0112 21.75c-2.676 0-5.216-.584-7.499-1.632z"
                />
              </svg>
            </div>
            <h2>Connexion</h2>
            <p>Accédez à votre espace sécurisé</p>
          </div>

          <form class="login-form" [formGroup]="loginForm" (ngSubmit)="onSubmit()">
            <div class="form-group">
              <label for="email">Adresse e-mail</label>
              <div class="input-wrapper">
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
                    d="M21.75 6.75v10.5a2.25 2.25 0 01-2.25 2.25h-15a2.25 2.25 0 01-2.25-2.25V6.75m19.5 0A2.25 2.25 0 0019.5 4.5h-15a2.25 2.25 0 00-2.25 2.25m19.5 0v.243a2.25 2.25 0 01-1.07 1.916l-7.5 4.615a2.25 2.25 0 01-2.36 0L3.32 8.91a2.25 2.25 0 01-1.07-1.916V6.75"
                  />
                </svg>
                <input
                  id="email"
                  type="email"
                  placeholder="exemple@hopital.dz"
                  formControlName="email"
                  [class.error]="loginForm.get('email')?.touched && loginForm.get('email')?.invalid"
                />
              </div>
              <span
                class="error-message"
                *ngIf="loginForm.get('email')?.touched && loginForm.get('email')?.invalid"
              >
                Veuillez entrer une adresse e-mail valide
              </span>
            </div>

            <div class="form-group">
              <label for="password">Mot de passe</label>
              <div class="input-wrapper">
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
                    d="M16.5 10.5V6.75a4.5 4.5 0 10-9 0v3.75m-.75 11.25h10.5a2.25 2.25 0 002.25-2.25v-6.75a2.25 2.25 0 00-2.25-2.25H6.75a2.25 2.25 0 00-2.25 2.25v6.75a2.25 2.25 0 002.25 2.25z"
                  />
                </svg>
                <input
                  id="password"
                  type="password"
                  placeholder="••••••••"
                  formControlName="password"
                  [class.error]="
                    loginForm.get('password')?.touched && loginForm.get('password')?.invalid
                  "
                />
              </div>
              <span
                class="error-message"
                *ngIf="loginForm.get('password')?.touched && loginForm.get('password')?.invalid"
              >
                Le mot de passe est requis
              </span>
            </div>

            <div class="form-options">
              <label class="checkbox-wrapper">
                <input type="checkbox" id="remember" />
                <span class="checkmark"></span>
                Se souvenir de moi
              </label>
              <a href="#" class="forgot-link">Mot de passe oublié ?</a>
            </div>

            <button
              type="submit"
              class="submit-btn"
              [disabled]="loginForm.invalid || isLoading()"
              [class.loading]="isLoading()"
            >
              <svg
                *ngIf="!isLoading()"
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
              <span *ngIf="!isLoading()">Connexion</span>
              <span *ngIf="isLoading()" class="loader"></span>
            </button>

            <div class="error-alert" *ngIf="errorMessage()">
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
                  d="M12 9v3.75m-9.303 3.376c-.866 1.5.217 3.374 1.948 3.374h14.71c1.73 0 2.813-1.874 1.948-3.374L13.949 3.378c-.866-1.5-3.032-1.5-3.898 0L2.697 16.126zM12 15.75h.007v.008H12v-.008z"
                />
              </svg>
              {{ errorMessage() }}
            </div>
          </form>

          <div class="form-footer">
            <p>Besoin d'aide ? Contactez le support technique</p>
          </div>
        </div>
      </div>
    </div>
  `,
  styles: [
    `
      .login-container {
        display: flex;
        min-height: 100vh;
        background: #f8fafc;
      }

      .branding-panel {
        flex: 1;
        background: linear-gradient(135deg, #0d9488 0%, #065f46 50%, #064e3b 100%);
        display: flex;
        flex-direction: column;
        justify-content: center;
        padding: 3rem;
        position: relative;
        overflow: hidden;
      }

      .branding-panel::before {
        content: '';
        position: absolute;
        top: -50%;
        right: -50%;
        width: 100%;
        height: 100%;
        background: radial-gradient(circle, rgba(255, 255, 255, 0.1) 0%, transparent 70%);
        pointer-events: none;
      }

      .branding-content {
        position: relative;
        z-index: 1;
        color: white;
        max-width: 480px;
        margin: 0 auto;
      }

      .logo-icon {
        width: 80px;
        height: 80px;
        background: rgba(255, 255, 255, 0.15);
        border-radius: 20px;
        display: flex;
        align-items: center;
        justify-content: center;
        margin-bottom: 2rem;
      }

      .logo-icon svg {
        width: 48px;
        height: 48px;
        color: white;
      }

      .app-title {
        font-size: 2.5rem;
        font-weight: 700;
        margin-bottom: 0.5rem;
      }

      .app-subtitle {
        font-size: 1.1rem;
        opacity: 0.9;
        margin-bottom: 3rem;
      }

      .features-list {
        display: flex;
        flex-direction: column;
        gap: 1.25rem;
      }

      .feature-item {
        display: flex;
        align-items: center;
        gap: 1rem;
        padding: 1rem;
        background: rgba(255, 255, 255, 0.1);
        border-radius: 12px;
        transition: all 0.3s ease;
      }

      .feature-item:hover {
        background: rgba(255, 255, 255, 0.15);
        transform: translateX(5px);
      }

      .feature-item svg {
        width: 24px;
        height: 24px;
        flex-shrink: 0;
      }

      .branding-footer {
        position: absolute;
        bottom: 2rem;
        left: 3rem;
        right: 3rem;
        color: rgba(255, 255, 255, 0.6);
        font-size: 0.875rem;
      }

      .form-panel {
        flex: 1;
        display: flex;
        align-items: center;
        justify-content: center;
        padding: 2rem;
      }

      .form-container {
        width: 100%;
        max-width: 420px;
      }

      .form-header {
        text-align: center;
        margin-bottom: 2.5rem;
      }

      .medical-icon {
        width: 64px;
        height: 64px;
        background: linear-gradient(135deg, #0d9488, #065f46);
        border-radius: 16px;
        display: flex;
        align-items: center;
        justify-content: center;
        margin: 0 auto 1.5rem;
        box-shadow: 0 10px 40px rgba(13, 148, 136, 0.3);
      }

      .medical-icon svg {
        width: 32px;
        height: 32px;
        color: white;
      }

      .form-header h2 {
        font-size: 1.75rem;
        font-weight: 700;
        color: #1e293b;
        margin-bottom: 0.5rem;
      }

      .form-header p {
        color: #64748b;
      }

      .login-form {
        display: flex;
        flex-direction: column;
        gap: 1.5rem;
      }

      .form-group {
        display: flex;
        flex-direction: column;
        gap: 0.5rem;
      }

      .form-group label {
        font-size: 0.875rem;
        font-weight: 600;
        color: #374151;
      }

      .input-wrapper {
        position: relative;
        display: flex;
        align-items: center;
      }

      .input-wrapper svg {
        position: absolute;
        left: 1rem;
        width: 20px;
        height: 20px;
        color: #9ca3af;
        pointer-events: none;
      }

      .input-wrapper input {
        width: 100%;
        padding: 0.875rem 1rem 0.875rem 3rem;
        border: 2px solid #e5e7eb;
        border-radius: 12px;
        font-size: 1rem;
        transition: all 0.2s ease;
        background: white;
      }

      .input-wrapper input:focus {
        outline: none;
        border-color: #0d9488;
        box-shadow: 0 0 0 4px rgba(13, 148, 136, 0.1);
      }

      .input-wrapper input.error {
        border-color: #ef4444;
      }

      .error-message {
        font-size: 0.8rem;
        color: #ef4444;
      }

      .form-options {
        display: flex;
        justify-content: space-between;
        align-items: center;
        font-size: 0.875rem;
      }

      .checkbox-wrapper {
        display: flex;
        align-items: center;
        gap: 0.5rem;
        cursor: pointer;
        color: #64748b;
      }

      .checkbox-wrapper input[type='checkbox'] {
        width: 18px;
        height: 18px;
        accent-color: #0d9488;
      }

      .forgot-link {
        color: #0d9488;
        text-decoration: none;
        font-weight: 500;
      }

      .forgot-link:hover {
        color: #065f46;
      }

      .submit-btn {
        display: flex;
        align-items: center;
        justify-content: center;
        gap: 0.75rem;
        padding: 1rem 1.5rem;
        background: linear-gradient(135deg, #0d9488, #065f46);
        color: white;
        border: none;
        border-radius: 12px;
        font-size: 1rem;
        font-weight: 600;
        cursor: pointer;
        transition: all 0.3s ease;
        box-shadow: 0 4px 20px rgba(13, 148, 136, 0.3);
      }

      .submit-btn:hover:not(:disabled) {
        transform: translateY(-2px);
        box-shadow: 0 6px 25px rgba(13, 148, 136, 0.4);
      }

      .submit-btn:disabled {
        opacity: 0.6;
        cursor: not-allowed;
      }

      .submit-btn svg {
        width: 20px;
        height: 20px;
      }

      .loader {
        width: 20px;
        height: 20px;
        border: 2px solid rgba(255, 255, 255, 0.3);
        border-top-color: white;
        border-radius: 50%;
        animation: spin 0.8s linear infinite;
      }

      @keyframes spin {
        to {
          transform: rotate(360deg);
        }
      }

      .error-alert {
        display: flex;
        align-items: center;
        gap: 0.75rem;
        padding: 1rem;
        background: #fef2f2;
        border: 1px solid #fecaca;
        border-radius: 12px;
        color: #dc2626;
        font-size: 0.875rem;
      }

      .error-alert svg {
        width: 20px;
        height: 20px;
        flex-shrink: 0;
      }

      .form-footer {
        text-align: center;
        margin-top: 2rem;
        padding-top: 1.5rem;
        border-top: 1px solid #e5e7eb;
      }

      .form-footer p {
        color: #9ca3af;
        font-size: 0.875rem;
      }

      @media (max-width: 1024px) {
        .branding-panel {
          display: none;
        }
      }
    `,
  ],
})
export class LoginComponent {
  private fb = inject(FormBuilder);
  private authService = inject(AuthService);
  private router = inject(Router);

  constructor() {
    if (this.authService.isAuthenticated()) {
      this.router.navigate(['/']);
    }
  }

  loginForm = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required]],
  });

  isLoading = signal(false);
  errorMessage = signal('');

  onSubmit() {
    if (this.loginForm.valid) {
      this.isLoading.set(true);
      this.errorMessage.set('');

      const { email, password } = this.loginForm.value;

      this.authService.login({ email: email!, password: password! }).subscribe({
        next: () => {
          this.isLoading.set(false);
          this.router.navigate(['/']);
        },
        error: (err) => {
          this.isLoading.set(false);
          this.errorMessage.set('Email ou mot de passe incorrect');
          console.error('Login error:', err);
        },
      });
    } else {
      this.loginForm.markAllAsTouched();
    }
  }
}
