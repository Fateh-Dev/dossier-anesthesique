import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Medecin {
  id?: string;
  nom: string;
  prenom: string;
  matricule: string;
  sexe?: string;
  specialite?: string;
  gradeScientifique?: string;
  numeroTel?: string;
  dateNaissance?: string;
  // properties from backend entity
  nationnalite?: string;
  numeroTel2?: string;
  gradeActuel?: string;
  observation?: string;
}

export interface PagedResultDto<T> {
  totalCount: number;
  items: T[];
}

export interface MedecinQuery {
  matricule?: string;
  nom?: string;
  sexe?: string;
  specialite?: string;
  gradeScientifique?: string;
  nationnalite?: string;
  sorting?: string;
  skipCount: number;
  maxResultCount: number;
}

@Injectable({
  providedIn: 'root',
})
export class MedecinService {
  private http = inject(HttpClient);
  // Using 5050 to match AuthService
  private apiUrl = 'http://localhost:5050/api/Medecin';

  getAllMedecinsFilter(query: MedecinQuery): Observable<PagedResultDto<Medecin>> {
    return this.http.post<PagedResultDto<Medecin>>(`${this.apiUrl}/Get_All_Medecins_Filter`, query);
  }

  getMedecinById(id: string): Observable<Medecin> {
    return this.http.get<Medecin>(`${this.apiUrl}/Get_Medecin_ById?id=${id}`);
  }

  createMedecin(medecin: Medecin): Observable<string> {
    return this.http.post(`${this.apiUrl}/Create_Medecin`, medecin, { responseType: 'text' });
  }

  updateMedecin(medecin: Medecin): Observable<string> {
    return this.http.put(`${this.apiUrl}/Update_Medecin`, medecin, { responseType: 'text' });
  }

  deleteMedecin(id: string): Observable<string> {
    return this.http.delete(`${this.apiUrl}/Delete_Medecin_ById?idMedecin=${id}`, {
      responseType: 'text',
    });
  }
}
