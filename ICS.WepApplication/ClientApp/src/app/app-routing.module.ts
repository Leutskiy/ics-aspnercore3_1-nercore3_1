import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SigninComponent } from './components/signin/signin.component';
import { SingupComponent } from './components/singup/singup.component';
import { ProfileComponent } from './components/profile/profile.component';
import { MainComponent } from './components/main/main.component';
import { NotFoundPageComponent } from './components/pages/not-found-page/not-found-page.component';
import { InvitationComponent } from './components/invitation/invitation.component';
import { InvitationMainComponent } from './components/invitation/invitation-main/invitation-main.component';
import { AuthGuard } from './auth/auth.guard';
import { RedirectToProfileGuard } from './auth/redirect-to-profile.guard';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
  },
  {
    path: 'logout',
    redirectTo: 'login',
    pathMatch: 'full'
  },
  { path: 'login', component: SigninComponent, canActivate: [RedirectToProfileGuard]  },
  { path: 'singup', component: SingupComponent },
  { path: 'profile/:profileId/employee/:employeeId', component: ProfileComponent, canActivate: [AuthGuard] },
  { path: 'profile/:profileId/employee/:employeeId/information', component: MainComponent, canActivate: [AuthGuard] },
  { path: 'invitation', component: InvitationComponent, canActivate: [AuthGuard] },
  { path: 'invitation/details', component: InvitationMainComponent, canActivate: [AuthGuard] },
  { path: '**', component: NotFoundPageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [AuthGuard, RedirectToProfileGuard]
})
export class AppRoutingModule { }
