import { Component, signal } from '@angular/core';
import { MOCK_USERS, MockUser } from '../../../core/data/mock.data';
import { AuthService } from '../../../core/services/auth.service';

@Component({
  selector: 'app-stories-bar',
  standalone: true,
  imports: [],
  templateUrl: './stories-bar.component.html',
  styleUrl: './stories-bar.component.scss'
})
export class StoriesBarComponent {
  users: MockUser[] = MOCK_USERS;
  viewingStory = signal<MockUser | null>(null);
  storyProgress = signal(0);
  private progressInterval: any;

  email: string | null;
  constructor(authService: AuthService) {
    this.email = authService.currentUserEmail();
  }

  openStory(user: MockUser) {
    if (!user.hasStory) return;
    this.viewingStory.set(user);
    this.storyProgress.set(0);
    user.storyViewed = true;

    clearInterval(this.progressInterval);
    this.progressInterval = setInterval(() => {
      const current = this.storyProgress();
      if (current >= 100) {
        this.closeStory();
      } else {
        this.storyProgress.set(current + 2);
      }
    }, 100);
  }

  closeStory() {
    clearInterval(this.progressInterval);
    this.viewingStory.set(null);
    this.storyProgress.set(0);
  }

  getMyLetter(): string {
    return this.email?.charAt(0).toUpperCase() ?? 'Y';
  }

  getMyUsername(): string {
    return this.email?.split('@')[0] ?? 'usuario';
  }

  getMyDisplayName(): string {
    return this.getMyUsername()
      .split(/[._-]/)
      .map(p => p.charAt(0).toUpperCase() + p.slice(1))
      .join(' ');
  }
}
