import { Component, WritableSignal } from '@angular/core';
import { Product } from '../../lib/types/productType';
import { signal } from '@angular/core';

@Component({
  selector: 'app-product',
  imports: [],
  templateUrl: './product.html',
  styleUrl: './product.css',
})
export class ProductComponent {

  nextId: number = 1;

  selectedProduct? : Product = undefined;

  products: WritableSignal<Product[]> = signal<Product[]> ([
    {
      id: this.nextId++,
      name: 'Xbox',
      description: 'Une console de maxxxxeur',
      price: 850,
      image: "https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcSKpD2BbIWKr40ar4FCZhV8GqARoOVFsR7mrXxfc6iasSyFqsS7sJ7K9DlaDcd2dxEOtsR8Fg_m-uH5uELDTaxtiiGxrKoh"
    },

    {
      id: this.nextId++,
      name: 'PS5',
      description: 'Une console de Sony',
      price: 650,
      image: "https://media.s-bol.com/3D6zn3jJGvyn/WnQNpEn/550x533.jpg"
    },

    {
      id: this.nextId++,
      name: 'Switch',
      description: 'Une console jap',
      price: 400,
      image: "https://files.refurbed.com/ii/nintendo-switch-2017-1647351625.jpg?t=fitdesign&h=600&w=800&t=convert&f=webp"
    },

  ])
};


