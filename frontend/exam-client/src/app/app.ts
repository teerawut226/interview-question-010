import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ExamService } from './services/exam.service';
import { ExamQuestionResponse, ExamResult } from './models/exam.model';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class AppComponent implements OnInit {
  questions: ExamQuestionResponse[] = [];
  fullname: string = '';
  selectedAnswers: { [questionId: number]: number } = {};
  result: ExamResult | null = null;
  loading: boolean = false;

  constructor(
    private examService: ExamService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.loadQuestions();
  }

  loadQuestions(): void {
    this.examService.getExamQuestions().subscribe({
      next: (data) => {
        this.questions = data;
        this.cdr.detectChanges();
      },
      error: (err) => {
        console.error('Failed to load questions', err);
        alert('ไม่สามารถโหลดข้อมูลข้อสอบได้ กรุณาตรวจสอบ Backend');
      }
    });
  }

  onSubmit(): void {
    if (!this.fullname.trim()) {
      alert('กรุณากรอกชื่อ-นามสกุลก่อนส่งข้อสอบ');
      return;
    }

    const answers = Object.keys(this.selectedAnswers).map(qId => ({
      choiceId: Number(this.selectedAnswers[Number(qId)])
    }));

    if (answers.length !== this.questions.length) {
      alert('กรุณาตอบคำถามให้ครบทุกข้อ');
      return;
    }

    const payload = {
      fullname: this.fullname,
      answers: answers
    };

    this.loading = true;
    this.examService.submitExam(payload).subscribe({
      next: (res) => {
        this.result = res;
        this.loading = false;
        this.cdr.detectChanges();
      },
      error: (err) => {
        console.error('Failed to submit exam', err);
        alert('เกิดข้อผิดพลาดในการส่งข้อสอบ');
        this.loading = false;
        this.cdr.detectChanges();
      }
    });
  }

  // ฟังก์ชันเริ่มทำข้อสอบใหม่
  resetExam(): void {
    this.result = null;
    this.selectedAnswers = {};
    this.fullname = '';
    this.loadQuestions();
    this.cdr.detectChanges();
  }
}