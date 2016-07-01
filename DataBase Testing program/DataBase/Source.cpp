#include <iostream>
#include <sstream>
#include "sqlite3.h"
#include <vector>
#include <random>
#include <algorithm> 
#include "DataBase.h"

using namespace std;
class Question{
private:
	string _question;
	string _answers[4];
	int _correctAnswerIndex;
	int _id;
public:
	Question(int, string q, string correctAns, string ans2, string ans3, string ans4);

	string getQuestion();
	string* getAnswers();
	int getCorrectAnswerIndex();
	int getId();
};

int callback(void *ans, int argc, char **argv, char **azColName){
	if (argc != 0){
		vector<Question*>* _users = (vector<Question*>*)ans;
		_users->push_back(new Question(atoi(argv[0]), argv[1], argv[2], argv[3], argv[4], argv[5]));
		for (int i = 0; i < argc; i++){
			cout << i << ": " << argv[i] << endl;
		}
	}
	return 0;
}

int main(){
	try{
		DataBase d;
		//d.addAnswerToPlayer(25, "Steven", 4, "true", true, 3); works
		//d.addNewUser("Steven123", "123654", "Err@ee.ocom");
	}
	catch (exception e){
		cout << e.what() << endl;
	}
	system("pause");
	return 0;
}


Question::Question(int id, string q, string correctAns, string ans2, string ans3, string ans4){
	_id = id;
	_question = q;
	std::default_random_engine generator;
	std::uniform_int_distribution<int> distribution(1, 4);
	vector<string> v = { correctAns, ans2, ans3, ans4 }; //put all the answers in a vector
	std::random_shuffle(v.begin(), v.end()); //randomize the order
	for (unsigned int it = 0; it < v.size(); ++it){
		if (v[it] == correctAns){ //find the correct answer
			_correctAnswerIndex = it;
			it = v.size(); //after finding end loop
		}
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