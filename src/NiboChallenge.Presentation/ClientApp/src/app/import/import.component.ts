import { Component, ViewChild } from '@angular/core';
import { HttpClient, HttpRequest, HttpEventType, HttpResponse } from '@angular/common/http';
import { Transaction } from '../../models/transaction';
import { format } from 'util';

@Component({
  selector: 'app-import',
  templateUrl: './import.component.html'
})
export class ImportComponent {
  public progress: number;
  public importedFiles: string[] = [];
  public mergedTransactions: Transaction[];
  public newTransactions: Transaction[];

  private formData: FormData;
  @ViewChild('form')
  private form;

  constructor(private http: HttpClient){}

  upload(files)
  {
      this.formData = new FormData();

      for (let file of files)
          this.formData.append(file.name, file);
      
      const uploadRequest = new HttpRequest('POST', 'api/upload', this.formData, {reportProgress: true});

      this.http.request(uploadRequest).subscribe(event => {
        switch(event.type){
            case HttpEventType.UploadProgress:
                this.progress = Math.round(100 * event.loaded/event.total);
                break;
            case HttpEventType.Response:
                this.mergedTransactions = event.body as Transaction[];
                this.importedFiles = [];
                for (let file of files)
                    this.importedFiles.push(file.name);
                this.checkNewTransactions(this.mergedTransactions);
                break;
        }
      });
  }

  checkNewTransactions(transactions)
  {
    const uploadRequest = new HttpRequest('POST', 'api/Transaction/CheckNewTransactions', this.mergedTransactions);

      this.http.request(uploadRequest).subscribe(event => {
        switch(event.type){
            case HttpEventType.Response:
                this.newTransactions = event.body as Transaction[];
                break;
        }
      });
  }

  save()
  {
    const uploadRequest = new HttpRequest('POST', 'api/Transaction/', this.newTransactions);

      this.http.request(uploadRequest).subscribe(event => {
        switch(event.type){
            case HttpEventType.Response:
                if (event.ok)
                  alert('Dados salvos');
                else
                  alert('Ocorreu um erro ao salvar as transações');
                break;
        }
      });
  }

  cancel()
  {
    this.formData = new FormData();
    this.importedFiles = [];
    this.mergedTransactions = null;
    this.form.nativeElement.reset();
  }
}
