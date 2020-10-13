import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IAppConfig } from '../../settings/app-config';

export abstract class ComponentDataService<TComponentData> {

  uriPath: string;
  client: HttpClient

  constructor(uriRelativePath: string, httpClient: HttpClient, config: IAppConfig) {
      this.uriPath = `${config.icsApiEndpoint}${uriRelativePath}`;
      this.client = httpClient;
  }

  getData() {
    return this.client.get<any>(this.uriPath);
  }

  setData(componentData: TComponentData) {
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    const options = { headers: headers };

    return this.client.post<any>(this.uriPath, componentData, options);
  }
}
