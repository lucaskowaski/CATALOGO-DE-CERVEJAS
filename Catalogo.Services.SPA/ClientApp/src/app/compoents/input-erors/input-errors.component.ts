import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'input-errors',
  templateUrl: './input-errors.component.html'
})
export class InputErrorsComponent implements OnInit {
  @Input() field: any;
  messages = {
    required: 'Este campo é obrigatório'
  }
  constructor() { }
  ngOnInit() {
  }
}
