import { TestBed } from '@angular/core/testing';

import { ExcelPaste } from './excel-paste';

describe('ExcelPaste', () => {
  let service: ExcelPaste;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ExcelPaste);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
