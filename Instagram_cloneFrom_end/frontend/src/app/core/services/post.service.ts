import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { ApiResponse } from '../models/api-response.model';
import { PostDTO, CreatePostRequest } from '../models/post.model';

@Injectable({ providedIn: 'root' })
export class PostService {
private readonly baseUrl = `${environment.apiUrl}/posts`;  constructor(private http: HttpClient) {}

  createPost(userId: string, request: CreatePostRequest): Observable<ApiResponse<PostDTO>> {
    const formData = new FormData();
    formData.append('postDescription', request.postDescription);
    formData.append('isStory', request.isStory.toString());
    if (request.locationName) formData.append('locationName', request.locationName);
    if (request.latitude !== undefined && request.latitude !== null)
      formData.append('latitude', request.latitude.toString());
    if (request.longitude !== undefined && request.longitude !== null)
      formData.append('longitude', request.longitude.toString());
    formData.append('mediaUrl', request.mediaUrl);

    return this.http.post<ApiResponse<PostDTO>>(`${this.baseUrl}/${userId}`, formData);
  }
}
