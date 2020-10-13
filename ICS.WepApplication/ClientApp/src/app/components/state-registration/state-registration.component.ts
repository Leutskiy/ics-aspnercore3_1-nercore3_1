import { Component, OnInit, Input } from '@angular/core';
import { StateRegistration } from '../../contracts/login-data';
import { StateRegistrationDataService } from '../../services/component-providers/state-registration/state-registration-data.service';

@Component({
  selector: 'app-state-registration',
  templateUrl: './state-registration.component.html',
  styleUrls: ['./state-registration.component.scss'],
  providers: [StateRegistrationDataService]
})
export class StateRegistrationComponent implements OnInit {

  @Input() title: string;

  editable: boolean;
  viewMode: boolean;

  @Input() stateRegistration: StateRegistration;

  constructor(private stateRegistrationDataService: StateRegistrationDataService) {
    this.stateRegistration = this.stateRegistration || new StateRegistration();
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

    this.stateRegistrationDataService.setDataById(this.stateRegistration, this.stateRegistration.id).subscribe(
      response => {
        console.log(response);
      },
      error => {
        console.log(error);
      }
    );
  }

  viewDetails() {
    this.viewMode = !this.viewMode;

    if (!this.viewMode) {
      this.reset();
    }
  }

  private reset() {
    this.ngOnInit();
  }

}
