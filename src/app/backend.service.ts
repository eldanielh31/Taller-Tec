import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class BackendService {

  url : String = 'http://localhost:5022/'
  headers: HttpHeaders = new HttpHeaders()
    // .append('Content-Type', 'application/json')
    // .append('Access-Control-Allow-Headers', 'Content-Type')
    // .append('Access-Control-Allow-Methods', 'GET')
    // .append('Access-Control-Allow-Origin', '*');

  constructor(private httpClient: HttpClient) {
   
  }

  public getEmploye( email: String ){
    console.log(this.headers.get('Access-Control-Allow-Origin'))
    return this.httpClient.get(`${this.url}employees/email/${email}/`)
  }

}
