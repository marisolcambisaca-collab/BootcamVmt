export interface MockUser {
  id: string;
  username: string;
  displayName: string;
  avatarColor: string;
  avatarLetter: string;
  isVerified: boolean;
  hasStory: boolean;
  storyViewed: boolean;
}

export interface MockComment {
  username: string;
  text: string;
  avatarColor: string;
}

export interface MockPost {
  id: string;
  user: MockUser;
  imageUrl: string;
  description: string;
  location: string;
  likes: number;
  liked: boolean;
  saved: boolean;
  comments: MockComment[];
  timeAgo: string;
  hashtags: string[];
  Interesante: boolean;  
  Celebrar: boolean;     
  Divertido: boolean;  
}

export const MOCK_USERS: MockUser[] = [
  { id: '1', username: 'maria.lopez', displayName: 'María López', avatarColor: '#e1306c', avatarLetter: 'M', isVerified: true, hasStory: true, storyViewed: false },
  { id: '2', username: 'carlos_dev', displayName: 'Carlos Dev', avatarColor: '#405de6', avatarLetter: 'C', isVerified: false, hasStory: true, storyViewed: false },
  { id: '3', username: 'sofia.travels', displayName: 'Sofía Travels', avatarColor: '#fd1d1d', avatarLetter: 'S', isVerified: true, hasStory: true, storyViewed: true },
  { id: '4', username: 'andres_photo', displayName: 'Andrés Photo', avatarColor: '#833ab4', avatarLetter: 'A', isVerified: false, hasStory: true, storyViewed: false },
  { id: '5', username: 'luna.art', displayName: 'Luna Art', avatarColor: '#f77737', avatarLetter: 'L', isVerified: false, hasStory: false, storyViewed: false },
  { id: '6', username: 'diego.fit', displayName: 'Diego Fit', avatarColor: '#fcb045', avatarLetter: 'D', isVerified: false, hasStory: true, storyViewed: false },
  { id: '7', username: 'valentina_m', displayName: 'Valentina M.', avatarColor: '#12b886', avatarLetter: 'V', isVerified: false, hasStory: true, storyViewed: false },
];

export const MOCK_POSTS: MockPost[] = [
  {
    id: '1',
    user: MOCK_USERS[0],
   imageUrl: 'assets/images/baile.png',
    description: 'Un bailecito en el Curso',
    location: 'Guayaquil-Ecuador',
    likes: 1842,
    liked: false,
    saved: false,
    comments: [
      { username: 'carlos_dev', text: '¡Qué foto tan hermosa! 😍', avatarColor: '#405de6' },
      { username: 'sofia.travels', text: 'Extraño tanto ese lugar ❤️', avatarColor: '#fd1d1d' },
      { username: 'andres_photo', text: 'La luz es increíble en esa hora', avatarColor: '#833ab4' },
    ],
    timeAgo: 'hace 2 horas',
    hashtags: ['atardecer', 'buenosaires', 'photography', 'citylife'],
    Interesante: false,
    Celebrar: false,
    Divertido: false
  },
  {
    id: '2',
    user: MOCK_USERS[1],
    imageUrl: 'assets/images/grupo.png',
    description: 'Nuevo proyecto terminado 🚀 Meses de trabajo y finalmente listo. El esfuerzo siempre vale la pena',
    location: 'Medellín, Colombia',
    likes: 956,
    liked: true,
    saved: false,
    comments: [
      { username: 'luna.art', text: '¡Felicidades! Se ve increíble 🎉', avatarColor: '#f77737' },
      { username: 'diego.fit', text: 'Siempre inspirando 💪', avatarColor: '#fcb045' },
    ],
    timeAgo: 'hace 5 horas',
    hashtags: ['developer', 'coding', 'webdev', 'startup'],
    Interesante: false,
    Celebrar: false,
    Divertido: false
  },
  {
    id: '3',
    user: MOCK_USERS[2],
    imageUrl: 'https://picsum.photos/seed/post3/600/600',
    description: 'Explorando nuevos destinos ✈️🌍 Cada viaje es una historia diferente. ¿A dónde debería ir después?',
    location: 'Cartagena, Colombia',
    likes: 3201,
    liked: false,
    saved: true,
    comments: [
      { username: 'maria.lopez', text: 'Qué envidia sana 😭🔥', avatarColor: '#e1306c' },
      { username: 'valentina_m', text: '¡Quiero ir! Se ve espectacular', avatarColor: '#12b886' },
      { username: 'andres_photo', text: 'La composición es perfecta 📸', avatarColor: '#833ab4' },
      { username: 'carlos_dev', text: '¿Cuándo el próximo destino? 🌎', avatarColor: '#405de6' },
    ],
    timeAgo: 'hace 1 día',
    hashtags: ['travel', 'adventure', 'colombia', 'cartagena', 'viajes'],
    Interesante: false,
    Celebrar: false,
    Divertido: false
  },
  {
    id: '4',
    user: MOCK_USERS[3],
    imageUrl: 'https://picsum.photos/seed/post4/600/600',
    description: 'La naturaleza siempre tiene algo nuevo que mostrar 🌿🍃 Esta mañana amaneció así de espectacular',
    location: 'Barichara, Santander',
    likes: 721,
    liked: false,
    saved: false,
    comments: [
      { username: 'sofia.travels', text: '¡Qué lugar tan mágico! 💚', avatarColor: '#fd1d1d' },
      { username: 'luna.art', text: 'Los colores son una obra de arte', avatarColor: '#f77737' },
    ],
    timeAgo: 'hace 2 días',
    hashtags: ['naturaleza', 'colombia', 'amanecer', 'paisaje'],
    Interesante: false,
    Celebrar: false,
    Divertido: false
  },
  {
    id: '5',
    user: MOCK_USERS[5],
    imageUrl: 'https://picsum.photos/seed/post5/600/600',
    description: 'Día de entrenamiento completado 💪🔥 La constancia es la clave del éxito. No hay atajos',
    location: 'Bogotá, Colombia',
    likes: 2103,
    liked: false,
    saved: false,
    comments: [
      { username: 'carlos_dev', text: '¡Motivación total! 🔥', avatarColor: '#405de6' },
      { username: 'valentina_m', text: 'Inspirando como siempre 💯', avatarColor: '#12b886' },
    ],
    timeAgo: 'hace 3 días',
    hashtags: ['fitness', 'gym', 'workout', 'motivacion', 'salud'],
    Interesante: false,
    Celebrar: false,
    Divertido: false
  }
];

export const SUGGESTIONS: MockUser[] = [
  { id: '8', username: 'photo.world', displayName: 'Photo World', avatarColor: '#e1306c', avatarLetter: 'P', isVerified: true, hasStory: false, storyViewed: false },
  { id: '9', username: 'travel.diary', displayName: 'Travel Diary', avatarColor: '#405de6', avatarLetter: 'T', isVerified: false, hasStory: false, storyViewed: false },
  { id: '10', username: 'food.lovers', displayName: 'Food Lovers', avatarColor: '#fcb045', avatarLetter: 'F', isVerified: false, hasStory: false, storyViewed: false },
  { id: '11', username: 'art.gallery', displayName: 'Art Gallery', avatarColor: '#833ab4', avatarLetter: 'A', isVerified: true, hasStory: false, storyViewed: false },
  { id: '12', username: 'music.vibes', displayName: 'Music Vibes', avatarColor: '#12b886', avatarLetter: 'M', isVerified: false, hasStory: false, storyViewed: false },
];
