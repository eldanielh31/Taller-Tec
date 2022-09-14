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

  public deleteEmploye( id : number ){
    return this.httpClient.delete(`${this.url}employees/id/${id}`)
  }

  public postEmploye( user: Object ){
    let httpheaders = new HttpHeaders()
      .set('Content-type', 'application/Json');
    let options = {
      headers: httpheaders
    };
    return this.httpClient.post(`${this.url}employees/new`, user, options)
  }

  public deleteClient(id: number) {
    return this.httpClient.delete(`${this.url}clients/id/${id}`)
  }

  public postClient(user: Object) {
    return this.httpClient.post(`${this.url}clients/new`, user)
  }

}
