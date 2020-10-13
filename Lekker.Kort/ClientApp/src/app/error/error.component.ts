import { Component, Inject } from '@angular/core';

@Component({
  selector: 'error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.css']
})

export class ErrorComponent {
  constructor(@Inject('BASE_URL') baseUrl: string) {
   
  }

  public goHome() {
    
  }

}

