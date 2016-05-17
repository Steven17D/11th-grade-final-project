#ifndef GAME_H_
#define GAME_H_
#include "User.h"
#include "DataBase.h"
#include "Question.h"
#include <iostream>
#include <vector>
#include <map>
using namespace std;
class User;
class DataBase;
class Game{
private:
	vector<Question*> _questions;
	vector<User*> _players;
	int _questions_no;
	int _currQuestionIndex;
	DataBase& _db;
	map<string, int> _results;
	int _currentTurnAnswers;

	bool insertGameToDB();
	void initQuestionsFromDB();
	void sendQuestionToAllUsers();
public:
	Game(const vector<User*>& users, int questionsNo, DataBase& db);
	~Game();

	void sendFirstQuestion();
	void handleFinishGame();
	bool handleNextTurn();
	bool handleAnswerFromUser(User* u, int answerNo, int time);
	bool leaveGame(User*);
	int getId();
};

#endif