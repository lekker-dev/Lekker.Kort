import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatIconRegistry } from '@angular/material/icon';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-shorten',
  templateUrl: './shorten.component.html',
  styleUrls: ['./shorten.component.css']
})
export class ShortenComponent {

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, iconRegistry: MatIconRegistry, sanitizer: DomSanitizer) {
    this.shortenEndpoint = baseUrl + "ShortUrl";
    this.redirectionEndpoint = baseUrl + "r/";
    this.http = http;

    iconRegistry.addSvgIcon(
      'copy',
      sanitizer.bypassSecurityTrustResourceUrl('assets/content_copy-24px.svg'));
  }

  private redirectionEndpoint: string;
  private shortenEndpoint: string;
  private http: HttpClient;
  public shortenedUrl: string;
  public showShortened: boolean;

  public getShortUrl(url: string) {
    this.http.post<ShortUrl>(this.shortenEndpoint, { url: url }).subscribe(result => {
      this.shortenedUrl = this.redirectionEndpoint + result.shortUrl;
      this.showShortened = true;
    }, error => console.error(error));

  }
}


interface ShortUrl {
  shortUrl: string;
}
