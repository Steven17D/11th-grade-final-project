#ifndef VALIDATOR_H_
#define VALIDATOR_H_
#include <iostream>
using namespace std;
class Validator{
public:
	static bool isPasswordValid(string password);
	static bool isUsernameValid(string username);
};

#endif