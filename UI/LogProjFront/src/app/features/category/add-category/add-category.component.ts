import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-add-category',
  imports: [ReactiveFormsModule],
  templateUrl: './add-category.component.html',
  styleUrl: './add-category.component.css'
})
export class AddCategoryComponent {

  addCategoryFormGroup = new FormGroup({
    name: new FormControl<string>('', { nonNullable: true }),
    urlHandle: new FormControl<string>('', { nonNullable: true })
  });

  onSubmit() {
    console.log(this.addCategoryFormGroup.getRawValue());
  }

}
