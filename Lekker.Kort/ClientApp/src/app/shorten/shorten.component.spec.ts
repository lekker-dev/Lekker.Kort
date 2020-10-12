import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShortenComponent } from './shorten.component';

describe('CounterComponent', () => {
  let component: ShortenComponent;
  let fixture: ComponentFixture<ShortenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ShortenComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShortenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should display a title', async(() => {
    const titleText = fixture.nativeElement.querySelector('h1').textContent;
    expect(titleText).toEqual('Maak hom Lekker');
  }));

  //it('should create a url when lekker is clicked', async(() => {
  //  const countElement = fixture.nativeElement.querySelector('strong');
  //  expect(countElement.textContent).toEqual('0');

  //  const incrementButton = fixture.nativeElement.querySelector('button');
  //  incrementButton.click();
  //  fixture.detectChanges();
  //  expect(countElement.textContent).toEqual('1');
  //}));
});
