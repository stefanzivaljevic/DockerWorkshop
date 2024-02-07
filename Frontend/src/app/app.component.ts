import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'webExample';
  currentEnv: string = '';
  favoriteColor: string = '';
  favoriteColors: Array<string> = new Array<string>();
  baseUrl: string = 'http://localhost:5000';
  loading: boolean = false;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getData();
  }

  public getEnvironment(): void {
    this.http
      .get(this.baseUrl + '/Environment', { responseType: 'text' })
      .subscribe((response) => {
        this.currentEnv = response;
      });
  }

  public addFavoriteColor(): void {
    this.loading = true;
    this.http
      .post(this.baseUrl + '/Color', JSON.stringify(this.favoriteColor), {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .subscribe(() => {
        this.loading = false;
        this.getData();
      });
  }

  private getData(): void {
    this.loading = true;
    this.http.get(this.baseUrl + '/Color').subscribe((response) => {
      this.favoriteColors = response as Array<string>;
      this.loading = false;
    });
  }
}
