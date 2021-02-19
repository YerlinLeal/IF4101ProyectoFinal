import { Component, OnInit } from '@angular/core';
import {FormControl} from '@angular/forms'

@Component({
  selector: 'app-select-services',
  templateUrl: './select-services.component.html',
  styleUrls: ['./select-services.component.css']
})
export class SelectServicesComponent implements OnInit {

  services = new FormControl();
  servicesList: string[] = ['Telefonía Fija', 'Telefonía Movil', 'Cable', 'Internet'];
  constructor() { }

  ngOnInit(): void {
  }

}
