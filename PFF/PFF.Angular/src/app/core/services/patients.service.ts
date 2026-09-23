import { inject, Service } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { CreatePatientRequest, Patient } from '../../shared/models/patient.model';
import { Observable } from 'rxjs';

@Service()
export class PatientsService {

    private readonly http: HttpClient = inject(HttpClient);
    private readonly baseUrl = `${environment.apiUrl}/patients`;

    create(request: CreatePatientRequest): Observable<Patient> {
        return this.http.post<Patient>(this.baseUrl, request);
    }
}
