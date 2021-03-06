import {Injectable} from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})

export class TokenInterceptor implements HttpInterceptor{
    private listNoToken : string[] = ["login", "register", "country"]
    intercept(
        req: HttpRequest<any>,
        next: HttpHandler) : Observable<HttpEvent<any>>
        {
            if(req.url.includes(environment.apiurl) && this.shouldBeIntercepted(req.url)  && localStorage.getItem("id_token") != null)
            {
                req = req.clone({
                    setHeaders : {Authorization : `Bearer ${localStorage.getItem("id_token")}`}
                });
                console.log("Request intercepted, token added");
                
                console.log(req)
                
            }
            return next.handle(req);
        }
    private shouldBeIntercepted(url : string) : boolean{
        for(let item of this.listNoToken){
            if(url.includes(item)){
                console.log(item+" found, interception aborted")
                return false;
            }
        }
        return true;
    }
}