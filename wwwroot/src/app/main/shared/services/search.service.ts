import { Injectable } from '@angular/core';
import { Subject }    from 'rxjs/Subject';

@Injectable()
export class SearchService {

  private searchConfirmedSource = new Subject<string>();

  searchConfirmed$ = this.searchConfirmedSource.asObservable();

  confirmSearch(text: string) {
    this.searchConfirmedSource.next(text);
  }
}
