import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ChartsModule, ThemeService } from 'ng2-charts';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { LandingComponent } from './pages/landing/landing.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { SignInComponent } from './pages/sign-in/sign-in.component';
import { GraduadosComponent } from './pages/graduados/graduados.component';
import { SignUpComponent } from './pages/sign-up/sign-up.component';
import { ApplicationComponent } from './pages/application/application.component';

@NgModule({
	declarations: [
		AppComponent,
		LandingComponent,
		NavbarComponent,
		SignInComponent,
		GraduadosComponent,
		SignInComponent,
		SignUpComponent,
		ApplicationComponent,
	],
	imports: [BrowserModule, AppRoutingModule, HttpClientModule, FormsModule, ChartsModule],
	providers: [ThemeService],
	bootstrap: [AppComponent],
})
export class AppModule {}
