import { Routes } from '@angular/router';
import { CategorListComponent } from './features/category/categor-list/categor-list.component';

export const routes: Routes = [
    {
        path: 'admin/categories',
        component: CategorListComponent
    }
];
