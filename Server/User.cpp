#include "User.h"
#include "Helper.h"

User::User(string name, SOCKET s){
	_username = name;
	_sock = s;
	_currRoom = nullptr;
	_currGame = nullptr;
}


void User::send(string msg){
	Helper::sendData(_sock, msg);
}


string User::getUsername(){
	return _username;
}

SOCKET User::getSocket(){
	return _sock;
}

Room* User::getRoom(){
	return _currRoom;
}

Game* User::getGame(){
	return _currGame;
}


void User::setGame(Game* g){
	_currGame = g;
}


void User::clearRoom(){
	_currRoom = nullptr;
}

bool User::createRoom(int roomId, string roomName, int maxUsers, int questionsNo, int questionTime){
	//Protocol 114:
	//[1140] //success
	//[1141] //fail
	if (_currRoom == nullptr){
		_currRoom = new Room(roomId, this, roomName, maxUsers, questionsNo, questionTime);
		send("1140");
		return true;
	}
	else{
		send("1141");
		return false;
	}
}

bool User::joinRoom(Room* r){
	if (_currRoom == nullptr){
		_currRoom = r;
		r->joinRoom(this);
		return true;
	}
	else{
		return false;
	}
}

void User::leaveRoom(){
	if (_currRoom != nullptr){
		_currRoom->leaveRoom(this);
		_currRoom = nullptr;
	}
}

int User::closeRoom(){
	if (_currRoom == nullptr){
		return -1;
	}
	else{
		int roomId = _currRoom->closeRoom(this);
		if (roomId != -1){
			delete(_currRoom);
			_currRoom = nullptr;
		}
		return roomId;
	}
}

bool User::leaveGame(){
	if (_currRoom == nullptr){
		return false;
	}
	else{
		bool leftGame = _currGame->leaveGame(this);
		if (leftGame){
			delete(_currGame);
			_currGame = nullptr;
		}
		return leftGame;
	}
}
