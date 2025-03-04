import { bootstrapApplication } from '@angular/platform-browser';
import { AppHomeComponent } from './app/Home/app.HomeComponent';  // Corrigido para o caminho correto

// Inicializando a aplicação com o componente standalone
bootstrapApplication(AppHomeComponent, {
  providers: [
    
  ]
}).catch(err => console.error(err));
