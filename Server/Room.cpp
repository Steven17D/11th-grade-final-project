#include "Room.h"
#include "Helper.h"

string Room::getUsersAsString(vector<User*> usersList, User* excludeUser){
	//for DEBUGING
}

void Room::sendMessage(string msg){
	sendMessage(nullptr, msg);
}

void Room::sendMessage(User* excludeUser, string msg){
	for (unsigned int i = 0; i < _users.size(); i++){
		try{
			if (_users[i] != excludeUser){
				_users[i]->send(msg);
			}
		}
		catch(exception e){
			cout << e.what() << endl;
		}
	}
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
		u->send("1100" + Helper::getPaddedNumber(_questionsNo, 2) + Helper::getPaddedNumber(_questionTime, 2));
		//server send 108
		return true;
	}
}

void Room::leaveRoom(User* u){
	
}

int Room::closeRoom(User* u){
	return 1;
}


vector<User*> Room::getUsers(){
	return _users;
}

string Room::getUsersListMessage(){
	string msg = "108" + Helper::getPaddedNumber(_users.size(), 1);
	for (unsigned int i = 0; i < _users.size(); i++){
		msg += Helper::getPaddedNumber(_users[i]->getUsername().size(), 2) + _users[i]->getUsername();
	}
	return "";
}

int Room::getQuestionsNo(){
	return _questionsNo;
}

int Room::getId(){
	return _id;
}

string Room::getName(){
	return _name;
}
