import { Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { LayoutComponent } from './layout/layout.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { PatientsComponent } from './pages/patients/patients.component';
import { InterventionsComponent } from './pages/interventions/interventions.component';
import { DossiersComponent } from './pages/dossiers/dossiers.component';
import { StatistiquesComponent } from './pages/statistiques/statistiques.component';
import { ParametresComponent } from './pages/parametres/parametres.component';
import { ProfilComponent } from './pages/profil/profil.component';
import { MedecinsComponent } from './pages/medecins/medecins.component';
import { authGuard } from './guards/auth.guard';

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  {
    path: '',
    component: LayoutComponent,
    canActivate: [authGuard],
    children: [
      { path: '', component: DashboardComponent },
      { path: 'patients', component: PatientsComponent },
      { path: 'medecins', component: MedecinsComponent },
      { path: 'interventions', component: InterventionsComponent },
      { path: 'dossiers', component: DossiersComponent },
      { path: 'statistiques', component: StatistiquesComponent },
      { path: 'parametres', component: ParametresComponent },
      { path: 'profil', component: ProfilComponent },
    ],
  },
];
