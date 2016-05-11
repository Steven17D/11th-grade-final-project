#include "Validator.h"

bool Validator::isPasswordValid(string password){
	/*correct password should contain then 3 chars
	must not contain spaces
	must contain one number
	must contain one upper case char
	must contain one lower case char*/
	if (password.size() < 4)
		return false;
	bool haveSpace = false, haveNumber = false, haveUpperCase = false, haveLowerCase = false;
	for (unsigned int i = 0; i < password.size(); i++){
		if (password[i] == ' '){
			haveSpace = true;
			i = password.size(); //in case of space the loop ends
		}
		else if (password[i] >= '0' && password[i] <= '9'){
			haveNumber = true;
		}
		else if (password[i] >= 'a' && password[i] <= 'z'){
			haveLowerCase = true;
		}
		else if (password[i] >= 'A' && password[i] <= 'Z'){
			haveUpperCase = true;
		}
	}
	return (!haveSpace && haveNumber && haveLowerCase && haveUpperCase);
}

bool Validator::isUsernameValid(string username){
	/*correct username must not be empty
	must start with a letter
	must not contain spaces*/
	bool empty = true, startWithLetter = false, containsSpace = false;
	if (username.find(' ') != string::npos){
		containsSpace = true;
	}
	if ((username[0] >= 'a' && username[0] <= 'z') || (username[0] >= 'A' && username[0] <= 'Z')){
		startWithLetter = true;
	}
	if (username.size() >= 1){
		empty = false;
	}
	return (!empty && startWithLetter && !containsSpace);
}