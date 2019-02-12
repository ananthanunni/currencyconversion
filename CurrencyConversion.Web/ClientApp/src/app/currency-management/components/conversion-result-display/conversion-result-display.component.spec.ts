import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConversionResultDisplayComponent } from './conversion-result-display.component';

describe('ConversionResultDisplayComponent', () => {
  let component: ConversionResultDisplayComponent;
  let fixture: ComponentFixture<ConversionResultDisplayComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConversionResultDisplayComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConversionResultDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
