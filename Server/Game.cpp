#include "Game.h"

bool Game::insertGameToDB(){
	
}

void Game::initQuestionsFromDB(){
	
}

string creat118Msg(){

}

void Game::sendQuestionToAllUsers(){
	currentTurnAnswers = 0;
	string msg = creat118Msg(); //message 118
	for (unsigned int i = 0; i < _players.size(); i++){
		try{
			_players[i]->send(msg);
		}
		catch(exception e){
			cout << e.what() << endl;
		}
	}
}


Game::Game(const vector<User*>& users, int questionsNo, DataBase& db) : _db(db){
	_players = users;
	_questions_no = questionsNo;
	try{
		int roomId = _db.insertNewGame();
		_questions = _db.initQuestions(_questions_no);
		for (unsigned int i = 0; i < _players.size(); i++){
			_players[i]->setGame(this);
		}
	}catch(exception e){
		cout << e.what() << endl;
	}
}

Game::~Game(){
	///////////?
}


void Game::sendFirstQuestion(){
	sendQuestionToAllUsers();
}

void Game::handleFinishGame(){
	_db.updateGameStatus();
}

bool Game::handleNextTurn(){
	
}

bool Game::handleAnswerFromUser(User* u, int answerNo, int time){
	
}

bool Game::leaveGame(User*){
	
}

int Game::getId(){
	
}
