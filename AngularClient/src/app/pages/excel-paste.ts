// excel-paste.service.ts
import { Injectable } from '@angular/core';

const STORAGE_KEY = 'excelRows';
@Injectable({ providedIn: 'root' })
export class ExcelPasteService {
  private rows: string[][] = [];
  constructor() {
    this.loadFromStorage();
  }
  /** Charger les lignes collées */
  load(text: string) {
    this.rows = text
      .trim()
      .split('\n')
      .map((line) => line.split('\t').map((col) => col.trim()));
    this.saveToStorage();
  }

  /** Récupérer et supprimer la première ligne */
  popNext(): string[] | null {
    var row = this.rows.length > 0 ? this.rows.shift()! : null;
    this.saveToStorage();
    return row;
  }

  /** Voir la prochaine ligne sans la retirer */
  peekNext(): string[] | null {
    return this.rows.length > 0 ? this.rows[0] : null;
  }

  /** Nombre de lignes restantes */
  remaining(): number {
    return this.rows.length;
  }

  /** Réinitialiser */
  reset() {
    this.rows = [];
    localStorage.removeItem(STORAGE_KEY);
  }
  /** Sauvegarder dans localStorage */
  private saveToStorage() {
    localStorage.setItem(STORAGE_KEY, JSON.stringify(this.rows));
  }

  /** Charger depuis localStorage */
  private loadFromStorage() {
    const data = localStorage.getItem(STORAGE_KEY);
    this.rows = data ? JSON.parse(data) : [];
  }
  isEmpty(): boolean {
    return this.rows.length === 0;
  }
}
