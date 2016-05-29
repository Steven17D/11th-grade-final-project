#include "TriviaServer.h"

TriviaServer::TriviaServer(){
	//db constrastor is automatically called and he will throw an exception if failed
	//need to create new socket
	_socket = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
	if (_socket == INVALID_SOCKET)
	{
		throw exception("Faild to create a socket."); //Couldn't create the socket
	}
}
TriviaServer::~TriviaServer(){
	for (std::map<int, Room*>::iterator it = _roomList.begin(); it != _roomList.end(); ++it){
		delete it->second;
	}
	for (std::map<SOCKET, User*>::iterator it = _connectedUsers.begin(); it != _connectedUsers.end(); ++it){
		delete it->second;
	}
	closesocket(_socket);
}

void TriviaServer::server(){
	bindAndListen();
	thread t(this->clientHandler, _socket);
	t.join();
	while (true){
		this->accept();
	}
}
void TriviaServer::bindAndListen(){
	SOCKADDR_IN addr; // The address structure for a TCP socket
	//WSA???????????????????????????????????????????????????????????
	addr.sin_family = AF_INET;      // Address family
	addr.sin_port = htons(5656);
	addr.sin_addr.s_addr = htonl(INADDR_ANY);
	if (::bind(_socket, (LPSOCKADDR)&addr, sizeof(addr)) == SOCKET_ERROR){
		//We couldn't bind (this will happen if you try to bind to the same  
		//socket more than once)
		throw exception("Failed to bind");
	}
	listen(_socket, SOMAXCONN);
}
void TriviaServer::accept(){

}
void TriviaServer::clientHandler(SOCKET s){
	try{
		int messageTypeCode = Helper::getMessageTypeCode(s);
		if (messageTypeCode != 0 && messageTypeCode != 299){ //???????
			addRecievedMessage(buildRecieveMessage(s, 0/*???????*/));
			messageTypeCode = Helper::getMessageTypeCode(s);
		}
		addRecievedMessage(buildRecieveMessage(s, 299));
	}
	catch (exception e){
		addRecievedMessage(buildRecieveMessage(s, 299));
	}
}
void TriviaServer::safeDeleteUser(RecievedMessage* r){
	try{
		SOCKET client_socket = r->getSock();
		handleSignout(r);
		closesocket(client_socket);
	}
	catch (exception e){
		cout << e.what() << endl;
	}
}

User* TriviaServer::handleSignin(RecievedMessage* r){
	if (_db.isUserAndPassMatch(r->getValues()[0], r->getValues()[1])){
		if (getUserByName(r->getUser()->getUsername()) == nullptr){
			r->getUser()->send("1022");
			return nullptr;
		}
		else{
			pair<SOCKET, User*> u(r->getSock(), r->getUser());
			_connectedUsers.insert(u);
			r->getUser()->send("1020");
			return r->getUser();
		}
	}
	else{
		r->getUser()->send("1021");
		return nullptr;
	}
}
bool TriviaServer::handleSignup(RecievedMessage* r){
	if (Validator::isPasswordValid(r->getValues()[1])){
		if (Validator::isUsernameValid(r->getValues()[0])){
			if (!_db.isUserExists(r->getValues()[0])){
				if (!_db.addNewUser(r->getValues()[0], r->getValues()[1], r->getValues()[2])){
					r->getUser()->send("1044");
				}
				else{
					r->getUser()->send("1040");
				}
			}
			else{
				r->getUser()->send("1042");
			}
		}
		else{
			r->getUser()->send("1043");
		}
	}
	else{
		r->getUser()->send("1041");
	}
}
void TriviaServer::handleSignout(RecievedMessage* r){
	bool user_exsist = false;
	if (r->getUser() != nullptr){
		std::map<SOCKET, User*>::iterator it;
		it = _connectedUsers.find(r->getSock());
		_connectedUsers.erase(it);
		this->handleCloseRoom(r);
		this->handleLeaveRoom(r);
		this->handleLeaveGame(r);
	}
}

void TriviaServer::handleLeaveGame(RecievedMessage* r){
	if (r->getUser()->leaveGame()){
		delete(r->getUser()->getGame());
	}
}
void TriviaServer::handleStartGame(RecievedMessage* r){
	vector<User*> users = r->getUser()->getRoom()->getUsers(); //users int the room
	//r->getUser()->getRoom()->
}
void TriviaServer::handlePlayerAnswer(RecievedMessage* r){
	if (r->getUser()->getGame() != nullptr){
		if (!r->getUser()->getGame()->handleAnswerFromUser(r->getUser(), atoi(r->getValues()[0].c_str()), atoi(r->getValues()[1].c_str()))){
			delete(r->getUser()->getGame());
		}
	}
}

bool TriviaServer::handleCreateRoom(RecievedMessage* r){
	if (r->getUser() != nullptr){
		_roomIdSequence++;
		r->getUser()->createRoom(_roomIdSequence, r->getValues()[0], atoi(r->getValues()[1].c_str()), atoi(r->getValues()[2].c_str()), atoi(r->getValues()[3].c_str()));
		pair<int, Room*> p(_roomIdSequence, r->getUser()->getRoom());
		_roomList.insert(p);
		return true;
	}
	return false;
}
bool TriviaServer::handleCloseRoom(RecievedMessage* r){

}
bool TriviaServer::handleJoinRoom(RecievedMessage* r){

}
bool TriviaServer::handleLeaveRoom(RecievedMessage* r){

}
void TriviaServer::handleGetUsersInRoom(RecievedMessage* r){

}
void TriviaServer::handleGetRooms(RecievedMessage* r){

}

void TriviaServer::handleGetBestScores(RecievedMessage* r){

}
void TriviaServer::handleGetPersonalStatus(RecievedMessage* r){

}

void TriviaServer::handleRecievedMessage(){

}
void TriviaServer::addRecievedMessage(RecievedMessage* r){

}
RecievedMessage* TriviaServer::buildRecieveMessage(SOCKET s, int msgCode){

}

User* TriviaServer::getUserByName(string name){
	User* result = nullptr;
	for (std::map<SOCKET, User*>::iterator it = _connectedUsers.begin(); it != _connectedUsers.end(); ++it){
		if (it->second->getUsername() == name){
			result = it->second;
		}
	}
	return result;
}
User* TriviaServer::getUserBySocket(SOCKET s){
	User* result = nullptr;
	for (std::map<SOCKET, User*>::iterator it = _connectedUsers.begin(); it != _connectedUsers.end(); ++it){
		if (it->first == s){
			result = it->second;
		}
	}
	return result;
}
Room* TriviaServer::getRoomById(int id){
	Room* result = nullptr;
	for (std::map<int, Room*>::iterator it = _roomList.begin(); it != _roomList.end(); ++it){
		if (it->first == id){
			result = it->second;
		}
	}
	return result;
}