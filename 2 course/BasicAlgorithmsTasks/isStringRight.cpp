#include <iostream>
#include <string>
#define MAXSTACKSIZE 100

using namespace std;

//определение правильности вложенности скобок в строке

bool IsStringRight(string&); 

struct STACK { 
	char A[MAXSTACKSIZE]; 
	int v;	//количество элементов
};

STACK S;

int main() {

	S.v = 0;

	string str;
	cin >> str; 
	if (IsStringRight(str)) {
		cout << "String is right";
	}
	else {
		cout << "String is wrong";
	}
	return 0;
}

bool IsStringRight(string& str) {

	char currStrChar;	
	char tempCharFromStack;

	
	while (str.empty() == false) {
		currStrChar = str[0];
		if ((currStrChar == '{') || (currStrChar == '(') || (currStrChar == '[')) {
			S.A[S.v] = currStrChar;
			++S.v;

		} else	{
			if ((currStrChar == '}') || (currStrChar == ')') || (currStrChar == ']')) {
				--S.v;
				if (S.v == -1)
					return false;
				tempCharFromStack = S.A[S.v];

				if (currStrChar == '}') {
					if (tempCharFromStack != '{')
						return false;
				}
				if (currStrChar == ']') {
					if (tempCharFromStack != '[')
						return false;
				}
				if (currStrChar == ')') {
					if (tempCharFromStack != '(')
						return false;
				}
			}			
		}
		str.erase(0,1);		
	}
	if (S.v == 0)
		return true;
	else
		return false;	

}