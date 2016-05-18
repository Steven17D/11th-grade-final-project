#include "Room.h"

string Room::getUsersAsString(vector<User*> users, User* u){
	
}

void Room::sendMessage(string msg){
	
}

void Room::sendMessage(User* u, string msg){
	
}



Room::Room(int id, User* admin, string name, int maxUsers, int questionNo, int questionTime){
	_id = id;
	_admin = admin;
	_users.push_back(admin);
	_name = name;
	_maxUsers = maxUsers;
	_questionsNo = questionNo;
	_questionTime = questionTime;
}


bool Room::joinRoom(User* u){
	if (_users.size() == _maxUsers){
		u->send("1101");
		return false;
	}
	else{
		_users.push_back(u);
		u->send("1100"+_questionsNo+_questionTime); //make 2 bytes
		return true;
	}
}

void Room::leaveRoom(User* u){
	//_users.
}

int Room::closeRoom(User* u){
	
}


vector<User*> Room::getUsers(){
	
}

string Room::getUsersListMessage(){
	
}

int Room::getQuestionsNo(){
	
}

int Room::getId(){
	
}

string Room::getName(){
	
}
