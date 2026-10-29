// src/app/models/exam.model.ts
export interface ChoiceResponse {
  id: number;
  text: string;
}

export interface ExamQuestionResponse {
  id: number;
  title: string;
  choices: ChoiceResponse[];
}

export interface SubmissionRequest {
  fullname: string;
  answers: { choiceId: number }[];
}

export interface ExamResult {
  id: number;
  fullName: string;
  score: number;
  totalScore: number;
  submittedAt: string;
}