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
import { PersonDetailsComponent } from './components/person-details/person-details.component';
import { MainComponent } from './components/main/main.component';
import { InvitationComponent } from './components/invitation/invitation.component';
import { NewInvitationFormComponent } from './components/invitation/new-form/new-invitation-form.component';
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
import { EmployeePassportComponent } from './components/passport/employee-passport.component';
import { AlienPassportInvitationComponent } from './components/passport/alien-passport-invitation.component';
import { EmployeeOrganizationComponent } from './components/organization/employee-organization.component';
import { AlienOrganizationInvitationComponent } from './components/organization/alien-organization-invitation.component';
import { AlienJobInvitationComponent } from './components/job/alien-job-invitation.component';
import { EmployeeJobComponent } from './components/job/employee-job.component';
import { AlienContactsInvitationComponent } from './components/contacts/alien-contacts-invitation.component';
import { EmployeeContactsComponent } from './components/contacts/employee-contacts.component';
import { EmployeeStateRegistrationComponent } from './components/state-registration/employee-state-registration.component';
import { AlienStateRegistrationInvitationComponent } from './components/state-registration/alien-state-registration-invitation.component';
import { VisitDetailsInvitationComponent } from './components/visit-details/visit-details.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    SigninComponent,
    SingupComponent,

    PersonDetailsComponent,
    EmployeeJobComponent,
    EmployeePassportComponent,
    EmployeeContactsComponent,
    EmployeeOrganizationComponent,
    EmployeeStateRegistrationComponent,
    AlienJobInvitationComponent,
    AlienPassportInvitationComponent,
    AlienContactsInvitationComponent,
    AlienOrganizationInvitationComponent,
    AlienStateRegistrationInvitationComponent,
    MainComponent,
    ProfileComponent,
    NewInvitationFormComponent,
    InvitationComponent,

    NotFoundPageComponent,
    FileUploadComponent,
    LoadingScreenComponent,
    VisitDetailsInvitationComponent,
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
