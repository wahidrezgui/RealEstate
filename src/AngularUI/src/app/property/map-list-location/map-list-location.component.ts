import { Component, OnInit } from '@angular/core';
import * as L from 'leaflet';
@Component({
  selector: 'app-map-list-location',
  templateUrl: './map-list-location.component.html',
  styleUrls: ['./map-list-location.component.css']
})
export class MapListLocationComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    if (!navigator.geolocation) {
      console.log('geo not supported')
    }
    else {
      navigator.geolocation.getCurrentPosition((position) => {
        const coord = position.coords;

        let mymap = L.map('map').setView([coord.latitude, coord.longitude], 17);
        L.tileLayer(
          'https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token=pk.eyJ1Ijoid2FoaWRyZXpndWkiLCJhIjoiY2wxYjJ2aWdnMDRodDNqbDV1b2lmenY0NiJ9.9R1Qg7cZIi6qhQtwEPo1cg',
          {
            attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
            maxZoom: 18,
            id: 'mapbox/streets-v11',
            tileSize: 512,
            zoomOffset: -1,
            accessToken: 'pk.eyJ1Ijoid2FoaWRyZXpndWkiLCJhIjoiY2wxYjJ2aWdnMDRodDNqbDV1b2lmenY0NiJ9.9R1Qg7cZIi6qhQtwEPo1cg'
          }).addTo(mymap);

        var marker = L.marker([coord.latitude, coord.longitude]).addTo(mymap);
        marker.bindPopup('<b>Home</b>').openPopup();
        var circle = L.circle([coord.latitude, coord.longitude], {
          color: 'red',
          fillColor: '#f03',
          fillOpacity: 0.5,
          radius: 100
        }).addTo(mymap);
      }

      )


    }
  }

}
