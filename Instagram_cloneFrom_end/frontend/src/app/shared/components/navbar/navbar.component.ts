import { Component, signal, HostListener } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../../core/services/auth.service';
import { BuscarComponent } from '../../../features/buscar/buscar';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule, RouterLink, RouterLinkActive,BuscarComponent],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent {
  showMenu = false;
  mostrarBuscar = false;
  mostrarNotificaciones = false;
  isDark = signal(false);

  email: string | null;
  userId: string | null;

  constructor(private authService: AuthService) {
    this.email = authService.currentUserEmail();
    this.userId = authService.currentUserId();

    const savedTheme = localStorage.getItem('ig_theme');
    if (savedTheme === 'dark') {
      this.isDark.set(true);
      document.documentElement.setAttribute('data-theme', 'dark');
    }
  }

  toggleMenu() {
    this.showMenu = !this.showMenu;
    if (this.showMenu) {
      this.mostrarBuscar = false;
      this.mostrarNotificaciones = false;
    }
  }

  toggleBuscar() {
    this.mostrarBuscar = !this.mostrarBuscar;
    this.mostrarNotificaciones = false;
    this.showMenu = false;
  }

  toggleNotificaciones() {
    this.mostrarNotificaciones = !this.mostrarNotificaciones;
    this.mostrarBuscar = false;
    this.showMenu = false;
  }

  cerrarTodos() {
    this.mostrarBuscar = false;
    this.mostrarNotificaciones = false;
    this.showMenu = false;
  }

  toggleTheme() {
    const dark = !this.isDark();
    this.isDark.set(dark);
    document.documentElement.setAttribute('data-theme', dark ? 'dark' : 'light');
    localStorage.setItem('ig_theme', dark ? 'dark' : 'light');
  }

  logout() {
    this.authService.logout();
  }

  getAvatarLetter(): string {
    return this.email?.charAt(0).toUpperCase() ?? 'U';
  }

  @HostListener('document:click', ['$event'])
  onDocumentClick(event: Event) {
    const target = event.target as HTMLElement;
    if (!target.closest('nav')) {
      this.showMenu = false;
    }
  }
}