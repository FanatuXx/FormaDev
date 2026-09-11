import { inject, Service } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { CreatePatientRequest } from '../../shared/models/patient.model';
import { Observable } from 'rxjs';

@Service()
export class PatientsService {

    private readonly http = inject(HttpClient);
    private readonly baseUrl = environment.apiUrl + "/patients";

    createPatient(request: CreatePatientRequest): Observable<unknown> {
        return this.http.post(`${environment.apiUrl}/patients`, request);
    }
}
