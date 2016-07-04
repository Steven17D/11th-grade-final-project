#include "DataBase.h"
#include "Helper.h"
#include <sstream>
#include <time.h>

int DataBase::callbackCount(void* NotUse, int argc, char** argv, char** azColName){
	
	return 0;
}

int DataBase::callbackQuestions(void* Questions, int argc, char** argv, char** azColName){
	if (argc != 0){
		vector<Question*>* _users = (vector<Question*>*)Questions;
		_users->push_back(new Question(atoi(argv[0]), argv[1], argv[2], argv[3], argv[4], argv[5]));
	}
	return 0;
}

int DataBase::callbackBestScores(void* usersAndScores, int argc, char** argv, char** azColName){
	if (argc != 0){
		vector<string>* _usersAndScores = (vector<string>*)usersAndScores;
		_usersAndScores->push_back(argv[0]);
		_usersAndScores->push_back(argv[1]);
	}
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
	int rc = sqlite3_open("trivia.db", &_db);
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
	string sql = "SELECT username, COUNT(*) FROM t_players_answers GROUP BY username ORDER BY COUNT(*) DESC LIMIT 3 ;";
	int rc = sqlite3_exec(_db, sql.c_str(), callbackBestScores, &s, &_zErrMsg);
	if (rc != SQLITE_OK){
		fprintf(stderr, "SQL error: %s\n", _zErrMsg);
		sqlite3_free(_zErrMsg);
	}
	return s;
}

vector<string> DataBase::getPersonalStatus(string username){
	vector<string> s;
	string games_count;
	string sql = "SELECT COUNT(game_id) FROM(SELECT game_id FROM t_players_answers WHERE username = '" + username + "' GROUP BY game_id);";
	int rc = sqlite3_exec(_db, sql.c_str(), callbackPassword, &games_count, &_zErrMsg);
	if (rc != SQLITE_OK){
		fprintf(stderr, "SQL error: %s\n", _zErrMsg);
		sqlite3_free(_zErrMsg);
	}
	s.push_back(Helper::getPaddedNumber(atoi(games_count.c_str()), 4));//number of games
	string correct_ans;
	sql = "SELECT SUM(is_correct) FROM t_players_answers WHERE username ='" + username + "';";
	rc = sqlite3_exec(_db, sql.c_str(), callbackPassword, &correct_ans, &_zErrMsg);
	if (rc != SQLITE_OK){
		fprintf(stderr, "SQL error: %s\n", _zErrMsg);
		sqlite3_free(_zErrMsg);
	}
	s.push_back(Helper::getPaddedNumber(atoi(correct_ans.c_str()), 6));
	string num_of_ans;
	sql = "SELECT COUNT(username) FROM t_players_answers WHERE username ='" + username + "';";
	rc = sqlite3_exec(_db, sql.c_str(), callbackPassword, &num_of_ans, &_zErrMsg);
	if (rc != SQLITE_OK){
		fprintf(stderr, "SQL error: %s\n", _zErrMsg);
		sqlite3_free(_zErrMsg);
	}
	string temp1 = to_string(atoi(num_of_ans.c_str()) - atoi(correct_ans.c_str()));
	s.push_back(Helper::getPaddedNumber(atoi(temp1.c_str()), 6));
	string time;
	sql = "SELECT AVG(answer_time) FROM t_players_answers WHERE username = '" + username + "';";
	rc = sqlite3_exec(_db, sql.c_str(), callbackPassword, &time, &_zErrMsg);
	if (rc != SQLITE_OK){
		fprintf(stderr, "SQL error: %s\n", _zErrMsg);
		sqlite3_free(_zErrMsg);
	}
	string temp2 = "";
	if (time[1] == '.')
	{
		temp2.push_back('0');
		temp2.push_back(time[0]);
		temp2.push_back(time[2]);
		temp2.push_back(time[3]);
	}
	else
	{
		temp2.push_back(time[0]);
		temp2.push_back(time[1]);
		temp2.push_back(time[3]);
		temp2.push_back(time[4]);
	}
	s.push_back(temp2);

	return s;
}

const string currentDateTime() {
	time_t     now = time(0);
	struct tm  tstruct;
	char       buf[80];
	localtime_s(&tstruct,&now);
	strftime(buf, sizeof(buf), "%Y-%m-%d.%X", &tstruct);

	return buf;
}
int DataBase::insertNewGame(){
	string status = "0";
	string curt = currentDateTime();
	string id = "";
	string sql = "SELECT MAX(game_id) From t_games;";
	int rc = sqlite3_exec(_db, sql.c_str(), callbackPassword, &id, &_zErrMsg);
	if (rc != SQLITE_OK){
		fprintf(stderr, "SQL error: %s\n", _zErrMsg);
		sqlite3_free(_zErrMsg);
		return false;
	}
	int id_to_insert = atoi(id.c_str());
	id_to_insert += 1;
	sql = "INSERT INTO t_games (game_id,status,start_time,end_time) VALUES ('" + to_string(id_to_insert) +
		"','" + status + "','" + curt + "','" + "NULL" + "');";
	rc = sqlite3_exec(_db, sql.c_str(), NULL, NULL, &_zErrMsg);
	if (rc != SQLITE_OK){
		fprintf(stderr, "SQL error: %s\n", _zErrMsg);
		sqlite3_free(_zErrMsg);
		return false;
	}
	return id_to_insert;
}

bool DataBase::updateGameStatus(int gameId){
	string sql = "UPDATE t_games SET status = '1' WHERE game_id = " + to_string(gameId) + ";";
	int rc = sqlite3_exec(_db, sql.c_str(), NULL, NULL, &_zErrMsg);
	if (rc != SQLITE_OK){
		fprintf(stderr, "SQL error: %s\n", _zErrMsg);
		sqlite3_free(_zErrMsg);
		return false;
	}
	return true;
}

bool DataBase::addAnswerToPlayer(int gameId, string username, int questionId, string answer, bool isCorrect, int answerTime){
	time_t result = time(nullptr);
	string time = currentDateTime();
	string sql = "INSERT INTO t_players_answers (game_id ,username ,question_id ,player_answer ,is_correct ,answer_time ) VALUES ('" + to_string(gameId) + "','" + username + "','" + to_string(questionId) + "','" + answer + "','" + to_string(isCorrect) + "','" + to_string(answerTime) + "');";
	int rc = sqlite3_exec(_db, sql.c_str(), NULL, NULL, &_zErrMsg);
	if (rc != SQLITE_OK){
		fprintf(stderr, "SQL error: %s\n", _zErrMsg);
		sqlite3_free(_zErrMsg);
		return false;
	}
	return true;
}
