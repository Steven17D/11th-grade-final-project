#include "User.h"
#include "Room.h"
#include "RecievedMessage.h"
#include "DataBase.h"
//test
class TriviaServer{
private:
	SOCKET _socket;
	map<SOCKET, User*> _connectedUsers;
	DataBase _db;
	map<int, Room*> _roomList;
	mutex _mtxRecievedMessages;
	queue<RecievedMessage*> _queRcvMessages;
	static int _roomIdSequence;

	void bindAndListen();
	void accept();
	void clientHandler(SOCKET s);
	void safeDeleteUser(RecievedMessage* r);

	User* handleSignin(RecievedMessage* r);
	bool handleSignup(RecievedMessage* r);
	void handleSignout(RecievedMessage* r);

	void handleLeaveGame(RecievedMessage* r);
	void handleStartGame(RecievedMessage* r);
	void handlePlayerAnswer(RecievedMessage* r);

	bool handleCreateRoom(RecievedMessage* r);
	bool handleCloseRoom(RecievedMessage* r);
	bool handleJoinRoom(RecievedMessage* r);
	bool handleLeaveRoom(RecievedMessage* r);
	void handleGetUsersInRoom(RecievedMessage* r);
	void handleGetRooms(RecievedMessage* r);

	void handleGetBestScores(RecievedMessage* r);
	void handleGetPersonalStatus(RecievedMessage* r);

	void hendleRecievedMessage();
	void addRecievedMessage(RecievedMessage* r);
	RecievedMessage* buildRecieveMessage(SOCKET s, int n);

	User* getUserByName(string name);
	User* getUserBySocket(SOCKET s);
	Room* getRoomById(int id);

public:
	TriviaServer();
	~TriviaServer();
	
	void server();
};