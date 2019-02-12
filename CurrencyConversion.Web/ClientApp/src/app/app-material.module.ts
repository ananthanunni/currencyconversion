import { NgModule } from "@angular/core";
import { MatButtonModule, MatSelectModule, MatProgressSpinnerModule, MatIconModule, MatInputModule, MatCardModule} from "@angular/material";

const materialComponents = [
  MatButtonModule, MatProgressSpinnerModule, MatSelectModule, MatIconModule, MatInputModule, MatCardModule
];
@NgModule(
  {
    imports: materialComponents,
    exports:materialComponents
  }
)
export class AppMaterialModule {

}
