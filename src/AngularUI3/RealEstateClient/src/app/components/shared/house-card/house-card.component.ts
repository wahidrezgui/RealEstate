import {Component, Input} from '@angular/core';
import {MatCardModule} from '@angular/material/card'

@Component({
  selector: 'app-house-card',
  templateUrl: './house-card.component.html',
  styleUrls: ['./house-card.component.css']
})

export class HouseCardComponent   {
  @Input() src = '';
  @Input() title='';
}
