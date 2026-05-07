import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { EmployeeService } from '../../services/employee';
import { Employee } from '../../interfaces/employee';

@Component({
  selector: 'app-employees',
  imports: [CommonModule, FormsModule],
  templateUrl: './employees.html',
  styleUrl: './employees.css',
})
export class Employees implements OnInit {

  employees: Employee[] = [];
  error: string = '';
  loading: boolean = false;

  // campos para agregar empleado
  nuevoEmpleado: Partial<Employee> = {
    name: '',
    email: '',
    phone: '',
    position: '',
    department: '',
    salary: ''
  };

  constructor(private employeeService: EmployeeService) {}

  ngOnInit(): void {
    this.cargarEmployees();
  }

  cargarEmployees() {
    this.loading = true;
    this.error = '';
    this.employeeService.getAll().subscribe({
      next: (data) => {
        this.employees = data;
        this.loading = false;
      },
      error: () => {
        this.error = 'Error al cargar empleados.';
        this.loading = false;
      }
    });
  }

  agregarEmployee() {
    this.employeeService.crearEmployee(this.nuevoEmpleado).subscribe({
      next: (empleado) => {
        this.employees.push(empleado);
        // limpiar formulario
        this.nuevoEmpleado = { name: '', email: '', phone: '', position: '', department: '', salary: '' };
      },
      error: () => {
        this.error = 'Error al agregar empleado.';
      }
    });
  }

  editarEmployee() {
    const empleado = this.employees[0];
    if (!empleado) return;

    const payload: Partial<Employee> = {
      name: 'Carlos Méndez Editado',
      email: 'carlos.editado@mail.com',
      phone: '555-0000',
      position: 'Tech Lead',
      department: 'Engineering',
      salary: '2000'
    };

    this.employeeService.actualizarEmployee(empleado.id, payload).subscribe({
      next: (actualizado) => {
        const index = this.employees.findIndex(e => e.id === empleado.id);
        this.employees[index] = actualizado;
      },
      error: () => {
        this.error = 'Error al editar empleado.';
      }
    });
  }

  eliminarEmployee(id: string) {
    this.employeeService.eliminarEmployee(id).subscribe({
      next: () => {
        this.employees = this.employees.filter(e => e.id !== id);
      },
      error: () => {
        this.error = 'Error al eliminar empleado.';
      }
    });
  }
}