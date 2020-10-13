import { Component, OnInit, Input } from '@angular/core';
import { Job } from '../../contracts/login-data';
import { JobDataService } from '../../services/component-providers/job/job-data.service';

@Component({
  selector: 'app-job',
  templateUrl: './job.component.html',
  styleUrls: ['./job.component.scss'],
  providers: [JobDataService]
})
export class JobComponent implements OnInit {

  @Input() title: string;
  @Input() employeeId: string;

  editable: boolean;
  viewMode: boolean;

  @Input() job: Job;

  constructor(private jobDataService: JobDataService) {
    this.job = this.job || new Job();
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

    this.jobDataService.setDataById(this.job, this.employeeId).subscribe(
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
