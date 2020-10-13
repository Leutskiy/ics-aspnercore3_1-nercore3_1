import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { SigninComponent } from './components/signin/signin.component';
import { ProfileComponent } from './components/profile/profile.component';
import { JobComponent } from './components/job/job.component';
import { StateRegistrationComponent } from './components/state-registration/state-registration.component';
import { OrganizationComponent } from './components/organization/organization.component';
import { PassportComponent } from './components/passport/passport.component';
import { ContactDetailsComponent } from './components/contact-details/contact-details.component';
import { PersonDetailsComponent } from './components/person-details/person-details.component';
import { MainComponent } from './components/main/main.component';
import { InvitationComponent } from './components/invitation/invitation.component';
import { InvitationMainComponent } from './components/invitation/invitation-main/invitation-main.component';
import { AuthService } from './services/auth.service';
import { SingupService } from './services/singup.service';
import { HttpClientModule } from '@angular/common/http';
import { NotFoundPageComponent } from './components/pages/not-found-page/not-found-page.component';
import { APP_CONFIG, AppConfig } from './settings/app-config';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptor } from './interceptors/token.interceptor';
import { LoadingScreenInterceptor } from './interceptors/loading-screen/loading-screen.interceptor';
import { SingupComponent } from './components/singup/singup.component';
import { NgbdDatepickerAdapterModule } from './modules/adapters/datepicker-adapter.module';
import { LoadingScreenComponent } from './components/loading-screen/loading-screen.component';
import { FileUploadComponent } from './components/file-upload/file-upload.component';
import { AlienComponent } from './components/invitation/alien/alien.component';

@NgModule({
  declarations: [
    AppComponent,
    SigninComponent,
    ProfileComponent,
    JobComponent,
    StateRegistrationComponent,
    OrganizationComponent,
    PassportComponent,
    ContactDetailsComponent,
    PersonDetailsComponent,
    MainComponent,
    InvitationComponent,
    InvitationMainComponent,
    HeaderComponent,
    NotFoundPageComponent,
    SingupComponent,
    LoadingScreenComponent,
    FileUploadComponent,
    AlienComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    HttpClientModule,
    NgbdDatepickerAdapterModule,
    CommonModule,
    ReactiveFormsModule
  ],
  providers: [
    AuthService,
    SingupService,
    {
      provide: APP_CONFIG,
      useValue: AppConfig
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: LoadingScreenInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
