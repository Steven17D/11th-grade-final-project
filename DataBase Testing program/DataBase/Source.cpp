#include <iostream>
#include <sstream>
#include "sqlite3.h"
#include <vector>

using namespace std;

int callbackUserList(void *ans, int argc, char **argv, char **azColName){
	if (argc != 0){
		vector<string>* _users = (vector<string>*)ans;
		for (int i = 0; i < argc; i++){
			_users->push_back(string(argv[i]));

		}
	}
	return 0;
}

int main(){
	sqlite3* db;
	char *zErrMsg = 0;
	if (sqlite3_open("trivia.db", &db)){
		cout << "Can't open database: " << sqlite3_errmsg(db) << endl;
		sqlite3_close(db);
		system("Pause");
		return(1);
	}
	vector<string> users;
	int rc = sqlite3_exec(db, "SELECT username FROM t_users;", callbackUserList, &users, &zErrMsg);
	if (rc != SQLITE_OK){
		fprintf(stderr, "SQL error: %s\n", zErrMsg);
		sqlite3_free(zErrMsg);
	}
	for (unsigned int i = 0; i < users.size(); i++){
		cout << (users)[i] << endl;
	}
	sqlite3_close(db);
	system("pause");
	return 0;
}
