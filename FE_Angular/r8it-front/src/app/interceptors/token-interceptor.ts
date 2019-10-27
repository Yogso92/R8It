import {Injectable} from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})

export class TokenInterceptor implements HttpInterceptor{
    private listNoToken : string[] = ["login", "register", "category", "country"]
    intercept(
        req: HttpRequest<any>,
        next: HttpHandler) : Observable<HttpEvent<any>>
        {
            if(req.url.includes(environment.apiurl) && !this.shouldBeIntercepted(req.url)  && localStorage.getItem("id_token"))
            {
                req = req.clone({
                    setHeaders : {Authorization : `Bearer ${localStorage.getItem("id_token")}`}
                });
                
            }
            console.log(req)
            return next.handle(req);
        }
    private shouldBeIntercepted(url : string){
        for(let item of this.listNoToken){
            if(url.includes(item)){
                return true;
            }
        }
        return false;
    }
}