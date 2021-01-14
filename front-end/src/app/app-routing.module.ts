import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LandingComponent } from './pages/landing/landing.component';
import { SignInComponent } from './pages/sign-in/sign-in.component';
import { SignUpComponent } from './pages/sign-up/sign-up.component';
import { GraduadosComponent } from './pages/graduados/graduados.component';
import { AuthGuard } from './guards/auth.guard';
import { ApplicationComponent } from './pages/application/application.component';

const routes: Routes = [
	{ path: 'home', component: LandingComponent },
	{ path: 'sign-in', component: SignInComponent },
	{ path: 'sign-up', component: SignUpComponent },
	{ path: 'app', component: ApplicationComponent, canActivate: [AuthGuard] },
	{ path: 'app/graduados/:id', component: GraduadosComponent, canActivate: [AuthGuard] },
	{ path: '**', pathMatch: 'full', redirectTo: 'home' },
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule],
})
export class AppRoutingModule {}
