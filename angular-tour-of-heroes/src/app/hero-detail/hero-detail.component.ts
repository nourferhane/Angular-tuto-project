import {Hero} from '../hero'
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HeroService } from '../hero.service';
import { Location } from '@angular/common';
import { DOCUMENT } from '@angular/common';
import { Inject } from '@angular/core';

@Component({
  selector: 'app-hero-detail',
  templateUrl: './hero-detail.component.html',
  styleUrls: ['./hero-detail.component.css']
})
export class HeroDetailComponent implements OnInit {
  @Input('data') hero : Hero;
  constructor(private route:ActivatedRoute, private heroService:HeroService,
    private location:Location,@Inject(DOCUMENT) private document: Document) { }

  ngOnInit(): void {
   //this.getHero();
  }
  getHero(): void{
    const id = +this.route.snapshot.paramMap.get('id');

    this.heroService.getHero(id )
    .subscribe(hero => this.hero = hero);
  }
  goBack(): void {
    this.location.back();
  }
  save(): void {
  this.heroService.updateHero(this.hero.id,this.hero)
    .subscribe(() =>this.document.location.reload());

}
}
