import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LandingComponent } from './pages/landing/landing.component';
import { SigninComponent } from './pages/signin/signin.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';

const routes: Routes = [
	{ path: 'home', component: LandingComponent },
	{ path: 'sign-in', component: SigninComponent },
	{ path: 'sign-up', component: LandingComponent },
	{ path: 'app', component: DashboardComponent },
	{ path: 'editar-graduados/:id', component: LandingComponent },
	{ path: '**', pathMatch: 'full', redirectTo: 'home' },
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule],
})
export class AppRoutingModule {}
