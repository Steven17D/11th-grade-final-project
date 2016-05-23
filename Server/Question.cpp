#include "Question.h"
#include <random>
#include <algorithm> 

Question::Question(int id, string q, string correctAns, string ans2, string ans3, string ans4){
	_id = id;
	_question = q;
	std::default_random_engine generator;
	std::uniform_int_distribution<int> distribution(1, 4);
	vector<string> v = { correctAns, ans2, ans3, ans4 }; //put all the answers in a vector
	std::random_shuffle(v.begin(), v.end()); //randomize the order
	int i = 0;
	for (std::vector<string>::iterator it = v.begin(); it != v.end(); ++it){
		if (*it == correctAns){ //find the correct answer
			_correctAnswerIndex = i;
			it = v.end(); //after finding end loop
		}
		i++;
	}
	std::copy(v.begin(), v.end(), _answers);
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
