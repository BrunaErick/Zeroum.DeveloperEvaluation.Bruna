import { bootstrapApplication } from '@angular/platform-browser';
import { AppHomeComponent } from './app/Home/app.HomeComponent';
import { config } from './app/app.config.server';

const bootstrap = () => bootstrapApplication(AppHomeComponent, config);

export default bootstrap;
