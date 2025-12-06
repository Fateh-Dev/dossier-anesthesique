import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface RefItem {
  id: string;
  label: string;
  abreviation: string;
  order: number;
}

export interface RefEntity {
  label: string;
  description: string;
}

@Injectable({
  providedIn: 'root',
})
export class ReferenceService {
  private http = inject(HttpClient);
  private apiUrl = 'http://localhost:5050/api/ReferenceTables';

  // GET all items
  getSpecialites(): Observable<RefItem[]> {
    return this.http.get<RefItem[]>(`${this.apiUrl}/specialites`);
  }

  getTypesAnesthesies(): Observable<RefItem[]> {
    return this.http.get<RefItem[]>(`${this.apiUrl}/typesAnesthesies`);
  }

  getGradesScientifiques(): Observable<RefItem[]> {
    return this.http.get<RefItem[]>(`${this.apiUrl}/gradesScientifiques`);
  }

  getRespirateurs(): Observable<RefItem[]> {
    return this.http.get<RefItem[]>(`${this.apiUrl}/respirateurs`);
  }

  getArmes(): Observable<RefItem[]> {
    return this.http.get<RefItem[]>(`${this.apiUrl}/armes`);
  }

  getAgents(): Observable<RefItem[]> {
    return this.http.get<RefItem[]>(`${this.apiUrl}/agents`);
  }

  getGrades(): Observable<RefItem[]> {
    return this.http.get<RefItem[]>(`${this.apiUrl}/grades`);
  }

  // CREATE items - separate endpoints
  createSpecialite(label: string): Observable<RefItem> {
    return this.http.post<RefItem>(`${this.apiUrl}/specialites`, { label });
  }

  createTypeAnesthesie(label: string): Observable<RefItem> {
    return this.http.post<RefItem>(`${this.apiUrl}/typesAnesthesies`, { label });
  }

  createGradeScientifique(label: string): Observable<RefItem> {
    return this.http.post<RefItem>(`${this.apiUrl}/gradesScientifiques`, { label });
  }

  createRespirateur(label: string): Observable<RefItem> {
    return this.http.post<RefItem>(`${this.apiUrl}/respirateurs`, { label });
  }

  createArme(label: string): Observable<RefItem> {
    return this.http.post<RefItem>(`${this.apiUrl}/armes`, { label });
  }

  createAgent(label: string): Observable<RefItem> {
    return this.http.post<RefItem>(`${this.apiUrl}/agents`, { label });
  }

  createGrade(label: string): Observable<RefItem> {
    return this.http.post<RefItem>(`${this.apiUrl}/grades`, { label });
  }

  // UPDATE item
  updateSpecialite(id: string, item: RefEntity): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/specialites/${id}`, item);
  }

  updateTypeAnesthesie(id: string, item: RefEntity): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/typesAnesthesies/${id}`, item);
  }

  updateGradeScientifique(id: string, item: RefEntity): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/gradesScientifiques/${id}`, item);
  }

  updateRespirateur(id: string, item: RefEntity): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/respirateurs/${id}`, item);
  }

  updateArme(id: string, item: RefEntity): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/armes/${id}`, item);
  }

  updateAgent(id: string, item: RefEntity): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/agents/${id}`, item);
  }

  updateGrade(id: string, item: RefEntity): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/grades/${id}`, item);
  }

  // DELETE items
  deleteSpecialite(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/DeleteSpecialite?Id=${id}`);
  }

  deleteTypeAnesthesie(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/DeleteTypeAnesthesie?Id=${id}`);
  }

  deleteGradeScientifique(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/DeleteGradeScientifique?Id=${id}`);
  }

  deleteRespirateur(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/DeleteRespirateur?Id=${id}`);
  }

  deleteArme(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/DeleteArme?Id=${id}`);
  }

  deleteAgent(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/DeleteAgents?Id=${id}`);
  }

  deleteGrade(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/DeleteGrade?Id=${id}`);
  }
}
