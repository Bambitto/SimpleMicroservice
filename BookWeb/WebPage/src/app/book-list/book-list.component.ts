import { Component, OnInit } from '@angular/core';
import { Book } from '../book.model';
import { CommonModule } from '@angular/common'
import { NgOptimizedImage } from '@angular/common'
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-book-list',
  standalone: true,
  imports: [CommonModule, NgOptimizedImage, MatIconModule, MatButtonModule],
  templateUrl: './book-list.component.html',
  styleUrl: './book-list.component.css'
})
export class BookListComponent implements OnInit {
  books: Book[] = [
    {
      id: 1,
      title: 'Beautiful Beach House',
      location: 'California, USA',
      price: 200,
      imageUrl: 'https://sukces.pl/sklep/wp-content/uploads/2019/02/ksiazka_rusz_dupe.jpg',
      isFavorite: true,
    },
    {
      id: 2,
      title: 'Beautiful Beach House',
      location: 'California, USA',
      price: 200,
      imageUrl: 'https://sukces.pl/sklep/wp-content/uploads/2019/02/ksiazka_rusz_dupe.jpg',
      isFavorite: false
    },
    {
      id: 3,
      title: 'Beautiful Beach House',
      location: 'California, USA',
      price: 200,
      imageUrl: 'https://sukces.pl/sklep/wp-content/uploads/2019/02/ksiazka_rusz_dupe.jpg',
      isFavorite: false
    },
    {
      id: 1,
      title: 'Beautiful Beach House',
      location: 'California, USA',
      price: 200,
      imageUrl: 'https://sukces.pl/sklep/wp-content/uploads/2019/02/ksiazka_rusz_dupe.jpg',
      isFavorite: false
    },
    {
      id: 2,
      title: 'Beautiful Beach House',
      location: 'California, USA',
      price: 200,
      imageUrl: 'https://sukces.pl/sklep/wp-content/uploads/2019/02/ksiazka_rusz_dupe.jpg',
      isFavorite: false
    },
    {
      id: 3,
      title: 'Beautiful Beach House',
      location: 'California, USA',
      price: 200,
      imageUrl: 'https://sukces.pl/sklep/wp-content/uploads/2019/02/ksiazka_rusz_dupe.jpg',
      isFavorite: false
    },
    {
      id: 1,
      title: 'Beautiful Beach House',
      location: 'California, USA',
      price: 200,
      imageUrl: 'https://sukces.pl/sklep/wp-content/uploads/2019/02/ksiazka_rusz_dupe.jpg',
      isFavorite: true
    },
    {
      id: 2,
      title: 'Beautiful Beach House',
      location: 'California, USA',
      price: 200,
      imageUrl: 'https://sukces.pl/sklep/wp-content/uploads/2019/02/ksiazka_rusz_dupe.jpg',
      isFavorite: false
    },
    {
      id: 3,
      title: 'Beautiful Beach House',
      location: 'California, USA',
      price: 200,
      imageUrl: 'https://sukces.pl/sklep/wp-content/uploads/2019/02/ksiazka_rusz_dupe.jpg',
      isFavorite: false
    },
    {
      id: 1,
      title: 'Beautiful Beach House',
      location: 'California, USA',
      price: 200,
      imageUrl: 'https://sukces.pl/sklep/wp-content/uploads/2019/02/ksiazka_rusz_dupe.jpg',
      isFavorite: false
    },
    {
      id: 2,
      title: 'Beautiful Beach House',
      location: 'California, USA',
      price: 200,
      imageUrl: 'https://sukces.pl/sklep/wp-content/uploads/2019/02/ksiazka_rusz_dupe.jpg',
      isFavorite: false
    },
    {
      id: 3,
      title: 'Beautiful Beach House',
      location: 'California, USA',
      price: 200,
      imageUrl: 'https://sukces.pl/sklep/wp-content/uploads/2019/02/ksiazka_rusz_dupe.jpg',
      isFavorite: false
    },
  ];

  constructor() { }

  ngOnInit(): void {

  }
}
