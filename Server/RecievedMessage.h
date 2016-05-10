#ifndef RECIEVEDMESSAGE_H_
#define RECIEVEDMESSAGE_H_
#include "User.h"
#include <iostream>
#include <vector>
using namespace std;
class RecievedMessage{
private:
	SOCKET _sock;
	User* _user;
	int _messageCode;
	vector<string> _values;

public:
	RecievedMessage(SOCKET s, int messageCode); // note add name
	RecievedMessage(SOCKET s, int messageCode, vector<string> _values); // note add name

	SOCKET getSock();
	User* getUser();
	void setUser(User* u);
	int getMessageCode();
	vector<string>& getValues();
};

#endif