#include "TriviaServer.h"
#include "Validator.h"
#include "DataBase.h"
#include <iostream>
#include <string>
#include <thread>

//      ______ _   __ ____     ____   ____   ____       __ ______ ______ ______                  
//     / ____// | / // __ \   / __ \ / __ \ / __ \     / // ____// ____//_  __/                  
//    / __/  /  |/ // / / /  / /_/ // /_/ // / / /__  / // __/  / /      / /                     
//   / /___ / /|  // /_/ /  / ____// _, _// /_/ // /_/ // /___ / /___   / /                      
//  /_____________________ __/  __/______ ______ \____//_____/______/____/   ____   ____   _   __
//    / ___//_  __// ____/| |  / // ____// | / /  ( _ )       \ \/ //   |   / __ \ / __ \ / | / /
//    \__ \  / /  / __/   | | / // __/  /  |/ /  / __ \/|      \  // /| |  / /_/ // / / //  |/ / 
//   ___/ / / /  / /___   | |/ // /___ / /|  /  / /_/  <       / // ___ | / _, _// /_/ // /|  /  
//  /____/ /_/  /_____/   |___//_____//_/ |_/   \____/\/      /_//_/  |_|/_/ |_| \____//_/ |_/   
//                                                                                               

using namespace std;

int main(){ 
	/*	VALIDATOR CLASS TESTING everything works
	string in;
	Validator d;
	do{
		cout << "Enter: ";
		getline(cin, in);
		cout << endl << "password: " << d.isPasswordValid(in)
			<< endl << "username: " << d.isUsernameValid(in) << endl;
	} while (in != "0");
	*/

	DataBase* db = new DataBase();

	return 0;
}