import {Injectable} from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})

export class TokenInterceptor implements HttpInterceptor{
    intercept(
        req: HttpRequest<any>,
        next: HttpHandler) : Observable<HttpEvent<any>>
        {
            if(req.url.includes(environment.apiurl) && !req.url.includes("login") && localStorage.getItem("id_token"))
            {
                req = req.clone({
                    setHeaders : {Authorization : `Bearer ${localStorage.getItem("id_token")}`}
                });
                
            }
            console.log(req)
            return next.handle(req);
        }
}