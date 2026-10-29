// src/app/services/exam.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ExamQuestionResponse, SubmissionRequest, ExamResult } from '../models/exam.model';

@Injectable({
  providedIn: 'root'
})
export class ExamService {
  private apiUrl = 'http://localhost:5079/api/exams';

  constructor(private http: HttpClient) { }

  getExamQuestions(): Observable<ExamQuestionResponse[]> {
    return this.http.get<ExamQuestionResponse[]>(this.apiUrl);
  }

  submitExam(request: SubmissionRequest): Observable<ExamResult> {
    return this.http.post<ExamResult>(this.apiUrl, request);
  }
}