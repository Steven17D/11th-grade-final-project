#ifndef USER_H_
#define USER_H_
#include "Game.h"
#include "Room.h"
#include <iostream>
#include <WinSock2.h>
using namespace std;
class Room;
class Game;
class User{
private:
	string _username;
	Room* _currRoom;
	Game* _currGame;
	SOCKET _sock;

public:
	User(string name, SOCKET s);

	void send(string msg);

	string getUsername();
	SOCKET getSocket();
	Room* getRoom();
	Game* getGame();

	void setGame(Game* g);

	void clearRoom();
	bool createRoom(int roomId, string roomName, int maxUsers, int questionsNo, int questionTime);
	bool joinRoom(Room* r);
	void leaveRoom();
	int closeRoom();
	bool leaveGame();
};

#endif