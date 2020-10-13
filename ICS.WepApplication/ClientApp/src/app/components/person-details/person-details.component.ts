import { Component, OnInit, Input } from '@angular/core';
import { Profile, Employee } from '../../contracts/login-data';
import { ProfileDataService } from '../../services/component-providers/profile/profile-data.service';
import { ScientificDataService } from '../../services/component-providers/scientific-info/scientific-data.service';

@Component({
  selector: 'app-person-details',
  templateUrl: './person-details.component.html',
  styleUrls: ['./person-details.component.scss'],
  providers: [ProfileDataService, ScientificDataService]
})

export class PersonDetailsComponent implements OnInit {

  @Input() title: string;
  @Input() profile: Profile;
  @Input() employee: Employee;

  editable: boolean;
  viewMode: boolean;

  constructor(
    private profileDataService: ProfileDataService,
    private scientificDataService: ScientificDataService) {
      this.profile = new Profile();
      this.employee = new Employee();
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

    console.log(this.profile);
    this.profileDataService.setDataById(this.profile, this.profile.id).subscribe(
      response => {
        console.log(response);
      },
      error => {
        console.log(error);
      }
    );

    this.scientificDataService.setDataById(this.employee.scientificInfo, this.employee.id).subscribe(
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
