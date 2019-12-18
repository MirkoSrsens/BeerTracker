import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { StartPageComponent } from './start-page/start-page.component';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { ProductionModule } from './production/production.module';

@NgModule({
  declarations: [
    AppComponent,
    StartPageComponent
  ],
  imports: [
    NgbModule,
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot([
      {path: 'startPage', component: StartPageComponent},
      {path: '', component: StartPageComponent},
      {path: '**', component: StartPageComponent}
    ]),
    ProductionModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
