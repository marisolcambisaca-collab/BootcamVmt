import { Routes } from '@angular/router';
import { authGuard, guestGuard } from './core/guards/auth.guard';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./features/auth/landing/landing').then(m => m.LandingComponent)
  },
  {
    path: 'auth',
    canActivate: [guestGuard],
    children: [
      {
        path: 'login',
        loadComponent: () => import('./features/auth/login/login.component').then(m => m.LoginComponent)
      },
      {
        path: 'register',
        loadComponent: () => import('./features/auth/register/register.component').then(m => m.RegisterComponent)
      },
      { path: '', redirectTo: 'login', pathMatch: 'full' }
    ]
  },
  {
    path: 'feed',
    canActivate: [authGuard],
    loadComponent: () => import('./features/feed/feed.component').then(m => m.FeedComponent)
  },
  {
    path: ':userId/posts',
    canActivate: [authGuard],
    loadComponent: () => import('./shared/components/navbar/components/create-post/create-post.component').then(m => m.CreatePostComponent)
  },
  {
  path: 'mensajes',
  canActivate: [authGuard],
  loadComponent: () => import('./features/mensajes/pages/mensaje.component/mensaje.component').then(m => m.MensajesComponent)
},
{
  path: 'profile/:userId',
  canActivate: [authGuard],
  loadComponent: () => import('./features/profile/profile').then(m => m.ProfileComponent)
},
{ path: '**', redirectTo: '' },
  { path: '**', redirectTo: '' }
];

