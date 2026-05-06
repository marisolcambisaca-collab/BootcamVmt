import { Component, OnInit } from '@angular/core';
import { DepartmentService } from '../../services/department';
import { Department } from '../../interfaces/department';


@Component({
  selector: 'app-departments',
  imports: [],
  templateUrl: './departments.html',
  styleUrl: './departments.css',
})
 
export class Departments implements OnInit {

  departments: Department[] = [];
  error: string = '';
  loading: boolean = false;

  constructor(private departmentService: DepartmentService) {}

  ngOnInit(): void {
    this.loading = true;
    this.departmentService.getAll().subscribe({
      next: (data) => {
        this.departments = data;
        this.loading = false;
      },
      error: (err) => {
        this.error = 'Error al cargar los departamentos.';
        this.loading = false;
      }
    });
  }
}






