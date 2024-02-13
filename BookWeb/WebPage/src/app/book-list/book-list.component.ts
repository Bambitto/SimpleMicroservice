import { Component, OnInit } from '@angular/core';
import { Book } from '../book.model';
import { CommonModule } from '@angular/common'
import { NgOptimizedImage } from '@angular/common'
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatChipListboxChange, MatChipsModule } from '@angular/material/chips';

@Component({
  selector: 'app-book-list',
  standalone: true,
  imports: [CommonModule, NgOptimizedImage, MatIconModule, MatButtonModule, MatChipsModule],
  templateUrl: './book-list.component.html',
  styleUrl: './book-list.component.css'
})
export class BookListComponent implements OnInit {
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

  constructor() { }

  ngOnInit(): void {

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
    

    console.log(this.selectedGenre)
  }
}
