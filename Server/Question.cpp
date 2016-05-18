#include "Question.h"
#include <random>
#include <algorithm> 

Question::Question(int id, string q, string correctAns, string ans2, string ans3, string ans4){
	_id = id;
	_question = q;
	std::default_random_engine generator;
	std::uniform_int_distribution<int> distribution(1, 4);
	vector<string> v = { correctAns, ans2, ans3, ans4 };
	std::random_shuffle(v.begin(), v.end());
	for (std::vector<string>::iterator it = v.begin() , int i = 0; it != v.end(); ++it , i++){
		if (*it == correctAns){
			_correctAnswerIndex = i;
		}
	}
}


string Question::getQuestion(){
	return _question;
}

string* Question::getAnswers(){
	return _answers;
}

int Question::getCorrectAnswerIndex(){
	return _correctAnswerIndex;
}

int Question::getId(){
	return _id;
}
