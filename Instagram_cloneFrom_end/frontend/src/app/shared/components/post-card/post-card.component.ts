import { Component, Input, signal } from '@angular/core';
import { MockPost } from '../../../core/data/mock.data';

@Component({
  selector: 'app-post-card',
  standalone: true,
  imports: [],
  templateUrl: './post-card.component.html',
  styleUrl: './post-card.component.scss'
})
export class PostCardComponent {
  @Input() post!: MockPost;

  showAllComments = signal(false);
  menuOpen = signal(false);
  imageLoaded = signal(false);
  selectedReaction = signal<string | null>(null);

toggleLike() {
  const yaActivo = this.post.liked;
  this.post.liked = false;
  this.post.Celebrar = false;
  this.post.Divertido = false;
  this.post.Interesante = false;

  if (!yaActivo) {
    this.post.liked = true;
    this.post.likes += 1;
  } else {
    this.post.likes -= 1;
  }
}

onInteresante() {
  const yaActivo = this.post.Interesante;
  this.post.liked = false;
  this.post.Celebrar = false;
  this.post.Divertido = false;
  this.post.Interesante = false;

  if (!yaActivo) {
    this.post.Interesante = true;
  }
}

onCelebrar() {
  const yaActivo = this.post.Celebrar;
  this.post.liked = false;
  this.post.Celebrar = false;
  this.post.Divertido = false;
  this.post.Interesante = false;

  if (!yaActivo) {
    this.post.Celebrar = true;
  }
}

onDivertido() {
  const yaActivo = this.post.Divertido;
  this.post.liked = false;
  this.post.Celebrar = false;
  this.post.Divertido = false;
  this.post.Interesante = false;

  if (!yaActivo) {
    this.post.Divertido = true;
  }
}
toggleSave() {
  this.post.saved = !this.post.saved;
}
formatLikes(n: number): string {
  if (n >= 1000) return (n / 1000).toFixed(1).replace('.0', '') + 'k';
  return n.toString();
}
}
