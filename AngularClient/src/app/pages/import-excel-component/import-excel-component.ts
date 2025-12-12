// import-excel.component.ts
import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExcelPasteService } from '../excel-paste';

@Component({
  selector: 'app-import-excel',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './import-excel-component.html',
  styleUrls: ['./import-excel-component.css'],
})
export class ImportExcelComponent {
  @Output() ready = new EventEmitter<void>();

  imported = false;
  nextRow: string[] | null = null;
  remaining = 0;

  constructor(private excel: ExcelPasteService) {
    this.imported = this.excel.remaining() > 0 ? true : false;
    this.nextRow = this.excel.peekNext();
    this.remaining = this.excel.remaining();
  }

  onPaste(event: ClipboardEvent) {
    const text = event.clipboardData?.getData('text')?.trim() ?? '';

    if (!text) {
      // NE PAS PASSER EN MODE imported
      return;
    }

    this.excel.load(text);
    this.imported = true;
    this.refreshInfo();
    this.ready.emit();
  }

  refreshInfo() {
    this.nextRow = this.excel.peekNext();
    this.remaining = this.excel.remaining();
  }

  reset() {
    this.excel.reset();
    this.imported = false;
    this.nextRow = null;
    this.remaining = 0;
  }
}
