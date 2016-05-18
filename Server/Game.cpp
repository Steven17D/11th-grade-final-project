#include "Game.h"

bool Game::insertGameToDB(){
	
}

void Game::initQuestionsFromDB(){
	
}

string creat118Msg(Question* q){
	string msg;
	msg = "118";
	char qSize[3] = { 0, 0, 0 };
	qSize[2] = q->getQuestion().size() % 10;
	qSize[1] = (q->getQuestion().size() % 100) / 10; // 245 % 100 = 45; 45 / 10 = 4;
	qSize[0] = q->getQuestion().size() / 100;
	msg = msg + qSize;
	string* ans = q->getAnswers();
	for (int i = 0; i < 4; i++){
		
	}

}

void Game::sendQuestionToAllUsers(){
	_currentTurnAnswers = 0;
	string msg = creat118Msg(_questions[_currQuestionIndex]); //message 118
	for (unsigned int i = 0; i < _players.size(); i++){
		try{
			_players[i]->send(msg);
		}
		catch(exception e){
			_players[0]->send("1180");
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
	for (std::map<string, int>::iterator it = _results.begin(), int i = 0; i < _players.size(); it++, i++){
		_results.insert(it, std::pair<string, int>(_players[i]->getUsername(), 0));
	}
}

Game::~Game(){
	///////////?
}


void Game::sendFirstQuestion(){
	sendQuestionToAllUsers();
}

string create121Msg(User* player){

}

void Game::handleFinishGame(){
	_db.updateGameStatus(getId());
	for (unsigned int i = 0; i < _players.size(); i++){
		try{
			_players[i]->send(create121Msg(_players[i]));
			_players[i]->setGame(nullptr);
		}
		catch (exception e){
			cout << e.what() << endl;
		}
	}
}

bool Game::handleNextTurn(){
	if (_players.size() < 1){
		handleFinishGame();
		return false;
	}
	else if (_currentTurnAnswers == _players.size()){
		if (_currQuestionIndex + 1 == _questions_no){
			handleFinishGame();
			return false;
		}
		else{
			_currQuestionIndex++;
			sendQuestionToAllUsers();
		}
	}
	return true;
}

bool Game::handleAnswerFromUser(User* u, int answerNo, int time){
	_currentTurnAnswers++;
	if (answerNo == _questions[_currQuestionIndex]->getCorrectAnswerIndex()){
		_results[u->getUsername()]++;
		_db.addAnswerToPlayer(getId(), u->getUsername(), _currQuestionIndex, _questions[_currQuestionIndex]->getAnswers()[answerNo], true, time);
		u->send("1201");
	}
	else if(answerNo != 5){
		_db.addAnswerToPlayer(getId(), u->getUsername(), _currQuestionIndex, _questions[_currQuestionIndex]->getAnswers()[answerNo], false, time);
		u->send("1200");
	}
	else{
		_db.addAnswerToPlayer(getId(), u->getUsername(), _currQuestionIndex, "", false, time);
		u->send("1200");
	}
	handleNextTurn();
}

bool Game::leaveGame(User* currUser){
	std::vector<User*>::iterator position = std::find(_players.begin(), _players.end(), currUser);
	if (position != _players.end()){
		_players.erase(position);
	}
	handleNextTurn();
	if ((_currentTurnAnswers == _players.size() && _currQuestionIndex + 1 == _questions_no) || _players.size() < 1){
		return false;
	}
	else{
		return true;
	}
}

int Game::getId(){
	return 1; /////////////////////////////?
}
