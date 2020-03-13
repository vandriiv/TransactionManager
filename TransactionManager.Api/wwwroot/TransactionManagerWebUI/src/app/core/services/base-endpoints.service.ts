import { Injectable } from '@angular/core';
import { QueryStringParameters } from 'src/app/shared/helpers/query-string-parameters';
import { UrlBuilder } from 'src/app/shared/helpers/url-builder';

@Injectable({
  providedIn: 'root'
})
export abstract class BaseEndpointsService {
  protected url:string="/";

  protected createUrl(action: string): string {
    const urlBuilder: UrlBuilder = new UrlBuilder(
      this.url,
      action
    );
    return urlBuilder.toString();
  }
  
  protected createUrlWithQueryParameters(
    action: string, 
    queryStringParameters?: QueryStringParameters): string {
    const urlBuilder: UrlBuilder = new UrlBuilder(
      this.url, 
      action
    );
   
    if (queryStringParameters) {
      urlBuilder.queryString = queryStringParameters;
    }
    return urlBuilder.toString();
  }  
 
  protected createUrlWithPathVariables(
    action: string, 
    pathVariables: any[] = []
  ): string {
    let encodedPathVariablesUrl: string = '';
   
    for (const pathVariable of pathVariables) {
      if (pathVariable !== null) {
        encodedPathVariablesUrl +=
          `/${encodeURIComponent(pathVariable.toString())}`;
      }
    }
    const urlBuilder: UrlBuilder = new UrlBuilder(
      this.url,  
      `${action}${encodedPathVariablesUrl}`
    );
    return urlBuilder.toString();
  }

}
