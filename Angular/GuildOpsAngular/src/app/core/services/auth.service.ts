import { inject, Service } from '@angular/core';
import { ResgisterPlayerRequest } from '../../shared/models/auth.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Service()
export class AuthService {

    private readonly http = inject(HttpClient);
    private readonly baseUrl = environment.apiUrl;

    register(request: ResgisterPlayerRequest): Observable<unknown> {
        return this.http.post(`${environment.apiUrl}/players`, request);
    }
}
