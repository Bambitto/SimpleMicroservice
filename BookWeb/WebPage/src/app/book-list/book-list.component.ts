import { Component, OnInit, OnDestroy } from '@angular/core';
import { Book } from '../book.model';
import { CommonModule, NgOptimizedImage } from '@angular/common'
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatChipListboxChange, MatChipsModule } from '@angular/material/chips';
import { Subscription } from 'rxjs';
import { SharedService } from '../SharedService';

@Component({
  selector: 'app-book-list',
  standalone: true,
  imports: [CommonModule, NgOptimizedImage, MatIconModule, MatButtonModule, MatChipsModule],
  templateUrl: './book-list.component.html',
  styleUrl: './book-list.component.css'
})
export class BookListComponent implements OnInit, OnDestroy {
  books: Book[] = [
    {
      id: 1,
      title: 'Beautiful Beach House',
      author: 'J. N. Bowling',
      genre: 'Komedia',
      imageUrl: 'https://sukces.pl/sklep/wp-content/uploads/2019/02/ksiazka_rusz_dupe.jpg',
      isFavorite: true,
    },
    {
      id: 1,
      title: 'Beautiful Beach House',
      author: 'J. N. Bowling',
      genre: 'Kryminał',
      imageUrl: 'https://sukces.pl/sklep/wp-content/uploads/2019/02/ksiazka_rusz_dupe.jpg',
      isFavorite: true,
    },
    {
      id: 1,
      title: 'Beautiful Beach House',
      author: 'J. N. Bowling',
      genre: 'Komedia',
      imageUrl: 'https://sukces.pl/sklep/wp-content/uploads/2019/02/ksiazka_rusz_dupe.jpg',
      isFavorite: true,
    },
    {
      id: 1,
      title: 'Beautiful Beach House',
      author: 'J. N. Bowling',
      genre: 'Komedia',
      imageUrl: 'https://sukces.pl/sklep/wp-content/uploads/2019/02/ksiazka_rusz_dupe.jpg',
      isFavorite: true,
    },
    {
      id: 1,
      title: 'Beautiful Beach House',
      author: 'J. N. Bowling',
      genre: 'Komedia',
      imageUrl: 'https://sukces.pl/sklep/wp-content/uploads/2019/02/ksiazka_rusz_dupe.jpg',
      isFavorite: true,
    },
    {
      id: 1,
      title: 'Beautiful Beach House',
      author: 'J. N. Bowling',
      genre: 'Komedia',
      imageUrl: 'https://sukces.pl/sklep/wp-content/uploads/2019/02/ksiazka_rusz_dupe.jpg',
      isFavorite: true,
    },
    {
      id: 1,
      title: 'Beautiful Beach House',
      author: 'J. N. Bowling',
      genre: 'Komedia',
      imageUrl: 'https://sukces.pl/sklep/wp-content/uploads/2019/02/ksiazka_rusz_dupe.jpg',
      isFavorite: true,
    },
    {
      id: 1,
      title: 'Beautiful Beach House',
      author: 'J. N. Bowling',
      genre: 'Komedia',
      imageUrl: 'https://sukces.pl/sklep/wp-content/uploads/2019/02/ksiazka_rusz_dupe.jpg',
      isFavorite: true,
    },
    {
      id: 1,
      title: 'Beautiful Beach House',
      author: 'J. N. Bowling',
      genre: 'Komedia',
      imageUrl: 'https://sukces.pl/sklep/wp-content/uploads/2019/02/ksiazka_rusz_dupe.jpg',
      isFavorite: true,
    },
    {
      id: 1,
      title: 'Beautiful Beach House',
      author: 'J. N. Bowling',
      genre: 'Komedia',
      imageUrl: 'https://sukces.pl/sklep/wp-content/uploads/2019/02/ksiazka_rusz_dupe.jpg',
      isFavorite: true,
    },

  ];
  showedBooks: Book[] = this.books;
  public genres: string[] = ['Komedia', 'Kryminał', 'Powieść', 'Sci-finction', 'Kryminał', 'Powieść', 'Sci-finction', 'Kryminał', 'Powieść', 'Sci-finction']
  selectedGenre = "";
  private searchSubscription: Subscription = new Subscription;

  constructor(private sharedService: SharedService) { }

  ngOnInit() {
    this.searchSubscription = this.sharedService.currentSearchTerm.subscribe(term => {
      this.filterBooks(term);
    });
  }

  ngOnDestroy() {
    this.searchSubscription.unsubscribe();
  }

  onSelection(event: MatChipListboxChange) {
    const selected = event.value;
    if (selected.length) {
      // Assuming single selection, adjust if multiple
      this.selectedGenre = selected;
      this.showedBooks = this.books.filter(book => book.genre === this.selectedGenre);
    } else {
      this.selectedGenre = "";
    }
  }

  filterBooks(searchTerm: string) {
    if (!searchTerm) {
      this.showedBooks = this.books.slice(); // No search term, show all books
    } else {
      this.showedBooks = this.books.filter(book =>
        book.title.toLowerCase().includes(searchTerm.toLowerCase()) ||
        book.author.toLowerCase().includes(searchTerm.toLowerCase())
      );
      console.log(searchTerm)
    }
  }
}
