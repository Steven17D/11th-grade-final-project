#include "DataBase.h"
#include <sstream>

int DataBase::callbackCount(void* NotUse, int argc, char** argv, char** azColName){
	
	return 0;
}

int DataBase::callbackQuestions(void* Questions, int argc, char** argv, char** azColName){
	if (argc != 0){
		vector<Question*>* _users = (vector<Question*>*)Questions;
		_users->push_back(new Question(atoi(argv[0]), argv[1], argv[2], argv[3], argv[4], argv[5]));
		for (int i = 0; i < argc; i++){
			cout << i << ": " << argv[i] << endl;
		}
	}
	return 0;
}

int DataBase::callbackBestScores(void* NotUse, int argc, char** argv, char** azColName){
	
	return 0;
}

int DataBase::callbackPersonalStatus(void* NotUse, int argc, char** argv, char** azColName){
	
	return 0;
}

int DataBase::callbackUsersList(void* users, int argc, char** argv, char** azColName){
	if (argc != 0){
		vector<string>* _users = (vector<string>*)users;
		for (int i = 0; i < argc; i++){
			_users->push_back(string(argv[i]));
		}
	}
	return 0;
}

int DataBase::callbackPassword(void* password, int argc, char** argv, char** azColName){
	if (argc != 0){
		*(string*)password = string(argv[0]);
	}
	return 0;
}


DataBase::DataBase(){
	int rc = sqlite3_open("test.db", &_db);
	if (rc){
		throw exception(sqlite3_errmsg(_db));
	}
}

DataBase::~DataBase(){
	sqlite3_close(_db);
}


bool DataBase::isUserExists(string username){
	vector<string> users;
	int rc = sqlite3_exec(_db, "SELECT username FROM t_users;", callbackUsersList, &users, &_zErrMsg);
	if (rc != SQLITE_OK){
		fprintf(stderr, "SQL error: %s\n", _zErrMsg);
		sqlite3_free(_zErrMsg);
	}
	auto it = find(users.begin(), users.end(), username);
	if (it != users.end()){
		return true;
	}
	else{
		return false;
	}
}

bool DataBase::addNewUser(string username, string password, string email){
	string sql = "INSERT INTO t_users (username,password,email) VALUES ('" + username + "','" + password + "','" + email + "');";
	int rc = sqlite3_exec(_db, sql.c_str(), NULL, NULL, &_zErrMsg);
	if (rc != SQLITE_OK){
		fprintf(stderr, "SQL error: %s\n", _zErrMsg);
		sqlite3_free(_zErrMsg);
		return false;
	}
	return true;
}

bool DataBase::isUserAndPassMatch(string username, string password){
	if (!isUserExists(username)){
		return false;
	}
	string dbPassword;
	string sql = "SELECT password FROM t_users WHERE username = '" + username + "';";
	int rc = sqlite3_exec(_db, sql.c_str(), callbackPassword, &dbPassword, &_zErrMsg);
	if (rc != SQLITE_OK){
		fprintf(stderr, "SQL error: %s\n", _zErrMsg);
		sqlite3_free(_zErrMsg);
	}
	if (password == dbPassword){
		return true;
	}
	else{
		return false;
	}
}


vector<Question*> DataBase::initQuestions(int questionsNo){
	vector<Question*> q;
	string sql = "SELECT * FROM t_questions;";
	int rc = sqlite3_exec(_db, sql.c_str(), callbackQuestions, &q, &_zErrMsg);
	if (rc != SQLITE_OK){
		fprintf(stderr, "SQL error: %s\n", _zErrMsg);
		sqlite3_free(_zErrMsg);
	}
	for (unsigned int i = 0; i < q.size(); i++){
		if (i >= questionsNo){
			delete(q[i]);
		}
	}
	q.resize(questionsNo);
	return q;
}

vector<string> DataBase::getBestScores(){
	vector<string> s;
	//SELECT username FROM t_players_answers GROUP BY username ORDER BY  COUNT(*) DESC LIMIT 3;
	return s;
}

vector<string> DataBase::getPersonalStatus(string username){
	vector<string> s;
	string sql = "SELECT _ FROM _ WHERE ;";
	int rc = sqlite3_exec(_db, sql.c_str(), callbackPersonalStatus, &s, &_zErrMsg);
	if (rc != SQLITE_OK){
		fprintf(stderr, "SQL error: %s\n", _zErrMsg);
		sqlite3_free(_zErrMsg);
	}
	return s;
}


int DataBase::insertNewGame(){
	return 0;
}

bool DataBase::updateGameStatus(int gameId){
	return true;
}

bool DataBase::addAnswerToPlayer(int gameId, string username, int questionId, string answer, bool isCorrect, int answerTime){
	return true;
}
