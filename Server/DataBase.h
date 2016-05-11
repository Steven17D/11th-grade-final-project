#ifndef DATABASE_H_
#define DATABASE_H_
#include "Question.h"
#include <iostream>
#include <vector>
#include "sqlite3.h"
using namespace std;
class DataBase{
private:
	sqlite3* _db;

	static int callbackCount(void*, int, char**, char**);
	static int callbackQuestions(void*, int, char**, char**);
	static int callbackBestScores(void*, int, char**, char**);
	static int callbackPersonalStatus(void*, int, char**, char**);

public:
	DataBase();
	~DataBase();

	bool isUserExists(string username);
	bool addNewUser(string username, string password, string email);
	bool isUserAndPassMatch(string username, string password);
	vector<Question*> initQuestions(int questionsNo);
	vector<string> getBestScores();
	vector<string> getPersonalStatus(string);
	int insertNewGame();
	bool updateGameStatus(int gameId);
	bool addAnswerToPlayer(int gameId, string username, int questionId, string answer, bool isCorrect, int answerTime);
};

#endif