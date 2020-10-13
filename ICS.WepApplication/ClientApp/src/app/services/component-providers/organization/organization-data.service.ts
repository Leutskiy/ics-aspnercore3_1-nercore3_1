import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { APP_CONFIG, IAppConfig } from '../../../settings/app-config';
import { ComponentDataService } from '../component-data.service';
import { Organization } from '../../../contracts/login-data';

@Injectable()
export class OrganizationDataService extends ComponentDataService<Organization> {

  constructor(
    private http: HttpClient,
    @Inject(APP_CONFIG) private config: IAppConfig) {
      super('api/v1/organization', http, config);
  }

  setDataById(componentData: Organization, id: string) {
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    const options = { headers: headers };

    return this.client.post<any>(`${this.uriPath}/${id}`, componentData, options);
  }
}
