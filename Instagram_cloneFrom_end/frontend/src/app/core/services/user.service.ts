import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { ApiResponse } from '../models/api-response.model';
import { UserDTO, CreateUserRequest, GetUsersParams } from '../models/user.model';

@Injectable({ providedIn: 'root' })
export class UserService {
  constructor(private http: HttpClient) {}

  createUser(request: CreateUserRequest): Observable<ApiResponse<UserDTO>> {
    return this.http.post<ApiResponse<UserDTO>>(`${environment.apiUrl}/users`, request);
  }

  getUsers(params?: GetUsersParams): Observable<ApiResponse<UserDTO[]>> {
    let httpParams = new HttpParams();
    if (params?.limit !== undefined) httpParams = httpParams.set('limit', params.limit);
    if (params?.offset !== undefined) httpParams = httpParams.set('offset', params.offset);
    if (params?.nameUser) httpParams = httpParams.set('nameUser', params.nameUser);
    if (params?.id) httpParams = httpParams.set('id', params.id);
    return this.http.get<ApiResponse<UserDTO[]>>(`${environment.apiUrl}/users`, { params: httpParams });
  }

  getUserById(id: string): Observable<ApiResponse<UserDTO>> {
    return this.http.get<ApiResponse<UserDTO>>(`${environment.apiUrl}/users/${id}`);
  }
}

