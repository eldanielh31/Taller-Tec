import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class BackendService {

  url : String = 'http://localhost:5022/'

  constructor(private httpClient: HttpClient) {
  }

  public getEmploye( email: String ){
    return this.httpClient.get(`${this.url}employees/email/${email}/`)
  }
  public getClient(email: String) {
    return this.httpClient.get(`${this.url}clients/email/${email}/`)
  }

}
