import { Injectable } from '@angular/core';
import {Hero} from './Hero';
import { HEROES } from './mock-heroes';
import { Observable, of } from 'rxjs';
import { MessageService } from './message.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HeroService {
  private heroesUrl = 'api/heroes';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  constructor(private messageService:MessageService,
    private http: HttpClient,) { }

  getHeroes():Observable< Hero[]> {
    return this.http.get<Hero[]>(this.heroesUrl)

  }

  getHero(id:number):Observable< Hero> {
    this.messageService.add(`fetch hero by id: ${id}`);

    return of(HEROES.find(hero => hero.id===id));
  }
}
