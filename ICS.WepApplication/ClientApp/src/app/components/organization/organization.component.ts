import { Component, OnInit, Input } from '@angular/core';
import { Organization } from '../../contracts/login-data';
import { OrganizationDataService } from '../../services/component-providers/organization/organization-data.service';

@Component({
  selector: 'app-organization',
  templateUrl: './organization.component.html',
  styleUrls: ['./organization.component.scss'],
  providers: [OrganizationDataService]
})
export class OrganizationComponent implements OnInit {

  @Input() title: string;

  editable: boolean;
  viewMode: boolean;

  @Input() organization: Organization;

  constructor(private organizationDataService: OrganizationDataService) {
    this.organization = this.organization || new Organization();
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

    this.organizationDataService.setDataById(this.organization, this.organization.id).subscribe(
      addedOrganizationId => {
        console.log(addedOrganizationId);
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
