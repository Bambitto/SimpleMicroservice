import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  private searchTermSource = new BehaviorSubject<string>('');
  currentSearchTerm = this.searchTermSource.asObservable();

  constructor() { }

  updateSearchTerm(term: string) {
    this.searchTermSource.next(term);
  }
}
