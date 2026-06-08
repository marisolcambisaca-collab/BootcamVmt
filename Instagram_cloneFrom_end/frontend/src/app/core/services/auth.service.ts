import { Injectable, signal, computed } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { tap } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import { ApiResponse } from '../models/api-response.model';
import { LoginRequest } from '../models/user.model';
import { jwtDecode } from '../utils/jwt-decode.util';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private readonly TOKEN_KEY = 'ig_token';

  private _token = signal<string | null>(this.getStoredToken());

  readonly isAuthenticated = computed(() => !!this._token());
  readonly currentToken = computed(() => this._token());
  readonly currentUserId = computed(() => {
    const token = this._token();
    if (!token) return null;
    try {
      const payload = jwtDecode(token);
      return payload['IdUser'] as string ?? null;
    } catch {
      return null;
    }
  });
  readonly currentUserEmail = computed(() => {
    const token = this._token();
    if (!token) return null;
    try {
      const payload = jwtDecode(token);
      return payload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress'] as string ?? null;
    } catch {
      return null;
    }
  });

  constructor(private http: HttpClient, private router: Router) {}

  login(request: LoginRequest) {
    return this.http.post<ApiResponse<string>>(`${environment.apiUrl}/auth/login`, request).pipe(
      tap(response => {
        if (response.data) {
          this.storeToken(response.data);
          this._token.set(response.data);
        }
      })
    );
  }

  logout() {
    localStorage.removeItem(this.TOKEN_KEY);
    this._token.set(null);
    this.router.navigate(['/auth/login']);
  }

  private storeToken(token: string) {
    localStorage.setItem(this.TOKEN_KEY, token);
  }

  private getStoredToken(): string | null {
    return localStorage.getItem(this.TOKEN_KEY);
  }
}
