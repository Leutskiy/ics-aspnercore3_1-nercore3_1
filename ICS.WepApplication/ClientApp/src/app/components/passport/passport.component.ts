import { Component, OnInit, Input } from '@angular/core';
import { Passport, Gender } from '../../contracts/login-data';
import { PassportDataService } from '../../services/component-providers/passport/passport-data.service';

@Component({
  selector: 'app-passport',
  templateUrl: './passport.component.html',
  styleUrls: ['./passport.component.scss'],
  providers: [PassportDataService]
})
export class PassportComponent implements OnInit {

  @Input() title: string;
  @Input() passport: Passport;

  editable: boolean;
  viewMode: boolean;

  constructor(
    private passportDataService: PassportDataService) {
      this.passport = new Passport();
  }

  ngOnInit(): void {
    this.viewMode = false;
    this.editable = false;
  }

  editDetails() {
    this.editable = !this.editable;
  }

  saveDetails() {
    this.editable = !this.editable;

    this.passport.birthDate = this.formatterToModel(this.passport.birthDate);
    this.passport.issueDate = this.formatterToModel(this.passport.issueDate);

    this.passportDataService.setDataById(this.passport, this.passport.id).subscribe(
      addedPassportId => {
        console.log(addedPassportId);
      },
      error => {
        console.log(error);
      }
    );
  }

  formatterToModel(model: Date | string | null): Date | null {
    if (model instanceof Date) {
      return model;

    }
    else if (model) {
      return new Date(this.parse(model));
    }
    else {
      return null;
    }
  }

  private parse(value: string): string {
    if (value) {
      let date = value.split(".");
      return date[2] + "-" + date[1] + "-" + date[0];
    }
    return null;
  }

  viewDetails() {
    this.viewMode = !this.viewMode;

    if (!this.viewMode) {
      this.reset();
    }
  }

  clearGender(): void {
    console.log(this.passport.gender);
    this.passport.gender = null;
  }

  private reset() {
    this.ngOnInit();
  }

}
