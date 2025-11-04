import { Component, inject } from '@angular/core';
import { RouterLink } from "@angular/router";
import { CategoryService } from '../services/category-service';

@Component({
  selector: 'app-categor-list',
  imports: [RouterLink],
  templateUrl: './categor-list.component.html',
  styleUrl: './categor-list.component.css'
})
export class CategorListComponent {
  private categoryService = inject(CategoryService)
  private getAllCategoriesRef = this.categoryService.getAllCategories();

  isLoading = this.getAllCategoriesRef.isLoading;
  isError = this.getAllCategoriesRef.error;
  value = this.getAllCategoriesRef.value;
}
