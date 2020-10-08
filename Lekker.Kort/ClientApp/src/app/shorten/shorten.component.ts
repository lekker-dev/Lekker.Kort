import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-shorten',
  templateUrl: './shorten.component.html'
})
export class ShortenComponent {

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.controllerEndpoint = baseUrl + "ShortUrl";
    this.http = http;
  }

  private controllerEndpoint: string;
  private http: HttpClient;
  public shortenedUrl: string;

  public getShortUrl(url: string) {
    this.http.post<ShortUrl>(this.controllerEndpoint, { url : url }).subscribe(result => {
      this.shortenedUrl = result.shortUrl;
    }, error => console.error(error));

  }
}

interface ShortUrl {
  shortUrl: string;
}
