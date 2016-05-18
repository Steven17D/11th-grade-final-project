#include "RecievedMessage.h"

RecievedMessage::RecievedMessage(SOCKET s, int messageCode){
	_sock = s;
	_messageCode = messageCode;
}

RecievedMessage::RecievedMessage(SOCKET s, int messageCode, vector<string> values){
	_sock = s;
	_messageCode = messageCode;
	_values = values;
}


SOCKET RecievedMessage::getSock(){
	return _sock;
}

User* RecievedMessage::getUser(){
	return _user;
}

void RecievedMessage::setUser(User* u){
	_user = u;
}

int RecievedMessage::getMessageCode(){
	return _messageCode;
}

vector<string>& RecievedMessage::getValues(){
	return _values;
}
