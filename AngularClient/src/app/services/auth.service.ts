import { Injectable, inject, signal, PLATFORM_ID } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { Router } from '@angular/router';
import { isPlatformBrowser } from '@angular/common';

export interface LoginDto {
  email: string;
  password: string;
}

export interface AuthResponse {
  id: string;
  email: string;
  roles: string[];
  token: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private http = inject(HttpClient);
  private router = inject(Router);
  private platformId = inject(PLATFORM_ID);
  private apiUrl = 'http://localhost:5022/api/auth'; // Adjust port if needed
  
  // Signal to track user state
  currentUser = signal<AuthResponse | null>(null);
  initialized = signal(false);

  constructor() {
    this.initializeAuth();
  }

  private initializeAuth() {
    // Simulate a small delay to show splash screen (optional, but good for UX)
    setTimeout(() => {
      const user = this.getUserFromStorage();
      this.currentUser.set(user);
      this.initialized.set(true);
    }, 1000);
  }

  login(credentials: LoginDto): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(`${this.apiUrl}/login`, credentials).pipe(
      tap(response => {
        this.saveToken(response);
      })
    );
  }

  logout() {
    if (isPlatformBrowser(this.platformId)) {
      localStorage.removeItem('user_auth');
    }
    this.currentUser.set(null);
    this.router.navigate(['/login']);
  }

  private saveToken(response: AuthResponse) {
    if (isPlatformBrowser(this.platformId)) {
      localStorage.setItem('user_auth', JSON.stringify(response));
    }
    this.currentUser.set(response);
  }

  private getUserFromStorage(): AuthResponse | null {
    if (isPlatformBrowser(this.platformId)) {
      const stored = localStorage.getItem('user_auth');
      if (stored) {
        try {
          const user = JSON.parse(stored);
          if (this.isTokenExpired(user.token)) {
            localStorage.removeItem('user_auth');
            return null;
          }
          return user;
        } catch (e) {
          console.error('Error parsing stored user auth:', e);
          localStorage.removeItem('user_auth');
          return null;
        }
      }
    }
    return null;
  }

  private isTokenExpired(token: string): boolean {
    try {
      const payload = JSON.parse(atob(token.split('.')[1]));
      const expiry = payload.exp;
      return (Math.floor((new Date).getTime() / 1000)) >= expiry;
    } catch {
      return true;
    }
  }

  isAuthenticated(): boolean {
    return !!this.currentUser();
  }
}
