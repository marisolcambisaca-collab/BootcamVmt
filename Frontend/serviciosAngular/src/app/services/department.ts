  import { Injectable, inject } from '@angular/core';
  import { HttpClient } from '@angular/common/http'; 
  import { Observable } from 'rxjs';
  import { Department } from '../interfaces/department'; 
  import { environment } from '../../environments/environments';
@Injectable({
  providedIn: 'root',
  
})
export class DepartmentService {

  private apiUrl = environment.apiUrl;
  private http = inject(HttpClient);

  getAll(): Observable<Department[]> {
    return this.http.get<Department[]>(`${this.apiUrl}/departments`);
  }

  getById(id: string): Observable<Department> {
    return this.http.get<Department>(`${this.apiUrl}/departments/${id}`);
  }


}
