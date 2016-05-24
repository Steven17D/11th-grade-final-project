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
	if (argc != 0){
		vector<string>* _users = (vector<string>*)users;
		for (int i = 0; i < argc; i++){
			_users->push_back(string(argv[i]));
		}
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
	vector<string>* users = new vector<string>;
	int rc = sqlite3_exec(_db, "SELECT username FROM t_users;", callbackUsersList, users, &_zErrMsg);
	if (rc != SQLITE_OK){
		fprintf(stderr, "SQL error: %s\n", _zErrMsg);
		sqlite3_free(_zErrMsg);
	}
	auto it = find(users->begin(), users->end(), username);
	if (it != users->end()){
		return true;
	}
	else{
		return false;
	}
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
	
}

vector<string> DataBase::getBestScores(){
	
}

vector<string> DataBase::getPersonalStatus(string username){
	
}


int DataBase::insertNewGame(){
	
}

bool DataBase::updateGameStatus(int gameId){
	
}

bool DataBase::addAnswerToPlayer(int gameId, string username, int questionId, string answer, bool isCorrect, int answerTime){
	
}
