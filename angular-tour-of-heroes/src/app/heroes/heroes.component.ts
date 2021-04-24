import { Component, OnInit } from '@angular/core';
import { Hero } from '../hero';
import { HEROES } from '../mock-heroes';
import { HeroService } from '../hero.service';
import { Observable } from 'rxjs';
import { DOCUMENT, Location, LocationStrategy } from '@angular/common';
import { Inject } from '@angular/core';

@Component({
  selector: 'app-heroes',
  templateUrl: './heroes.component.html',
  styleUrls: ['./heroes.component.css']
})

export class HeroesComponent implements OnInit {

  heroes : Hero[] =[];

  constructor(private heroService: HeroService,@Inject(DOCUMENT) private document: Document) { }

  ngOnInit() {
    this.getHeroes();
  }


  getHeroes(){
    return  this.heroService.getHeroes()
    .subscribe(heroes => (this.heroes = heroes));

  }
  add(name: string): void {
    name = name.trim();
    if (!name) { return; }
    this.heroService.addHero({ name } as Hero)
      .subscribe(() => this.document.location.reload());
  }

  delete(hero: Hero): void {
    this.heroes = this.heroes.filter(h => h !== hero);
    this.heroService.deleteHero(hero.id).subscribe();
  }
  Delete(id : number){
    this.heroService.deleteHero(id)
      .subscribe(() => this.document.location.reload());
  }
}