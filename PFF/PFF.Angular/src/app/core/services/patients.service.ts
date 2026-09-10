import { inject, Service } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Service()
export class PatientsService {

    private readonly http = inject(HttpClient);
    private readonly baseUrl = environment.apiUrl + "/patients";


}
