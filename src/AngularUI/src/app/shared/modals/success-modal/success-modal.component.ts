import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-success-modal',
  templateUrl: './success-modal.component.html',
  styleUrls: ['./success-modal.component.css', '../modal-shared.component.css']
})
export class SuccessModalComponent implements OnInit {

  @Input() public modalHeaderText!: string;
  @Input() public modalBodyText!: string;
  @Input() public okButtonText!: string;
  @Output() public redirectOnOK = new EventEmitter();
  constructor() { }

  ngOnInit(): void {
  }

  public emitEvent = () => {
    this.redirectOnOK.emit();
  }
}
