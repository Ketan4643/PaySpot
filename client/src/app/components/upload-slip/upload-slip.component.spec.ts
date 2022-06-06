import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UploadSlipComponent } from './upload-slip.component';

describe('UploadSlipComponent', () => {
  let component: UploadSlipComponent;
  let fixture: ComponentFixture<UploadSlipComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UploadSlipComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UploadSlipComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
