#ifndef ROOM_H_
#define ROOM_H_
#include "User.h"
#include <iostream>
#include <vector>
using namespace std;
class User;
class Room{
private:
	vector<User*> _users;
	User* _admin;
	int _maxUsers;
	int _questionTime;
	int _questionsNo;
	string _name;
	int _id;

	string getUsersAsString(vector<User*> users, User* u);
	void sendMessage(string msg);
	void sendMessage(User* u, string msg);

public:
	Room(int id, User* admin, string name, int maxUsers, int questionNo, int questionTime);

	bool joinRoom(User* u);
	void leaveRoom(User* u);
	int closeRoom(User* u);

	vector<User*> getUsers();
	string getUsersListMessage();
	int getQuestionsNo();
	int getId();
	string getName();
};

#endif