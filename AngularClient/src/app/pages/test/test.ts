import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { ExcelPasteService } from '../excel-paste';
import { ImportExcelComponent } from '../import-excel-component/import-excel-component';

@Component({
  selector: 'app-test',
  imports: [ReactiveFormsModule, ImportExcelComponent],
  templateUrl: './test.html',
  styleUrl: './test.scss',
})
export class TestPage implements OnInit {
  @ViewChild(ImportExcelComponent) importComp!: ImportExcelComponent;

  form!: FormGroup;

  constructor(private fb: FormBuilder, private excel: ExcelPasteService) {}
  grades = [
    { id: 1, label: 'Active' },
    { id: 2, label: 'Pending' },
    { id: 3, label: 'Suspended' },
  ];

  mapGradeFromExcel(label: string) {
    const item = this.grades.find((s) => s.label.toLowerCase() === label.toLowerCase());
    return item ? item.id : null;
  }

  ngOnInit() {
    this.form = this.fb.group({
      name: [''],
      email: [''],
      grade: [''],
      phone: [''],
    }); // Si localStorage contient déjà des lignes, charger la première
    if (!this.excel.isEmpty()) {
      this.loadNextRow();
    }
  }

  /** Remplit le formulaire depuis la prochaine ligne */
  loadNextRow() {
    const row = this.excel.peekNext();
    if (!row) {
      this.form.reset();
      return;
    }
    this.form.patchValue({
      name: row[0],
      email: row[1],
      grade: this.mapGradeFromExcel(row[2]),
      phone: row[3],
    });
  }

  /** Soumission = suppression de la ligne + passage à la suivante */
  submit() {
    console.log('Envoi :', this.form.value);

    this.excel.popNext(); // supprimer la ligne utilisée

    this.importComp.refreshInfo(); // mettre à jour l’affichage

    this.loadNextRow(); // remplir avec la nouvelle ligne
  }

  onImportReady() {
    this.loadNextRow();
  }
}
