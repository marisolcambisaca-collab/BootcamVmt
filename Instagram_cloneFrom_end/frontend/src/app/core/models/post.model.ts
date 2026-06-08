export interface PostDTO {
  postID: string;
  userID: string;
  isStory: boolean;
  postDescription: string;
  locationName: string | null;
  latitude: number | null;
  longitude: number | null;
  mediaUrl: string;
  createdAt: string;
  expiresAt: string | null;
}

export interface CreatePostRequest {
  postDescription: string;
  isStory: boolean;
  locationName?: string;
  latitude?: number;
  longitude?: number;
  mediaUrl: File;
}
