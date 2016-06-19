#include "TriviaServer.h"
int TriviaServer::_roomIdSequence = 0;
TriviaServer::TriviaServer(){
	this->_empty = true;
	//db constrastor is automatically called and he will throw an exception if failed
	//need to create new socket
	WSADATA wsaData;
	int iResult;
	iResult = WSAStartup(MAKEWORD(2, 2), &wsaData); // Initialize Winsock
	if (iResult != 0) {
		cout << "WSAStartup failed with error: " + iResult << endl;
	}
	cout << "Initialized Winsock" << endl;
	// Create a SOCKET for connecting to server
	try{
		_socket = socket(AF_INET, SOCK_STREAM, 0);
	}
	catch (exception e){
		cout << e.what() << endl;
	}
	if (_socket == INVALID_SOCKET) {
		printf("socket failed with error: %ld\n", WSAGetLastError());
		WSACleanup();
	}
	else{
		cout << "Socket created" << endl;
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
	thread handle_messages(&TriviaServer::handleRecievedMessage,this);
	handle_messages.detach();
	while (true){
		this->accept();
	}
}
void TriviaServer::bindAndListen(){
	SOCKADDR_IN addr; // The address structure for a TCP socket
	WSADATA wsaData;
	int iResult = WSAStartup(MAKEWORD(2, 2), &wsaData);
	if (iResult != NO_ERROR) {
		throw exception("WSAStartup failed with error: " + iResult);
	}
	addr.sin_family = AF_INET;      // Address family
	addr.sin_port = htons(8820);
	addr.sin_addr.s_addr = htonl(INADDR_ANY);
	if (::bind(_socket, (LPSOCKADDR)&addr, sizeof(addr)) == SOCKET_ERROR){
		//We couldn't bind (this will happen if you try to bind to the same  
		//socket more than once)
		throw exception("Failed to bind");
	}
	cout << "bind success" << endl;
	if (listen(_socket, SOMAXCONN) < 0){
		throw exception("Failed to listen");
	}
	else{
		cout << "listening..." << endl;
	}
}
void TriviaServer::accept(){
	SOCKET acceptSock;
	acceptSock = ::accept(_socket, NULL, NULL);
	thread clientT(&TriviaServer::clientHandler, this, acceptSock);
	clientT.detach();
	cout << "thread is runnig\n";
}
void TriviaServer::clientHandler(SOCKET s){
	cout << "client is being handled" << endl;
	while (true){
		try{
			int messageTypeCode = Helper::getMessageTypeCode(s);
			if (messageTypeCode != 0 && messageTypeCode != 299){ //???????
				addRecievedMessage(buildRecieveMessage(s, messageTypeCode));
			}
			else{
				addRecievedMessage(buildRecieveMessage(s, 299));
			}
		}
		catch (exception e){
			addRecievedMessage(buildRecieveMessage(s, 299));
		}
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
	vector<string> temp = r->getValues();
	if (_db.isUserAndPassMatch(temp[0], temp[1])){
		if (getUserByName(r->getUser()->getUsername()) != nullptr){
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
					return true;
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
	return false;
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
	Room* adminRoom = r->getUser()->getRoom();
	Game* g = nullptr;
	try{
		g = new Game(users, adminRoom->getQuestionsNo(), _db);
	}
	catch (exception e){
		r->getUser()->send("1180"); //failed
	}
	_roomList.erase(_roomList.find(adminRoom->getId()));
	if (g != nullptr)
		g->sendFirstQuestion();

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
	if (r->getUser()->getRoom() != nullptr){
		r->getUser()->closeRoom();
		for (std::map<int, Room*>::iterator it = _roomList.begin(); it != _roomList.end(); ++it){
			if (it->second == r->getUser()->getRoom()){
				_roomList.erase(it);
			}
		}
		return true;
	}
	else{
		return false;
	}
}
bool TriviaServer::handleJoinRoom(RecievedMessage* r){
	if (r->getUser() == nullptr){
		return false;
	}
	else{
		Room* temp = getRoomById(atoi(r->getValues()[0].c_str()));
		if (temp != nullptr){
			r->getUser()->joinRoom(temp);
			return true;
		}
		else{
			r->getUser()->send("1101");
			return false;
		}
	}
}
bool TriviaServer::handleLeaveRoom(RecievedMessage* r){
	if (r->getUser() == nullptr){
		return false;
	}
	else{
		Room* temp = r->getUser()->getRoom();
		if (temp != nullptr){
			r->getUser()->leaveRoom();
			return true;
		}
		else{
			return false;
		}
	}
}
void TriviaServer::handleGetUsersInRoom(RecievedMessage* r){
	Room* temp = getRoomById(atoi(r->getValues()[0].c_str()));
	if (temp == nullptr){
		r->getUser()->send("1080");
	}
	else{
		r->getUser()->send(temp->getUsersListMessage());
	}
}
void TriviaServer::handleGetRooms(RecievedMessage* r){
	Room* result = nullptr;
	string msg = "106" + Helper::getPaddedNumber(_roomList.size(), 4);
	for (std::map<int, Room*>::iterator it = _roomList.begin(); it != _roomList.end(); ++it){
		msg += Helper::getPaddedNumber(it->first, 4) + Helper::getPaddedNumber(it->second->getName().size(), 2) + it->second->getName();
	}
	r->getUser()->send(msg);
}

void TriviaServer::handleGetBestScores(RecievedMessage* r){
	vector<string> scores = _db.getBestScores();
	string msg = "124" + scores[0];
}///////////////////////////////
void TriviaServer::handleGetPersonalStatus(RecievedMessage* r){

}//////////////////////////////
//////////////add handle finish game
void TriviaServer::handleRecievedMessage(){
	while (true){
		while (_empty == true){

		}
		RecievedMessage* temp = _queRcvMessages.front();
		_queRcvMessages.pop();	
		if (_queRcvMessages.size() == 0){
			_empty = true;
		}
		if (temp == nullptr)
			cout << "temp is NULL";
		switch (temp->getMessageCode()){
		case 200:
			//u = new User(temp->getValues()[0],temp->getSock());
			//temp->setUser(u);
			handleSignin(temp);
			break;
		case 201:
			handleSignout(temp);
			break;
		case 203:
			handleSignup(temp);
			break;
		case 205:
			handleGetRooms(temp);
			break;
		case 207:
			handleGetUsersInRoom(temp);
			break;
		case 209:
			handleJoinRoom(temp);
			break;
		case 211:
			handleLeaveRoom(temp);
			break;
		case 213:
			handleCreateRoom(temp);
			break;
		case 215:
			handleCloseRoom(temp);
			break;
		case 217:
			handleStartGame(temp);
			break;
		case 219:
			handlePlayerAnswer(temp);
			break;
		case 222:
			handleLeaveGame(temp);
			break;
		case 223:
			handleGetBestScores(temp);
			break;
		case 225:
			handleGetPersonalStatus(temp);
			break;
		default:
			break;
		}

	}
}
void TriviaServer::addRecievedMessage(RecievedMessage* r){
	_queRcvMessages.push(r);
	_empty = false;
}
RecievedMessage* TriviaServer::buildRecieveMessage(SOCKET s, int msgCode){
	vector <string> vals;
	string temp;
	RecievedMessage* r = nullptr;
	int counter = 3;
	User* u = nullptr;
	string val = "";
	int size;
	switch (msgCode){
	case 200:
		for (int i = 0; i < 2; i++){
			size = atoi((Helper::getStringPartFromSocket(s, 2)).c_str());
			val = (Helper::getStringPartFromSocket(s, size));
			vals.push_back(val);
		}
		u = new User(vals[0], s);
		r = new RecievedMessage(s, msgCode, vals);
		r->setUser(u);
		return r;
		/*size = atoi(temp.substr(3, 2).c_str());
		val = temp.substr(5, size);
		cout << val << endl;
		vals.push_back(val);
		size = atoi(temp.substr(size + 5, 2).c_str());
		val = temp.substr(5 + val.size() + 2, size);
		vals.push_back(val);
		cout << val << endl;*/
	case 201:
		u = getUserBySocket(s);
		r = new RecievedMessage(s,msgCode);
		r->setUser(u);
		return r;
	case 203:
		for (int i = 0; i < 3; i++){
			size = atoi((Helper::getStringPartFromSocket(s, 2)).c_str());
			val = (Helper::getStringPartFromSocket(s, size));
			vals.push_back(val);
		}
		u = new User(vals[0], s);
		r = new RecievedMessage(s, msgCode, vals);
		r->setUser(u);
		return r;
	case 205:
		u = getUserBySocket(s);
		r = new RecievedMessage(s, msgCode);
		r->setUser(u);
		return r;
	case 207:
		val = (Helper::getStringPartFromSocket(s, 4));
		vals.push_back(val);
		u = getUserBySocket(s);
		r = new RecievedMessage(s, msgCode, vals);
		r->setUser(u);
		return r;
	case 209:
		val = (Helper::getStringPartFromSocket(s, 4));
		vals.push_back(val);
		u = getUserBySocket(s);
		r = new RecievedMessage(s, msgCode, vals);
		r->setUser(u);
		return r;
	case 211:
		u = getUserBySocket(s);
		r = new RecievedMessage(s, msgCode);
		r->setUser(u);
		return r;
	case 213:
		size = atoi((Helper::getStringPartFromSocket(s, 2)).c_str());
		val = (Helper::getStringPartFromSocket(s, size));
		vals.push_back(val);
		val = (Helper::getStringPartFromSocket(s, 1));
		vals.push_back(val);
		val = (Helper::getStringPartFromSocket(s, 2));
		vals.push_back(val);
		val = (Helper::getStringPartFromSocket(s, 2));
		vals.push_back(val);
		u = getUserBySocket(s);
		r = new RecievedMessage(s, msgCode, vals);
		r->setUser(u);
		return r;
	case 215:
		u = getUserBySocket(s);
		r = new RecievedMessage(s, msgCode);
		r->setUser(u);
		return r;
	case 217:
		u = getUserBySocket(s);
		r = new RecievedMessage(s, msgCode);
		r->setUser(u);
		return r;
	case 219:
		val = (Helper::getStringPartFromSocket(s, 1));
		vals.push_back(val);
		val = (Helper::getStringPartFromSocket(s, 2));
		vals.push_back(val);
		u = getUserBySocket(s);
		r = new RecievedMessage(s, msgCode, vals);
		r->setUser(u);
		return r;
	case 222:
		u = getUserBySocket(s);
		r = new RecievedMessage(s, msgCode);
		r->setUser(u);
		return r;
	case 223:
		u = getUserBySocket(s);
		r = new RecievedMessage(s, msgCode);
		r->setUser(u);
		return r;
	case 225:
		u = getUserBySocket(s);
		r = new RecievedMessage(s, msgCode);
		r->setUser(u);
		return r;
	default:
		break;
	}
	return nullptr;
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