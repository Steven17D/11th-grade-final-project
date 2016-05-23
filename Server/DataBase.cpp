#include "DataBase.h"
#include <sstream>

int DataBase::callbackCount(void* NotUse, int argc, char** argv, char** azColName){
	
}

int DataBase::callbackQuestions(void* NotUse, int argc, char** argv, char** azColName){
	
}

int DataBase::callbackBestScores(void* NotUse, int argc, char** argv, char** azColName){
	
}

int DataBase::callbackPersonalStatus(void* NotUse, int argc, char** argv, char** azColName){
	
}

int DataBase::callbackUsersList(void* users, int argc, char** argv, char** azColName){
	if (argc != 1){
		vector<string> _users;
		for (int i = 0; i < argc; i++){
			_users.push_back(string(argv[i]));
		}
		*(vector<string>*)users = _users;
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
	for (unsigned int i = 0; i < users.size(); i++){
		cout << to_string(i + 1) << ": " + users[i] << endl;
	}
	return true;//??
}

bool DataBase::addNewUser(string username, string password, string email){
	int rc = sqlite3_exec(_db, "INSERT INTO t_users", NULL, NULL, &_zErrMsg);
	if (rc != SQLITE_OK){
		fprintf(stderr, "SQL error: %s\n", _zErrMsg);
		sqlite3_free(_zErrMsg);
	}
	return true;
}

bool DataBase::isUserAndPassMatch(string username, string password){
	string sql = "SELECT * FROM t_users WHERE username = '" + username + "';";
	int rc = sqlite3_exec(_db, sql.c_str(), NULL, NULL, &_zErrMsg);
	if (rc != SQLITE_OK){
		fprintf(stderr, "SQL error: %s\n", _zErrMsg);
		sqlite3_free(_zErrMsg);
	}
	return true;
}


vector<Question*> DataBase::initQuestions(int questionsNo){
	return true;
}

vector<string> DataBase::getBestScores(){
	return true;
}

vector<string> DataBase::getPersonalStatus(string username){
	return true;
}


int DataBase::insertNewGame(){
	return 1;
}

bool DataBase::updateGameStatus(int gameId){
	return true;
}

bool DataBase::addAnswerToPlayer(int gameId, string username, int questionId, string answer, bool isCorrect, int answerTime){
	return true;
}
