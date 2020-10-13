import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { APP_CONFIG, IAppConfig } from '../../../settings/app-config';
import { Employee } from '../../../contracts/login-data';

@Injectable()
export class EmployeeDataService {

  private readonly uriRelativePath: string = "api/v1/employee";
  uriPath: string;

  constructor(
    private http: HttpClient,
    @Inject(APP_CONFIG) private config: IAppConfig) {
      this.uriPath = `${config.icsApiEndpoint}${this.uriRelativePath}`;
  }

  getData() {
    return this.http.get<any>(this.uriPath);
  }

  getDataById(id: string) {
    return this.http.get<any>(`${this.uriPath}/${id}`);
  }

  setDataById(componentData: Employee, id: string) {
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    const options = { headers: headers };

    return this.http.post<any>(`${this.uriPath}/${id}`, componentData, options);
  }
}
