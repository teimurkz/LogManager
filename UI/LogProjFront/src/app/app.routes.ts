import { Routes } from '@angular/router';
import { CategorListComponent } from './features/category/categor-list/categor-list.component';
import { AddCategoryComponent } from './features/category/add-category/add-category.component';

export const routes: Routes = [
    {
        path: 'admin/categories',
        component: CategorListComponent
    },
    {
        path: 'admin/categories/add',
        component: AddCategoryComponent
    }
];
