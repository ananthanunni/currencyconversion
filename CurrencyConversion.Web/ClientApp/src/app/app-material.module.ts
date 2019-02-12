import { NgModule } from "@angular/core";
import { MatButtonModule, MatSelectModule, MatProgressSpinnerModule, MatIconModule, MatInputModule} from "@angular/material";

const materialComponents = [
  MatButtonModule, MatProgressSpinnerModule, MatSelectModule, MatIconModule, MatInputModule
];
@NgModule(
  {
    imports: materialComponents,
    exports:materialComponents
  }
)
export class AppMaterialModule {

}
