import { Component, effect, inject } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AddCategoryRequest } from '../models/category.model';
import { CategoryServiceService } from '../services/category-service.service';

@Component({
  selector: 'app-add-category',
  imports: [ReactiveFormsModule],
  templateUrl: './add-category.component.html',
  styleUrl: './add-category.component.css'
})
export class AddCategoryComponent {
  private categoryService = inject(CategoryServiceService)

  constructor() {
    effect(() => {
      if (this.categoryService.addCategoryStatus() === 'success') {
        console.log('Add Category request Success');

      }
      if (this.categoryService.addCategoryStatus() === 'error') {
        console.error('Add Category request Filed');
      }
    })
  }
  addCategoryFormGroup = new FormGroup({
    name: new FormControl<string>('', { nonNullable: true, validators: [Validators.required, Validators.maxLength(100)] }),
    urlHandle: new FormControl<string>('', { nonNullable: true, validators: [Validators.required, Validators.maxLength(200)] })
  });

  get nameFormControl() {
    return this.addCategoryFormGroup.controls.name
  }
  get urlHandleFormControl() {
    return this.addCategoryFormGroup.controls.urlHandle
  }

  onSubmit() {
    const addCategoryFormValue = this.addCategoryFormGroup.getRawValue();
    const addCategoryRequestDto: AddCategoryRequest = {
      name: addCategoryFormValue.name,
      urlHandle: addCategoryFormValue.urlHandle
    }

    this.categoryService.addCategory(addCategoryRequestDto);

  }

}
