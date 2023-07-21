import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { EmployeePageComponent } from "./pages/employee-page/employee-page.component";

export const routes: Routes = [
  {
    path: 'employee',
    component: EmployeePageComponent
  },
  {
    path: '',
    redirectTo: 'employee',
    pathMatch: 'full'
  }
]

export class AppRoutingModule {
  
}
