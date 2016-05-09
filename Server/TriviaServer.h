#include <vector>
#include <thread>
#include <mutex>
#include <map>
#include <WinSock2.h>

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


public:
	TriviaServer();
	~TriviaServer();
	
	void server();

	
};