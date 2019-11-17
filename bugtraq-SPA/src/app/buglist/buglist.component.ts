import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-buglist',
  templateUrl: './buglist.component.html',
  styleUrls: ['./buglist.component.css']
})
export class BuglistComponent implements OnInit {
  buglist: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getBugList();
  }

  getBugList() {
    this.http.get('http://localhost:5000/api/buglist').subscribe(response =>{
      this.buglist = response;
    }, error => {
      console.log(error);
    });
  }

}
