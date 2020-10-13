import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-shorten',
  templateUrl: './shorten.component.html',
  styleUrls: ['./shorten.component.css']
})

export class ShortenComponent {
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.shortenEndpoint = baseUrl + "ShortUrl";
    this.lekkerEndpoint = baseUrl + "LekkerUrl";
    this.redirectionEndpoint = baseUrl + "r/";
    this.http = http;
  }

  private redirectionEndpoint: string;
  private shortenEndpoint: string;
  private lekkerEndpoint: string;
  private http: HttpClient;

  public modifiedUrl: string;

  public getLekkerUrl(url: string) {
    this.getModifiedUrlFromEndpoint(url, this.lekkerEndpoint);
  }

  public getShortUrl(url: string) {
    this.getModifiedUrlFromEndpoint(url, this.shortenEndpoint);
  }

  public getModifiedUrlFromEndpoint(url: string, endpoint: string) {
    this.modifiedUrl = '';
    this.http.post<ModifiedUrl>(endpoint, { url: url }).subscribe(result => {
      this.modifiedUrl = this.redirectionEndpoint + result.shortUrl;
    }, error => console.error(error));
  }
}

interface ModifiedUrl {
  shortUrl: string;
}
