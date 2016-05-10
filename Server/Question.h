#ifndef QUESTION_H_
#define QUESTION_H_
#include <iostream>
using namespace std;
class Question{
private:
	string _question;
	string _answers[4];
	int _correctAnswerIndex;
	int _id;
public:
	Question(int, string q , string correctAns, string ans2, string ans3, string ans4);

	string getQuestion();
	string* getAnswers();
	int getCorrectAnswerIndex();
	int getId();
};

#endif