#include "DataBase.h"

int DataBase::callbackCount(void*, int, char**, char**){
	
}

int DataBase::callbackQuestions(void*, int, char**, char**){
	
}

int DataBase::callbackBestScores(void*, int, char**, char**){
	
}

int DataBase::callbackPersonalStatus(void*, int, char**, char**){
	
}


DataBase::DataBase(){
	try{ //db open
		int rc = sqlite3_open("test.db", &_db);
		if (rc)
			throw exception(sqlite3_errmsg(_db));
	}
	catch (exception e){
		cout << e.what();
	}
}

DataBase::~DataBase(){
	//close db
	sqlite3_close(_db);
}


bool DataBase::isUserExists(string username){
	
}

bool DataBase::addNewUser(string username, string password, string email){
	
}

bool DataBase::isUserAndPassMatch(string username, string password){
	
}


vector<Question*> DataBase::initQuestions(int questionsNo){
	
}

vector<string> DataBase::getBestScores(){
	
}

vector<string> DataBase::getPersonalStatus(string){
	
}


int DataBase::insertNewGame(){
	
}

bool DataBase::updateGameStatus(int gameId){
	
}

bool DataBase::addAnswerToPlayer(int gameId, string username, int questionId, string answer, bool isCorrect, int answerTime){
	
}
