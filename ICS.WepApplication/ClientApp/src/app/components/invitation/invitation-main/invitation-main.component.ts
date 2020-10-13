import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-invitation-main',
  templateUrl: './invitation-main.component.html',
  styleUrls: ['./invitation-main.component.scss']
})
export class InvitationMainComponent implements OnInit {

  alienPersonDetailsTitle: string = "Личные данные приглашенного";
  alienPasportDetailsTitle: string = "Паспортные данные приглашенного";
  alienContactDetailsTitle: string = "Контактные данные приглашенного";
  alienOrganizationTitle: string = "Оргагизация приглашенного";
  alienWorkPlaceTitle: string = "Место работы приглашенного";
  alienStateRegistrationTitle: string = "Госудраственная регистрация приглашенного";

  constructor() { }

  ngOnInit(): void {
  }

}
