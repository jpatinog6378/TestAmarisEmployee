import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, Observable, of, retry } from "rxjs";
import { environment } from "../../environments/enviroment";
import { map } from 'rxjs/operators';
import { EmployeeResponseService } from "../models/employee-response";

@Injectable({
  providedIn: 'root',
})

export class EmployeeService {
  urlApi = environment.urlApi;
  headers = new HttpHeaders()
    .set('Content-Type', 'application/json')
    .set('Access-Control-Allow-Origin', '*');
  constructor(private http: HttpClient) { }

  getEmployeeAll(): Observable<EmployeeResponseService[]> {
    const endPointUrl = this.urlApi + environment.employeeAllUrl;
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    return this.http.get<EmployeeResponseService[]>(endPointUrl, { headers, observe: 'response' })
      .pipe(
        map(response => response.body ? response.body : [])
      );
  }

  getEmployeeById(idEmployee: string): Observable<EmployeeResponseService | null> {
    const endPointUrl= this.urlApi + environment.employeeByIdURL
    const params = new HttpParams({ fromObject: { idEmployee: idEmployee } });
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    return this.http.get<EmployeeResponseService>(endPointUrl, { headers, params, observe: 'response' })
      .pipe(
        map(response => response.body )
        );
  }


}
